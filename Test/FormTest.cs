using System.Security.Cryptography;
using WinFormsLibrary1;

namespace Test
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            /*            myTree1.SetConfig(new List<string>() { "Name", "Description", "Col" });
                        myTree1.CreateTree(new Test("qwre", "ASDSADADASDS", 123));
                        myTree1.CreateTree(new Test("adsads", "ASDSADADsSADS", 2342));
                        myTree1.CreateTree(new Test("qwrasdasde", "ASDSADADSASADS", 123234));
                        myTree1.CreateTree(new Test("qwredasasdads", "ASDASDASDSADADS", 12376556));*/


        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(myTree2.GetSelectedNode<BookViewModel>().Id);

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            myCheckedListBox1.CleatItems();
        }

        private void buttonSelected_Click(object sender, EventArgs e)
        {
            label1.Text = myCheckedListBox1.SelectedElement;
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Файл сохранен", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }

            try
            {
                var imagesPdf = new PicToPDF();
                imagesPdf.GenPdf(
                    new ImagesPdfInfo
                    {
                        FileName = fileName,
                        Title = "Pdf with images",
                        Images = new string[]
                        {
                        "C:\\Users\\tsukanova\\work\\QzO4NwvITPI.png",
                        "C:\\Users\\tsukanova\\work\\B-Eqsi4wyXY.png"
                        }
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Файл сохранен", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }

            try
            {
                var tablePdf = new TableToPDF();
                tablePdf.GenPdf(
                    new TablePdfInfo<Human>
                    {
                        FileName = fileName,
                        Title = "Pdf with table",
                        MergeCellsDown = new Dictionary<(int, int), int> { [(1, 0)] = 1 },
                        RowsHeights = new int[] { 20, 20, 20 },
                        ColumnWidth = new int[] { 40, 40, 100, 100, 100 },
                        HeaderNames = new List<string>[2] { new List<string> { "names ->", "info", "" }, new List<string> { "", "status", "age" } },
                        Values = new Human[] {
                            new Human{ Name = "Ксюша", Status = "good", Age = 20},
                            new Human{ Name = "Света", Status = "well", Age = 20},
                            new Human{ Name = "Тимофейкин", Status = "тундра", Age = 21} }
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonChart_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Файл сохранен", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }

            try
            {
                var h1 = new Human { Name = "Ксюша", Status = "good", Age = 20 };
                var h2 = new Human { Name = "Света", Status = "well", Age = 20 };
                var h3 = new Human { Name = "Тимофейкин", Status = "тундра", Age = 21 };
                var chartPdf = new DiagramToPDF();
                chartPdf.GenPdf(
                    new ChartPdfInfo
                    {
                        FileName = fileName,
                        Title = "Pdf with chart",
                        ChartTitle = "Человеки",
                        LegendPosition = LegendPosition.Bottom,
                        Data = new List<ChartData>
                        {
                        new ChartData{SeriesName = h1.Name, Value = h1.Age },
                        new ChartData{SeriesName = h2.Name, Value = h2.Age },
                        new ChartData{SeriesName = h3.Name, Value = h3.Age },
                        }
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            LoadData();   
        }

        public void LoadData()
        {
            myTree2.SetConfig(new List<string>() { "Ganre", "PriceToString", "Id", "Title" });
            myTree2.CreateTree(new BookViewModel { Id = 1, Title = "q", Description = "qwe", Ganre = "G1", Price = 456 });
            myTree2.CreateTree(new BookViewModel { Id = 2, Title = "w", Description = "qwe", Ganre = "G2", Price = null });
            myTree2.CreateTree(new BookViewModel { Id = 3, Title = "e", Description = "qwe", Ganre = "G1", Price = null });
            myTree2.CreateTree(new BookViewModel { Id = 4, Title = "r", Description = "qwe", Ganre = "G1", Price = 567 });
            myTree2.CreateTree(new BookViewModel { Id = 5, Title = "t", Description = "qwe", Ganre = "G2", Price = 88 });
            myTree2.CreateTree(new BookViewModel { Id = 6, Title = "y", Description = "qwe", Ganre = "G2", Price = null });
            myTree2.CreateTree(new BookViewModel { Id = 7, Title = "u", Description = "qwe", Ganre = "G1", Price = null });
            myTree2.CreateTree(new BookViewModel { Id = 8, Title = "i", Description = "qwe", Ganre = "G2", Price = 86 });
        }
    }
}
