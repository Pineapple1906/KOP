using System.ComponentModel;
using System.Text;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace WinFormsLibrary1
{
    public partial class PicToPDF : Component
    {
        public PicToPDF()
        {
            InitializeComponent();
        }

        public void GenPdf(ImagesPdfInfo info)
        {
            if (info.Images == null || string.IsNullOrEmpty(info.Title) || string.IsNullOrEmpty(info.FileName))
            {
                return;
            }

            var  document = new Document();

            var style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
            style.Font.Color = MigraDoc.DocumentObjectModel.Color.Parse("Black");

            var section = document.AddSection();

            var paragraph = section.AddParagraph(info.Title);

            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            foreach (string item in info.Images)
                section.AddImage(item);

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
