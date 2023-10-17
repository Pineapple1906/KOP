

namespace WinFormsLibrary1
{
    public class ChartPdfInfo
    {
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ChartTitle { get; set; } = string.Empty;
        public LegendPosition LegendPosition { get; set; } = LegendPosition.Bottom;
        public List<ChartData>? Data { get; set; }
    }
}