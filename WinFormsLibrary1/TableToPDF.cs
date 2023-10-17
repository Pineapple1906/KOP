using System.ComponentModel;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace WinFormsLibrary1
{
    public partial class TableToPDF : Component
    {
        public string Error = string.Empty;
        public TableToPDF()
        {
            InitializeComponent();
        }

        public void GenPdf<T>(TablePdfInfo<T> info)
        {
            if (string.IsNullOrEmpty(info.FileName) ||
                string.IsNullOrEmpty(info.Title) ||
                info.HeaderNames == null || 
                info.MergeCellsDown == null ||
                info.RowsHeights == null ||
                info.ColumnWidth == null ||
                info.Values == null)
            {
                throw new ArgumentException("Недостаточно входных данных");
            }

            var document = new Document();
            var style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;

            var section = document.AddSection();

            var paragraph = section.AddParagraph(info.Title);

            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            var table = document.LastSection.AddTable();
            table.Borders.Width = 0.25;

            for (int i = 0; i < info.ColumnWidth.Length; i++)
                table.AddColumn().Width = info.ColumnWidth[i];

            for (int i = 0; i < info.RowsHeights.Length; i++)
            {
                var row = table.AddRow();
                if (info.MergeCellsDown.ContainsKey((i, 0)))
                    row.Cells[0].MergeDown = info.MergeCellsDown[(i, 0)];

                else if (info.MergeCellsDown.ContainsKey((i, 1)))
                    row.Cells[1].MergeDown = info.MergeCellsDown[(i, 1)];

                else
                    row.Cells[0].MergeRight = 1;

                row.HeightRule = RowHeightRule.Exactly;
                row.Height = info.RowsHeights[i];
            }
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < info.HeaderNames[i].Count; j++)
                    table.Rows[j].Cells[i].AddParagraph(info.HeaderNames[i][j]);

            List<string> hierarchy = new();

            foreach (var prop in info.Values[0].GetType().GetProperties())
                hierarchy.Add(prop.Name);

            if (info.Values != null)
            {
                int cellCol = 2;
                int cellRow = 0;
                foreach (var value in info.Values)
                {
                    foreach (string el in hierarchy)
                    {
                        foreach (var prop in value.GetType().GetProperties())
                        {
                            if (string.Equals(prop.Name, el))
                            {
                                table.Rows[cellRow].Cells[cellCol].AddParagraph(prop.GetValue(value).ToString());
                                cellRow++;
                            }
                        }
                    }
                    cellCol++;
                    cellRow = 0;
                }
            }

            var renderer = new PdfDocumentRenderer(true)
            {
                Document = document
            };
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            renderer.RenderDocument();
            renderer.PdfDocument.Save(info.FileName);
        }
    }
}
