using System.ComponentModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms.DataVisualization.Charting;
using Font = iTextSharp.text.Font;

namespace WinFormsLibrary1
{
    public partial class DiagramToPDF : Component
    {
        public DiagramToPDF()
        {
            InitializeComponent();
        }

        public void GenPdf(ChartPdfInfo info)
        {
            // Проверяем входные данные
            if (string.IsNullOrEmpty(info.FileName) || string.IsNullOrEmpty(info.Title) || string.IsNullOrEmpty(info.ChartTitle) || info.Data == null || info.Data.Count == 0)
            {
                throw new ArgumentException("Недостаточно входных данных");
            }

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(info.FileName, FileMode.Create));
            document.Open();

            Paragraph title = new Paragraph(info.Title, new Font(Font.FontFamily.TIMES_ROMAN, 14f, Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            Chart chart = new Chart();
            chart.Width = 500;
            chart.Height = 300;

            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;
            foreach (var item in info.Data)
            {
                series.Points.AddXY(item.SeriesName, item.Value);
            }
            chart.Series.Add(series);

            chart.Titles.Add(info.ChartTitle);

            switch (info.LegendPosition)
            {
                case LegendPosition.Top:
                    chart.Legends.Add(new Legend("Legend"));
                    chart.Legends["Legend"].Docking = Docking.Top;
                    break;
                case LegendPosition.Bottom:
                    chart.Legends.Add(new Legend("Legend"));
                    chart.Legends["Legend"].Docking = Docking.Bottom;
                    break;
                case LegendPosition.Left:
                    chart.Legends.Add(new Legend("Legend"));
                    chart.Legends["Legend"].Docking = Docking.Left;
                    break;
                case LegendPosition.Right:
                    chart.Legends.Add(new Legend("Legend"));
                    chart.Legends["Legend"].Docking = Docking.Right;
                    break;
            }

            string chartImageFile = Path.GetTempFileName() + ".png";
            chart.SaveImage(chartImageFile, ChartImageFormat.Png);

            iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(chartImageFile);
            document.Add(chartImage);

            document.Close();

            // Удаление временного файла с изображением
            File.Delete(chartImageFile);
        }
    }
}
