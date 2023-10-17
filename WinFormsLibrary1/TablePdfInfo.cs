namespace WinFormsLibrary1
{
    public class TablePdfInfo<T>
    {
        public string Title { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public Dictionary<(int, int), int>? MergeCellsDown;
        public int[]? RowsHeights;
        public int[]? ColumnWidth;
        public List<string>[]? HeaderNames;
        public T[]? Values;
    }
}
