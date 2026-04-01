using QuestPDF.Elements.Table;
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
        // ── Palette ────────────────────────────────────────────
        private static readonly string Indigo900 = "#1e1b4b";
        private static readonly string Indigo700 = "#3730a3";
        private static readonly string Indigo500 = "#6366f1";
        private static readonly string Indigo100 = "#e0e7ff";
        private static readonly string Indigo50 = "#eef2ff";

        private static readonly string Slate800 = "#1e293b";
        private static readonly string Slate600 = "#475569";
        private static readonly string Slate400 = "#94a3b8";
        private static readonly string Slate200 = "#e2e8f0";
        private static readonly string Slate100 = "#f1f5f9";
        private static readonly string Slate50 = "#f8fafc";
        private static readonly string White = "#ffffff";

        private static readonly string Emerald600 = "#059669";
        private static readonly string Emerald50 = "#ecfdf5";
        private static readonly string Rose600 = "#e11d48";
        private static readonly string Rose50 = "#fff1f2";
        private static readonly string Amber600 = "#d97706";
        private static readonly string Amber50 = "#fffbeb";

        // ── Sizes ──────────────────────────────────────────────
        private const int MarginH = 44;
        private const int MarginTop = 0;   // header handles its own top
        private const int MarginBot = 36;

        public byte[] GenerateOrderInvoicePdf(Order order, string customerName)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(doc =>
            {
                doc.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.MarginHorizontal(MarginH);
                    page.MarginTop(MarginTop);
                    page.MarginBottom(MarginBot);
                    page.DefaultTextStyle(t => t.FontFamily("Helvetica").FontSize(10).FontColor(Slate800));

                    // ══════════════════════════════════════════
                    // HEADER  — full-bleed indigo band
                    // ══════════════════════════════════════════
                    page.Header().Background(Indigo900).PaddingHorizontal(MarginH).PaddingTop(32).PaddingBottom(28).Column(hdr =>
                    {
                        hdr.Item().Row(row =>
                        {
                            // Brand
                            row.RelativeItem().Column(brand =>
                            {
                                brand.Item().Row(logoRow =>
                                {
                                    // Logo mark — square accent
                                    logoRow.ConstantItem(36).Height(36)
                                        .Background(Indigo500)
                                        .AlignCenter().AlignMiddle()
                                        .Text("T").Bold().FontSize(18).FontColor(White);

                                    logoRow.ConstantItem(10);

                                    logoRow.RelativeItem().Column(lbl =>
                                    {
                                        lbl.Item().Text("TechShop")
                                            .Bold().FontSize(22).FontColor(White);
                                        lbl.Item().Text("Cửa hàng công nghệ")
                                            .FontSize(8.5f).FontColor(Indigo100);
                                    });
                                });
                            });

                            // Invoice meta
                            row.ConstantItem(200).Column(meta =>
                            {
                                meta.Item().AlignRight()
                                    .Text("HÓA ĐƠN BÁN HÀNG")
                                    .Bold().FontSize(10).FontColor(Indigo100).LetterSpacing(1.5f);
                                meta.Item().PaddingTop(4).AlignRight()
                                    .Text($"#{order.Id:D6}")
                                    .Bold().FontSize(24).FontColor(White);
                                meta.Item().PaddingTop(2).AlignRight()
                                    .Text($"Ngày {order.OrderDate:dd/MM/yyyy}")
                                    .FontSize(9).FontColor(Indigo100);
                            });
                        });

                        // Thin accent stripe at bottom of header
                        hdr.Item().PaddingTop(18).Height(2).Background(Indigo500);
                    });

                    // ══════════════════════════════════════════
                    // CONTENT
                    // ══════════════════════════════════════════
                    page.Content().PaddingTop(28).Column(body =>
                    {
                        // ── 3-column info strip ────────────────
                        body.Item().Row(row =>
                        {
                            InfoCard(row.RelativeItem(), "KHÁCH HÀNG", col =>
                            {
                                col.Item().Text(customerName).Bold().FontSize(11);
                                if (!string.IsNullOrWhiteSpace(order.CustomerEmail))
                                    col.Item().PaddingTop(3).Text(order.CustomerEmail).FontSize(9).FontColor(Slate600);
                                if (!string.IsNullOrWhiteSpace(order.Phone))
                                    col.Item().Text(order.Phone).FontSize(9).FontColor(Slate600);
                            });

                            row.ConstantItem(12);

                            InfoCard(row.RelativeItem(), "ĐỊA CHỈ GIAO HÀNG", col =>
                            {
                                if (!string.IsNullOrWhiteSpace(order.Address))
                                    col.Item().Text(order.Address).FontSize(10).FontColor(Slate800);
                                var city = string.Join(", ",
                                    new[] { order.City, order.PostalCode }
                                        .Where(s => !string.IsNullOrWhiteSpace(s)));
                                if (!string.IsNullOrWhiteSpace(city))
                                    col.Item().PaddingTop(3).Text(city).FontSize(10).FontColor(Slate800);
                            });

                            row.ConstantItem(12);

                            InfoCard(row.RelativeItem(), "TRẠNG THÁI ĐƠN HÀNG", col =>
                            {
                                col.Item().PaddingBottom(6).Row(r =>
                                {
                                    r.RelativeItem().Text("Mã đơn").FontSize(8.5f).FontColor(Slate400);
                                    r.AutoItem().Text($"#{order.Id:D6}").FontSize(8.5f).Bold().FontColor(Indigo700);
                                });
                                col.Item().PaddingBottom(6).Row(r =>
                                {
                                    r.RelativeItem().Text("Ngày đặt").FontSize(8.5f).FontColor(Slate400);
                                    r.AutoItem().Text(order.OrderDate.ToString("dd/MM/yyyy")).FontSize(8.5f).Bold();
                                });
                                // Status badge
                                col.Item().PaddingTop(2).Row(r =>
                                {
                                    r.RelativeItem().Text("Trạng thái").FontSize(8.5f).FontColor(Slate400);
                                    r.AutoItem()
                                        .Background(StatusBg(order.Status))
                                        .PaddingHorizontal(8).PaddingVertical(3)
                                        .Text(TranslateStatus(order.Status))
                                        .FontSize(8f).Bold().FontColor(StatusFg(order.Status));
                                });
                            });
                        });

                        body.Item().PaddingTop(24);

                        // ── Section label ──────────────────────
                        body.Item().PaddingBottom(10).Row(r =>
                        {
                            r.ConstantItem(3).Background(Indigo500);
                            r.ConstantItem(10);
                            r.RelativeItem().AlignMiddle()
                                .Text("CHI TIẾT SẢN PHẨM")
                                .Bold().FontSize(9).FontColor(Slate600).LetterSpacing(1.2f);
                        });

                        // ── Products table ─────────────────────
                        body.Item().Table(table =>
                        {
                            table.ColumnsDefinition(cols =>
                            {
                                cols.ConstantColumn(28);        // #
                                cols.RelativeColumn(5);         // Sản phẩm
                                cols.RelativeColumn(1.2f);      // SL
                                cols.RelativeColumn(2f);        // Đơn giá
                                cols.RelativeColumn(2f);        // Thành tiền
                            });

                            // Header row
                            void Th(ITableCellContainer cell, string text, TextHorizontalAlignment align = TextHorizontalAlignment.Left)
                            {
                                var base_ = cell.Background(Slate800).PaddingVertical(10).PaddingHorizontal(10);
                                IContainer aligned = align switch
                                {
                                    TextHorizontalAlignment.Right => base_.AlignRight(),
                                    TextHorizontalAlignment.Center => base_.AlignCenter(),
                                    _ => base_
                                };
                                aligned.Text(text).Bold().FontSize(8.5f).FontColor(Slate200).LetterSpacing(0.8f);
                            }

                            table.Header(h =>
                            {
                                Th(h.Cell(), "#", TextHorizontalAlignment.Center);
                                Th(h.Cell(), "SẢN PHẨM");
                                Th(h.Cell(), "SL", TextHorizontalAlignment.Center);
                                Th(h.Cell(), "ĐƠN GIÁ", TextHorizontalAlignment.Right);
                                Th(h.Cell(), "THÀNH TIỀN", TextHorizontalAlignment.Right);
                            });

                            int idx = 1;
                            foreach (var d in order.OrderDetails ?? [])
                            {
                                bool even = idx % 2 == 0;
                                string rowBg = even ? Slate50 : White;
                                decimal lineTotal = d.UnitPrice * d.Quantity;
                                string name = d.Product?.Name ?? $"Sản phẩm #{d.ProductId}";

                                void Td(ITableCellContainer cell, string text, bool bold = false,
                                        TextHorizontalAlignment align = TextHorizontalAlignment.Left,
                                        string? color = null)
                                {
                                    var c = cell.Background(rowBg)
                                                .BorderBottom(1).BorderColor(Slate200)
                                                .PaddingVertical(9).PaddingHorizontal(10);
                                    var aligned = align == TextHorizontalAlignment.Right ? c.AlignRight()
                                                : align == TextHorizontalAlignment.Center ? c.AlignCenter()
                                                : c;
                                    var txt = aligned.Text(text).FontSize(9.5f);
                                    if (bold) txt = txt.Bold();
                                    if (color != null) txt = txt.FontColor(color);
                                }

                                Td(table.Cell(), $"{idx}", align: TextHorizontalAlignment.Center, color: Slate400);
                                Td(table.Cell(), name, bold: true);
                                Td(table.Cell(), $"{d.Quantity}", align: TextHorizontalAlignment.Center);
                                Td(table.Cell(), $"{d.UnitPrice:N0} ₫", align: TextHorizontalAlignment.Right, color: Slate600);
                                Td(table.Cell(), $"{lineTotal:N0} ₫", bold: true, align: TextHorizontalAlignment.Right, color: Slate800);

                                idx++;
                            }
                        });

                        // ── Summary / totals ───────────────────
                        body.Item().PaddingTop(16).AlignRight().Width(280).Column(summary =>
                        {
                            // Subtotal row (optional, can add discount etc. later)
                            summary.Item()
                                .Background(Indigo50)
                                .Border(1).BorderColor(Indigo100)
                                .PaddingHorizontal(16).PaddingVertical(10)
                                .Row(r =>
                                {
                                    r.RelativeItem().Text("Tổng tiền hàng").FontSize(9).FontColor(Slate600);
                                    r.AutoItem().Text($"{order.TotalAmount:N0} ₫").FontSize(9).FontColor(Slate600);
                                });

                            // Grand total row
                            summary.Item()
                                .Background(Indigo700)
                                .PaddingHorizontal(16).PaddingVertical(12)
                                .Row(r =>
                                {
                                    r.RelativeItem().AlignMiddle()
                                        .Text("TỔNG THANH TOÁN").Bold().FontSize(9.5f).FontColor(Indigo100).LetterSpacing(0.8f);
                                    r.AutoItem().AlignMiddle()
                                        .Text($"{order.TotalAmount:N0} ₫").Bold().FontSize(16).FontColor(White);
                                });
                        });

                        // ── Closing note ───────────────────────
                        body.Item().PaddingTop(24).PaddingBottom(4)
                            .BorderTop(1).BorderColor(Slate200)
                            .PaddingTop(14)
                            .Text("Cảm ơn quý khách đã tin tưởng mua sắm tại TechShop. Chúng tôi sẽ liên hệ và giao hàng sớm nhất có thể.")
                            .FontSize(8.5f).Italic().FontColor(Slate400);
                    });

                    // ══════════════════════════════════════════
                    // FOOTER
                    // ══════════════════════════════════════════
                    page.Footer()
                        .BorderTop(1).BorderColor(Slate200)
                        .PaddingTop(10)
                        .Row(foot =>
                        {
                            foot.RelativeItem().AlignLeft()
                                .Text("techshop.vn  |  support@techshop.vn  |  1800 xxxx")
                                .FontSize(8).FontColor(Slate400);

                            foot.AutoItem().AlignRight().Text(txt =>
                            {
                                txt.Span("Trang ").FontSize(8).FontColor(Slate400);
                                txt.CurrentPageNumber().FontSize(8).FontColor(Slate600);
                                txt.Span(" / ").FontSize(8).FontColor(Slate400);
                                txt.TotalPages().FontSize(8).FontColor(Slate600);
                            });
                        });
                });
            }).GeneratePdf();
        }

        // ── Helpers ────────────────────────────────────────────

        private static void InfoCard(IContainer container, string title, Action<ColumnDescriptor> content)
        {
            container
                .Border(1).BorderColor(Slate200)
                .Background(White)
                .Padding(14)
                .Column(col =>
                {
                    col.Item().PaddingBottom(8).Row(r =>
                    {
                        r.ConstantItem(2).Background(Indigo500);
                        r.ConstantItem(7);
                        r.RelativeItem().AlignMiddle()
                            .Text(title).Bold().FontSize(7.5f).FontColor(Indigo700).LetterSpacing(1f);
                    });
                    content(col);
                });
        }

        private static string TranslateStatus(string? status) => status switch
        {
            "Pending" => "Chờ xác nhận",
            "Processing" => "Đang xử lý",
            "Shipped" => "Đang giao",
            "Delivered" => "Đã giao",
            "Cancelled" => "Đã hủy",
            "AwaitingBankTransfer" => "Chờ chuyển khoản",
            _ => status ?? "Không xác định",
        };

        private static string StatusBg(string? status) => status switch
        {
            "Delivered" => Emerald50,
            "Cancelled" => Rose50,
            "AwaitingBankTransfer" => Amber50,
            _ => Indigo50,
        };

        private static string StatusFg(string? status) => status switch
        {
            "Delivered" => Emerald600,
            "Cancelled" => Rose600,
            "AwaitingBankTransfer" => Amber600,
            _ => Indigo700,
        };
    }
}
