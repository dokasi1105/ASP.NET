using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using TechShop.Models;

namespace TechShop.Services
{
    public interface IPdfService
    {
        byte[] GenerateOrderInvoicePdf(Order order, string customerName);
    }

    public class PdfService : IPdfService
    {
        private const string Primary = "#4f46e5";
        private const string Dark    = "#111827";
        private const string Muted   = "#6b7280";
        private const string Border  = "#e5e7eb";
        private const string EvenRow = "#f8fafc";
        private const string Red     = "#dc2626";
        private const string White   = "#ffffff";

        public byte[] GenerateOrderInvoicePdf(Order order, string customerName)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(doc =>
            {
                doc.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginHorizontal(48);
                    page.MarginTop(40);
                    page.MarginBottom(32);
                    page.DefaultTextStyle(t => t.FontSize(10).FontColor(Dark));

                    // ══════════════════════════════════════════════
                    // HEADER
                    // ══════════════════════════════════════════════
                    page.Header().Column(hdr =>
                    {
                        hdr.Item().Row(row =>
                        {
                            row.RelativeItem().Column(left =>
                            {
                                left.Item().Text("TechShop")
                                    .Bold().FontSize(26).FontColor(Primary);
                                left.Item().Text("Cua hang cong nghe hang dau Viet Nam")
                                    .FontSize(9).FontColor(Muted);
                            });

                            row.ConstantItem(170).Column(right =>
                            {
                                right.Item().AlignRight().Text("HOA DON")
                                    .Bold().FontSize(20).FontColor(Dark);
                                right.Item().AlignRight().Text($"#{order.Id:D6}")
                                    .Bold().FontSize(13).FontColor(Primary);
                                right.Item().AlignRight()
                                    .Text($"Ngay: {order.OrderDate:dd/MM/yyyy}")
                                    .FontSize(9).FontColor(Muted);
                            });
                        });

                        hdr.Item().PaddingTop(10).Height(3).Background(Primary);
                    });

                    // ══════════════════════════════════════════════
                    // CONTENT
                    // ══════════════════════════════════════════════
                    page.Content().PaddingTop(20).Column(body =>
                    {
                        // ─ Info cards row ─
                        body.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).BorderColor(Border).Padding(12).Column(b =>
                            {
                                b.Item().Text("KHACH HANG").FontSize(7.5f).Bold().FontColor(Primary);
                                b.Item().PaddingTop(5).Text(customerName).FontSize(11).Bold();
                                if (!string.IsNullOrWhiteSpace(order.CustomerEmail))
                                    b.Item().PaddingTop(2).Text(order.CustomerEmail).FontSize(9).FontColor(Muted);
                                if (!string.IsNullOrWhiteSpace(order.Phone))
                                    b.Item().Text(order.Phone).FontSize(9).FontColor(Muted);
                            });

                            row.ConstantItem(10);

                            row.RelativeItem().Border(1).BorderColor(Border).Padding(12).Column(b =>
                            {
                                b.Item().Text("DIA CHI GIAO HANG").FontSize(7.5f).Bold().FontColor(Primary);
                                if (!string.IsNullOrWhiteSpace(order.Address))
                                    b.Item().PaddingTop(5).Text(order.Address).FontSize(10);
                                var city = string.Join(" ",
                                    new[] { order.City, order.PostalCode }
                                        .Where(s => !string.IsNullOrWhiteSpace(s)));
                                if (!string.IsNullOrWhiteSpace(city))
                                    b.Item().Text(city).FontSize(10);
                            });

                            row.ConstantItem(10);

                            row.RelativeItem().Border(1).BorderColor(Border).Padding(12).Column(b =>
                            {
                                b.Item().Text("THONG TIN DON HANG").FontSize(7.5f).Bold().FontColor(Primary);
                                b.Item().PaddingTop(4).Row(r =>
                                {
                                    r.RelativeItem().Text("Ma don:").FontSize(9).FontColor(Muted);
                                    r.AutoItem().Text($"#{order.Id:D6}").FontSize(9).Bold().FontColor(Primary);
                                });
                                b.Item().PaddingTop(3).Row(r =>
                                {
                                    r.RelativeItem().Text("Ngay dat:").FontSize(9).FontColor(Muted);
                                    r.AutoItem().Text(order.OrderDate.ToString("dd/MM/yyyy")).FontSize(9).Bold();
                                });
                                b.Item().PaddingTop(3).Row(r =>
                                {
                                    r.RelativeItem().Text("Trang thai:").FontSize(9).FontColor(Muted);
                                    r.AutoItem().Text(TranslateStatus(order.Status))
                                        .FontSize(9).Bold().FontColor(StatusColor(order.Status));
                                });
                            });
                        });

                        body.Item().PaddingTop(18);

                        // ─ Products table ─
                        body.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(26);
                                cols.RelativeColumn(5);
                                cols.RelativeColumn(1);
                                cols.RelativeColumn(2);
                                cols.RelativeColumn(2);
                            });

                            table.Header(h =>
                            {
                                h.Cell().Background(Primary).PaddingVertical(9).PaddingHorizontal(7)
                                    .AlignCenter().Text("#").Bold().FontSize(9).FontColor(White);
                                h.Cell().Background(Primary).PaddingVertical(9).PaddingHorizontal(7)
                                    .Text("SAN PHAM").Bold().FontSize(9).FontColor(White);
                                h.Cell().Background(Primary).PaddingVertical(9).PaddingHorizontal(7)
                                    .AlignCenter().Text("SL").Bold().FontSize(9).FontColor(White);
                                h.Cell().Background(Primary).PaddingVertical(9).PaddingHorizontal(7)
                                    .AlignRight().Text("DON GIA").Bold().FontSize(9).FontColor(White);
                                h.Cell().Background(Primary).PaddingVertical(9).PaddingHorizontal(7)
                                    .AlignRight().Text("THANH TIEN").Bold().FontSize(9).FontColor(White);
                            });

                            int idx = 1;
                            foreach (var d in order.OrderDetails ?? [])
                            {
                                string  bg        = idx % 2 == 0 ? EvenRow : White;
                                decimal lineTotal = d.UnitPrice * d.Quantity;
                                string  name      = d.Product?.Name ?? $"San pham #{d.ProductId}";

                                table.Cell().Background(bg).BorderBottom(1).BorderColor(Border)
                                    .PaddingVertical(8).PaddingHorizontal(7)
                                    .AlignCenter().Text($"{idx}").FontSize(9).FontColor(Muted);

                                table.Cell().Background(bg).BorderBottom(1).BorderColor(Border)
                                    .PaddingVertical(8).PaddingHorizontal(7)
                                    .Text(name).FontSize(10);

                                table.Cell().Background(bg).BorderBottom(1).BorderColor(Border)
                                    .PaddingVertical(8).PaddingHorizontal(7)
                                    .AlignCenter().Text($"{d.Quantity}").FontSize(10);

                                table.Cell().Background(bg).BorderBottom(1).BorderColor(Border)
                                    .PaddingVertical(8).PaddingHorizontal(7)
                                    .AlignRight().Text($"{d.UnitPrice:N0} VND").FontSize(10);

                                table.Cell().Background(bg).BorderBottom(1).BorderColor(Border)
                                    .PaddingVertical(8).PaddingHorizontal(7)
                                    .AlignRight().Text($"{lineTotal:N0} VND").FontSize(10).Bold();

                                idx++;
                            }
                        });

                        // ─ Total box ─
                        body.Item().AlignRight().Width(270)
                            .Background(EvenRow).Border(1).BorderColor(Border)
                            .Padding(14).Row(r =>
                            {
                                r.RelativeItem().Text("TONG THANH TOAN")
                                    .FontSize(11).Bold().FontColor(Dark);
                                r.AutoItem().Text($"{order.TotalAmount:N0} VND")
                                    .FontSize(14).Bold().FontColor(Red);
                            });

                        // ─ Closing ─
                        body.Item().PaddingTop(20).Height(2).Background(Primary);
                        body.Item().PaddingTop(10)
                            .Text("Cam on quy khach da tin tuong mua sam tai TechShop. Chung toi se lien he va giao hang som nhat.")
                            .FontSize(9).Italic().FontColor(Muted);
                    });

                    // ══════════════════════════════════════════════
                    // FOOTER
                    // ══════════════════════════════════════════════
                    page.Footer().AlignCenter().Text(txt =>
                    {
                        txt.Span("TechShop  |  Trang ").FontSize(8).FontColor(Muted);
                        txt.CurrentPageNumber().FontSize(8).FontColor(Muted);
                        txt.Span(" / ").FontSize(8).FontColor(Muted);
                        txt.TotalPages().FontSize(8).FontColor(Muted);
                    });
                });
            }).GeneratePdf();
        }

        private static string TranslateStatus(string? status) => status switch
        {
            "Pending"               => "Cho xac nhan",
            "Processing"           => "Dang xu ly",
            "Shipped"              => "Dang giao hang",
            "Delivered"            => "Da giao hang",
            "Cancelled"            => "Da huy",
            "AwaitingBankTransfer" => "Cho chuyen khoan",
            _                      => status ?? "Khong xac dinh"
        };

        private static string StatusColor(string? status) => status switch
        {
            "Delivered"            => "#16a34a",
            "Cancelled"            => "#dc2626",
            "AwaitingBankTransfer" => "#d97706",
            _                      => Primary
        };
    }
}
