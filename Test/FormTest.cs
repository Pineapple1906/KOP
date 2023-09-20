using WinFormsLibrary1;

namespace Test
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
            myTree1.SetConfig(new List<string>() { "Name", "Description", "Col" });
            myTree1.CreateTree(new Test("qwre", "ASDSADADASDS", 123));
            myTree1.CreateTree(new Test("adsads", "ASDSADADsSADS", 2342));
            myTree1.CreateTree(new Test("qwrasdasde", "ASDSADADSASADS", 123234));
            myTree1.CreateTree(new Test("qwredasasdads", "ASDASDASDSADADS", 12376556));
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            myCheckedListBox1.AddItem(myTextBox1.Txt);

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            myCheckedListBox1.CleatItems();
        }

        private void buttonSelected_Click(object sender, EventArgs e)
        {
            label1.Text = myCheckedListBox1.SelectedElement;
        }

    }
}
