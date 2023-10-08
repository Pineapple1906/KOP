using System.Text.RegularExpressions;

namespace WinFormsLibrary1
{
    public partial class MyTextBox : UserControl
    {
        public int StartRange { get; set; } = -1;
        public int EndRange { get; set; } = -1;

        private event EventHandler TextChange;
        public MyTextBox()
        {
            InitializeComponent();
            textBox1.TextChanged += (sender, e) => TextChange?.Invoke(sender, e);
        }

        public string Error
        {
            get; private set;
        }

        public string Txt //пуб свойство для установки и получения введённого значения
        {
            get
            {
                if (StartRange == -1 && EndRange == -1)
                {
                    Error = "Не задано начальное или конечное значение диапазона";
                    return null;
                }

                if (IsCorrect(textBox1.Text))
                {
                    return textBox1.Text;
                }
                else
                {
                    Error = "Длина не входит в диапазон допустимых значений";
                    return null;
                }
            }
            set
            {
                if (StartRange == -1 && EndRange == -1)
                    Error = "Неверно задано начальное или конечное значение диапазона";

                else if (IsCorrect(value)) textBox1.Text = value;
            }
        }

        private bool IsCorrect(string s)
        {
            return s.Length >= StartRange && s.Length <= EndRange;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
