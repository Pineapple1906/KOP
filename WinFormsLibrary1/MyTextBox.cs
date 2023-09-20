namespace WinFormsLibrary1
{
    public partial class MyTextBox : UserControl
    {
        public int? startRange = 1;
        public int? endRange = 1;

        private event EventHandler TextChange;
        public MyTextBox()
        {
            InitializeComponent();
            textBox1.TextChanged += (sender, e) => TextChange?.Invoke(sender, e);
            startRange = 0;
            endRange = 0;
        }
        public string Txt //пуб свойство для установки и получения введённого значения
        {
            get
            {
                if (startRange == -1 && endRange == -1)
                    throw new TemplateException("Не задано начальное или конечное значение диапазона");

                if (IsCorrect())
                {
                    return textBox1.Text;
                }
                else
                {
                    throw new TemplateException("Длина не входит в диапазон допустимых значений");
                }

            }
            set
            {
                if (startRange == -1 && endRange == -1)
                    throw new TemplateException("Не задано начальное или конечное значение диапазона");

                if (!IsCorrect()) textBox1.Text = value;

            }
        }

        private bool IsCorrect()
        {
            return textBox1.Text.Length >= StartRange && textBox1.Text.Length <= EndRange;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int StartRange
        {

            get
            {
                if (startRange <= -1)
                {
                    MessageBox.Show("StartRange не определен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
                else
                    return (int)startRange;
            }
            set
            {
                startRange = value;
            }
        }
        public int EndRange
        {
            get
            {
                if (endRange <= -1)
                {
                    MessageBox.Show("EndRange не определен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
                else
                {
                    return (int)endRange;
                }
            }
            set
            {
                endRange = value;
            }
        }
    }
}
