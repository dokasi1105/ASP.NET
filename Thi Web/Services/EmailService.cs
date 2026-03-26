using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Net;
using TechShop.Models;

namespace TechShop.Services
{
    public interface IEmailService
    {
        Task SendOrderConfirmationAsync(string toEmail, string customerName, Order order);
        Task SendWelcomeEmailAsync(string toEmail, string fullName);
        Task SendPasswordResetEmailAsync(string toEmail, string resetLink);
        Task SendMembershipUpgradeEmailAsync(string toEmail, string fullName, string oldTier, string newTier, int currentPoints);
        Task<bool> SendAsync(string to, string subject, string htmlBody);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _logger;
        private readonly IPdfService _pdfService;

        public EmailService(IConfiguration config, ILogger<EmailService> logger, IPdfService pdfService)
        {
            _config = config;
            _logger = logger;
            _pdfService = pdfService;
        }

        private (string Host, int Port, bool EnableSsl, string Username, string Password, string SenderEmail, string SenderName) GetSmtp()
        {
            string host = _config["SmtpSettings:Host"] ?? "";
            string portStr = _config["SmtpSettings:Port"] ?? "587";
            string enableSslStr = _config["SmtpSettings:EnableSsl"] ?? "true";
            string username = _config["SmtpSettings:UserName"] ?? "";
            string password = _config["SmtpSettings:Password"] ?? "";
            string senderEmail = _config["SmtpSettings:FromEmail"] ?? "";
            string senderName = _config["SmtpSettings:FromName"] ?? "TechShop";

            if (!int.TryParse(portStr, out int port)) port = 587;
            if (!bool.TryParse(enableSslStr, out bool enableSsl)) enableSsl = true;

            return (host, port, enableSsl, username, password, senderEmail, senderName);
        }

        private async Task SendEmailAsync(MimeMessage message)
        {
            var smtp = GetSmtp();
            using var client = new SmtpClient();

            try
            {
                var socketOpt = smtp.EnableSsl ? SecureSocketOptions.Auto : SecureSocketOptions.None;
                await client.ConnectAsync(smtp.Host, smtp.Port, socketOpt);
                await client.AuthenticateAsync(smtp.Username, smtp.Password);
                await client.SendAsync(message);

                _logger.LogInformation("Email sent ok. To={To}, Subject={Subject}", message.To.ToString(), message.Subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Email send failed. To={To}, Subject={Subject}", message.To.ToString(), message.Subject);
                throw; // để controller bắt và không làm “mất dấu lỗi”
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
        public async Task<bool> SendAsync(string to, string subject, string htmlBody)
        {
            try
            {
                var smtp = GetSmtp();

                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress(smtp.SenderName, smtp.SenderEmail));
                message.To.Add(MimeKit.MailboxAddress.Parse(to));
                message.Subject = subject;
                message.Body = new MimeKit.BodyBuilder { HtmlBody = htmlBody }.ToMessageBody();

                using var client = new MailKit.Net.Smtp.SmtpClient();
                var socketOpt = smtp.EnableSsl ? MailKit.Security.SecureSocketOptions.Auto : MailKit.Security.SecureSocketOptions.None;
                await client.ConnectAsync(smtp.Host, smtp.Port, socketOpt);
                await client.AuthenticateAsync(smtp.Username, smtp.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                _logger.LogInformation("Email sent to {Email} with subject {Subject}", to, subject);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Send email failed to {Email} with subject {Subject}", to, subject);
                return false;
            }
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string fullName)
        {
            var smtp = GetSmtp();
            var safeName = WebUtility.HtmlEncode(fullName);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtp.SenderName, smtp.SenderEmail));
            message.To.Add(new MailboxAddress(fullName ?? "", toEmail));
            message.Subject = "Chào mừng bạn đến với TechShop!";

            message.Body = new BodyBuilder
            {
                HtmlBody = $@"
                    <div style='font-family:Arial,sans-serif; color:#111'>
                        <h3>Xin chào {safeName},</h3>
                        <p>Cảm ơn bạn đã đăng ký tài khoản tại TechShop. Chúc bạn mua sắm vui vẻ!</p>
                    </div>"
            }.ToMessageBody();

            await SendEmailAsync(message);
        }

        public async Task SendPasswordResetEmailAsync(string toEmail, string resetLink)
        {
            var smtp = GetSmtp();
            var safeLink = WebUtility.HtmlEncode(resetLink);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtp.SenderName, smtp.SenderEmail));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = "TechShop - Khôi phục mật khẩu";

            message.Body = new BodyBuilder
            {
                HtmlBody = $@"
                    <div style='font-family:Arial,sans-serif; color:#111'>
                        <h3>Yêu cầu đặt lại mật khẩu</h3>
                        <p>Vui lòng bấm link sau để đặt lại mật khẩu:</p>
                        <p><a href='{safeLink}'>Đặt lại mật khẩu</a></p>
                        <p>Nếu bạn không yêu cầu, hãy bỏ qua email này.</p>
                    </div>"
            }.ToMessageBody();

            await SendEmailAsync(message);
        }

        public async Task SendMembershipUpgradeEmailAsync(string toEmail, string fullName, string oldTier, string newTier, int currentPoints)
        {
            var smtp = GetSmtp();
            var safeName = WebUtility.HtmlEncode(fullName);
            var safeOld = WebUtility.HtmlEncode(oldTier);
            var safeNew = WebUtility.HtmlEncode(newTier);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtp.SenderName, smtp.SenderEmail));
            message.To.Add(new MailboxAddress(fullName ?? "", toEmail));
            message.Subject = "TechShop - Nâng cấp thẻ thành viên";

            message.Body = new BodyBuilder
            {
                HtmlBody = $@"
                    <div style='font-family:Arial,sans-serif; color:#111'>
                        <h3>Xin chào {safeName},</h3>
                        <p>Chúc mừng bạn đã được nâng cấp thẻ thành viên!</p>
                        <p><b>{safeOld}</b> ➜ <b>{safeNew}</b></p>
                        <p>Điểm hiện tại: <b>{currentPoints}</b></p>
                    </div>"
            }.ToMessageBody();

            await SendEmailAsync(message);
        }

        public async Task SendOrderConfirmationAsync(string toEmail, string customerName, Order order)
        {
            var smtp = GetSmtp();
            var safeName = WebUtility.HtmlEncode(customerName);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtp.SenderName, smtp.SenderEmail));
            message.To.Add(new MailboxAddress(customerName ?? "", toEmail));
            message.Subject = $"⚡ Xác nhận đơn hàng #{order.Id:D6} - TechShop";

            // HTML email body
            var itemsHtml = string.Join("", (order.OrderDetails ?? []).Select((d, i) =>
            {
                var pname = WebUtility.HtmlEncode(d.Product?.Name ?? $"SP#{d.ProductId}");
                string rowBg = i % 2 == 0 ? "#f9fafb" : "#ffffff";
                decimal lineTotal = d.UnitPrice * d.Quantity;
                return $@"
                <tr style='background:{rowBg}'>
                    <td style='padding:10px 12px;border-bottom:1px solid #e5e7eb'>{pname}</td>
                    <td style='padding:10px 12px;border-bottom:1px solid #e5e7eb;text-align:center'>{d.Quantity}</td>
                    <td style='padding:10px 12px;border-bottom:1px solid #e5e7eb;text-align:right'>{d.UnitPrice:N0} ₫</td>
                    <td style='padding:10px 12px;border-bottom:1px solid #e5e7eb;text-align:right;font-weight:bold'>{lineTotal:N0} ₫</td>
                </tr>";
            }));

            string html = $@"<!DOCTYPE html>
<html lang='vi'>
<head><meta charset='UTF-8'><meta name='viewport' content='width=device-width,initial-scale=1'></head>
<body style='margin:0;padding:0;background:#f3f4f6;font-family:Arial,Helvetica,sans-serif'>
  <table width='100%' cellpadding='0' cellspacing='0' style='background:#f3f4f6;padding:32px 0'>
    <tr><td align='center'>
      <table width='640' cellpadding='0' cellspacing='0' style='background:#ffffff;border-radius:12px;overflow:hidden;box-shadow:0 4px 24px rgba(0,0,0,.08)'>

        <!-- Header -->
        <tr>
          <td style='background:linear-gradient(135deg,#4f46e5,#7c3aed);padding:32px 40px;text-align:center'>
            <div style='font-size:28px;font-weight:800;color:#ffffff;letter-spacing:-1px'>⚡ TechShop</div>
            <div style='font-size:13px;color:rgba(255,255,255,.75);margin-top:4px'>Cửa hàng công nghệ hàng đầu</div>
          </td>
        </tr>

        <!-- Greeting -->
        <tr>
          <td style='padding:32px 40px 0'>
            <h2 style='margin:0 0 8px;font-size:22px;color:#111827'>Cảm ơn bạn đã đặt hàng, {safeName}! 🎉</h2>
            <p style='margin:0;color:#6b7280;font-size:14px'>Đơn hàng <strong style='color:#4f46e5'>#{order.Id:D6}</strong> đã được ghi nhận lúc <strong>{order.OrderDate:dd/MM/yyyy HH:mm}</strong>.</p>
          </td>
        </tr>

        <!-- Info cards -->
        <tr>
          <td style='padding:20px 40px'>
            <table width='100%' cellpadding='0' cellspacing='0'>
              <tr>
                <td width='48%' style='background:#f9fafb;border-radius:8px;padding:16px;vertical-align:top'>
                  <div style='font-size:11px;font-weight:700;color:#9ca3af;letter-spacing:1px;text-transform:uppercase;margin-bottom:8px'>Thông tin giao hàng</div>
                  <div style='font-size:13px;color:#374151;line-height:1.6'>
                    <strong>{WebUtility.HtmlEncode(order.FullName)}</strong><br>
                    {WebUtility.HtmlEncode(order.Phone ?? "")}<br>
                    {WebUtility.HtmlEncode(order.Address ?? "")}<br>
                    {WebUtility.HtmlEncode(order.City ?? "")} {WebUtility.HtmlEncode(order.PostalCode ?? "")}
                  </div>
                </td>
                <td width='4%'></td>
                <td width='48%' style='background:#f9fafb;border-radius:8px;padding:16px;vertical-align:top'>
                  <div style='font-size:11px;font-weight:700;color:#9ca3af;letter-spacing:1px;text-transform:uppercase;margin-bottom:8px'>Chi tiết đơn hàng</div>
                  <div style='font-size:13px;color:#374151;line-height:1.6'>
                    Mã đơn: <strong style='color:#4f46e5'>#{order.Id:D6}</strong><br>
                    Ngày đặt: <strong>{order.OrderDate:dd/MM/yyyy}</strong><br>
                    Trạng thái: <strong style='color:#d97706'>Đang xử lý</strong>
                  </div>
                </td>
              </tr>
            </table>
          </td>
        </tr>

        <!-- Products table -->
        <tr>
          <td style='padding:0 40px 24px'>
            <table width='100%' cellpadding='0' cellspacing='0' style='border-radius:8px;overflow:hidden;border:1px solid #e5e7eb'>
              <thead>
                <tr style='background:#4f46e5'>
                  <th style='padding:12px 12px;text-align:left;color:#fff;font-size:12px;font-weight:700;letter-spacing:.5px'>SẢN PHẨM</th>
                  <th style='padding:12px 12px;text-align:center;color:#fff;font-size:12px;font-weight:700;letter-spacing:.5px;width:60px'>SL</th>
                  <th style='padding:12px 12px;text-align:right;color:#fff;font-size:12px;font-weight:700;letter-spacing:.5px;width:110px'>ĐƠN GIÁ</th>
                  <th style='padding:12px 12px;text-align:right;color:#fff;font-size:12px;font-weight:700;letter-spacing:.5px;width:120px'>THÀNH TIỀN</th>
                </tr>
              </thead>
              <tbody>
                {itemsHtml}
              </tbody>
              <tfoot>
                <tr style='background:#f9fafb'>
                  <td colspan='3' style='padding:14px 12px;text-align:right;font-size:14px;font-weight:700;color:#111827'>TỔNG THANH TOÁN:</td>
                  <td style='padding:14px 12px;text-align:right;font-size:17px;font-weight:800;color:#dc2626'>{order.TotalAmount:N0} ₫</td>
                </tr>
              </tfoot>
            </table>
          </td>
        </tr>

        <!-- Note about PDF -->
        <tr>
          <td style='padding:0 40px 24px'>
            <div style='background:#eff6ff;border-left:4px solid #4f46e5;border-radius:4px;padding:12px 16px;font-size:13px;color:#1e40af'>
              📎 Hóa đơn PDF chi tiết đã được đính kèm trong email này.
            </div>
          </td>
        </tr>

        <!-- Footer -->
        <tr>
          <td style='background:#f9fafb;padding:24px 40px;text-align:center;border-top:1px solid #e5e7eb'>
            <p style='margin:0;font-size:13px;color:#6b7280'>TechShop sẽ liên hệ và giao hàng trong thời gian sớm nhất.</p>
            <p style='margin:8px 0 0;font-size:12px;color:#9ca3af'>© 2025 TechShop. Cảm ơn quý khách đã tin tưởng! 🙏</p>
          </td>
        </tr>

      </table>
    </td></tr>
  </table>
</body>
</html>";

            // Generate PDF invoice
            byte[] pdfBytes = _pdfService.GenerateOrderInvoicePdf(order, customerName ?? "Khách hàng");

            // Build message with PDF attachment
            var bodyBuilder = new BodyBuilder { HtmlBody = html };
            bodyBuilder.Attachments.Add(
                $"HoaDon_TechShop_{order.Id:D6}.pdf",
                pdfBytes,
                new MimeKit.ContentType("application", "pdf"));

            message.Body = bodyBuilder.ToMessageBody();
            await SendEmailAsync(message);
        }
    }
}
