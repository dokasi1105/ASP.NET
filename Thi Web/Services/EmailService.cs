using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using TechShop.Models;

namespace TechShop.Services
{
    public interface IEmailService
    {
        Task SendOrderConfirmationAsync(string toEmail, string customerName, Order order);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendOrderConfirmationAsync(string toEmail, string customerName, Order order)
        {
            // Thiết lập nội dung Email dạng HTML
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("TechShop Store", _config["SmtpSettings:SenderEmail"]));
            message.To.Add(new MailboxAddress(customerName, toEmail));
            message.Subject = $"Xác nhận đơn hàng #{order.Id} từ TechShop";

            var builder = new BodyBuilder();
            builder.HtmlBody = $@"
                <div style='font-family: Arial, sans-serif; color: #333;'>
                    <h2 style='color: #4f46e5;'>Cảm ơn bạn đã đặt hàng, {customerName}!</h2>
                    <p>Đơn hàng <strong>#{order.Id}</strong> của bạn đã được ghi nhận vào hệ thống lúc {order.OrderDate.ToString("dd/MM/yyyy HH:mm")}.</p>
                    <table border='1' cellpadding='10' cellspacing='0' style='border-collapse: collapse; width: 100%; max-width: 600px;'>
                        <tr style='background-color: #f1f5f9;'>
                            <th>Sản phẩm</th>
                            <th>Số lượng</th>
                            <th>Thành tiền</th>
                        </tr>";

            foreach (var detail in order.OrderDetails)
            {
                builder.HtmlBody += $@"
                        <tr>
                            <td>{detail.Product?.Name}</td>
                            <td align='center'>{detail.Quantity}</td>
                            <td align='right'>{detail.UnitPrice.ToString("N0")} ₫</td>
                        </tr>";
            }

            builder.HtmlBody += $@"
                        <tr style='font-weight: bold;'>
                            <td colspan='2' align='right'>Tổng thanh toán:</td>
                            <td align='right' style='color: #dc3545;'>{order.TotalAmount.ToString("N0")} ₫</td>
                        </tr>
                    </table>
                    <p>Chúng tôi sẽ liên hệ để giao hàng trong thời gian sớm nhất.</p>
                </div>";

            message.Body = builder.ToMessageBody();

            // Kết nối SMTP và gửi
            using var client = new SmtpClient();
            try
            {
                // Sử dụng cấu hình từ appsettings.json
                string server = _config["SmtpSettings:Server"];
                int port = int.Parse(_config["SmtpSettings:Port"]);
                string user = _config["SmtpSettings:Username"];
                string pass = _config["SmtpSettings:Password"];

                await client.ConnectAsync(server, port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(user, pass);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                // Xử lý ghi log lỗi nếu không gửi được (bỏ qua nếu muốn app không sập)
                Console.WriteLine($"Lỗi gửi Email: {ex.Message}");
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}