Add DevExpress Reporting NuGet Packages
DevExpress.Reporting.Core
using DevExpress.Maui.Pdf;
using DevExpress.XtraReports.UI;
using MauiReportingApp.Data;

public partial class MainPage : ContentPage {
    //...
    public XtraReport CreateTableReport() {
        XtraReport report = new XtraReport() { Name = "Sample" };
        report.DataSource = new CountryDataSource();

        // Create a table header
        ReportHeaderBand headerBand = new ReportHeaderBand();
        headerBand.HeightF = 40;
        headerBand.BackColor = System.Drawing.Color.Beige;
        report.Bands.Add(headerBand);
        XRTable headerTable = new XRTable();
        headerTable.Rows.Add(new XRTableRow());
        XRTableCell cellDetail3 = new XRTableCell() { Text = "Country" };
        XRTableCell cellDetail4 = new XRTableCell() { Text = "Area, kmÂ²" };
        headerTable.Rows[0].Cells.AddRange([cellDetail3, cellDetail4]);
        headerTable.WidthF = report.PageWidth - report.Margins.Left - report.Margins.Right;
        headerBand.Controls.Add(headerTable);
        headerTable.BorderColor = System.Drawing.Color.Gray;
        headerTable.Padding = 0;
        headerTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;

        // Create a data table and populate it with data
        DetailBand detailBand = new DetailBand();
        detailBand.HeightF = 25;
        report.Bands.Add(detailBand);
        XRTable table = new XRTable();
        detailBand.Controls.Add(table);
        table.Rows.Add(new XRTableRow());
        XRTableCell cellDetail1 = new XRTableCell();
        XRTableCell cellDetail2 = new XRTableCell();
        cellDetail1.ExpressionBindings.Add(new ExpressionBinding("Text", "[Region]"));
        cellDetail2.ExpressionBindings.Add(new ExpressionBinding("Text", "[Area]"));
        table.Rows[0].Cells.AddRange([cellDetail1, cellDetail2]);
        table.BorderColor = System.Drawing.Color.Gray;
        table.Padding = 0;
        table.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        table.WidthF = report.PageWidth - report.Margins.Left - report.Margins.Right;

        report.CreateDocument();
        return report;
    }
}

Display the Report in PDF Viewer



Add the PdfViewer component to the page. For more information, refer to the following section: Add a PDF Viewer to the Page.
<ContentPage ...
            xmlns:dx="http://schemas.devexpress.com/maui">
    <dx:PdfViewer x:Name="pdfViewer"/>
</ContentPage>




Add the following code sample to the MainPage constructor to create a report, convert it to a PDF file, and open that file in the PDF Viewer:
public MainPage() {
    InitializeComponent();

    XtraReport report = CreateTableReport();
    string resultFile = Path.Combine(FileSystem.Current.AppDataDirectory, report.Name + ".pdf");
    report.ExportToPdf(resultFile);
    pdfViewer.DocumentSource = PdfDocumentSource.FromFile(resultFile);
}