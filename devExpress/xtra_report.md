using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DevExpress.XtraReports.UI;

// 1. Veri Modeli
public class UrunModel
{
    public int Id { get; set; }
    public string UrunAdi { get; set; }
    public decimal Fiyat { get; set; }
    public int Stok { get; set; }
}

public class ReportPdfGenerator
{
    public void ExportReportToPdf(string dosyaYolu)
    {
        // 2. Örnek Veri Listesi
        List<UrunModel> urunler = new List<UrunModel>
        {
            new UrunModel { Id = 1, UrunAdi = "Kablosuz Klavye", Fiyat = 750.00m, Stok = 45 },
            new UrunModel { Id = 2, UrunAdi = "Ergonomik Mouse", Fiyat = 450.50m, Stok = 120 },
            new UrunModel { Id = 3, UrunAdi = "27 Inç Monitör", Fiyat = 6200.00m, Stok = 15 }
        };

        // 3. Rapor Nesnesinin ve Sayfa Yapısının Oluşturulması
        XtraReport report = new XtraReport();
        report.PaperKind = System.Drawing.Printing.PaperKind.A4;
        report.Margins = new System.Drawing.Printing.Margins(40, 40, 40, 40);

        // 4. Rapor Başlığı (Report Header)
        ReportHeaderBand reportHeader = new ReportHeaderBand { HeightF = 40 };
        XRLabel titleLabel = new XRLabel
        {
            Text = "ÜRÜN STOK VE FİYAT RAPORU",
            Font = new Font("Arial", 14, FontStyle.Bold),
            ForeColor = Color.DarkNavy,
            SizeF = new SizeF(515, 30),
            LocationF = new PointF(0, 0),
            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        };
        reportHeader.Controls.Add(titleLabel);
        report.Bands.Add(reportHeader);

        // 5. Tablo Başlıkları (Page Header Band)
        PageHeaderBand pageHeader = new PageHeaderBand { HeightF = 25 };
        XRTable headerTable = new XRTable { SizeF = new SizeF(515, 25), LocationF = new PointF(0, 0) };
        XRTableRow headerRow = new XRTableRow();

        XRTableCell hCell1 = new XRTableCell { Text = "ID", Weight = 1, BackColor = Color.LightGray, Font = new Font("Arial", 9, FontStyle.Bold) };
        XRTableCell hCell2 = new XRTableCell { Text = "Ürün Adı", Weight = 3, BackColor = Color.LightGray, Font = new Font("Arial", 9, FontStyle.Bold) };
        XRTableCell hCell3 = new XRTableCell { Text = "Fiyat", Weight = 2, BackColor = Color.LightGray, Font = new Font("Arial", 9, FontStyle.Bold) };
        XRTableCell hCell4 = new XRTableCell { Text = "Stok", Weight = 1.5, BackColor = Color.LightGray, Font = new Font("Arial", 9, FontStyle.Bold) };

        headerRow.Cells.AddRange(new XRTableCell[] { hCell1, hCell2, hCell3, hCell4 });
        headerTable.Rows.Add(headerRow);
        pageHeader.Controls.Add(headerTable);
        report.Bands.Add(pageHeader);

        // 6. Satır Verileri (Detail Band - Data Binding)
        DetailBand detail = new DetailBand { HeightF = 25 };
        XRTable detailTable = new XRTable { SizeF = new SizeF(515, 25), LocationF = new PointF(0, 0) };
        XRTableRow detailRow = new XRTableRow();

        XRTableCell dCellId = new XRTableCell { Weight = 1 };
        dCellId.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[Id]"));

        XRTableCell dCellAd = new XRTableCell { Weight = 3 };
        dCellAd.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[UrunAdi]"));

        XRTableCell dCellFiyat = new XRTableCell { Weight = 2 };
        dCellFiyat.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "FormatString('{0:N2} ₺', [Fiyat])"));

        XRTableCell dCellStok = new XRTableCell { Weight = 1.5 };
        dCellStok.ExpressionBindings.Add(new ExpressionBinding("BeforePrint", "Text", "[Stok]"));

        detailRow.Cells.AddRange(new XRTableCell[] { dCellId, dCellAd, dCellFiyat, dCellStok });
        detailTable.Rows.Add(detailRow);
        detail.Controls.Add(detailTable);
        report.Bands.Add(detail);

        // 7. Veri Kaynağını Bağlama
        report.DataSource = urunler;

        // 8. PDF Olarak Dosyaya Kaydetme
        report.ExportToPdf(dosyaYolu);
    }

    // E-posta gönderiminde diske kaydetmeden kullanmak için MemoryStream yöntemi:
    public byte[] ExportReportToStream()
    {
        XtraReport report = new XtraReport();
        // (Bant ve alan tanımlamaları yukarıdaki gibidir)

        using (MemoryStream ms = new MemoryStream())
        {
            report.ExportToPdf(ms);
            return ms.ToArray();
        }
    }
}