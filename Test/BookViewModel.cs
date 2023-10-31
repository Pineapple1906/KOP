using System.ComponentModel;

namespace WinFormsLibrary1
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Ganre { get; set; } = string.Empty;
        public int? Price { get; set; }
        public string PriceToString
        {
            set
            {
            }
            get
            {
                if (Price == null) return "Бесплатная";
                else return Price.ToString();
            }
        }

    }
}
