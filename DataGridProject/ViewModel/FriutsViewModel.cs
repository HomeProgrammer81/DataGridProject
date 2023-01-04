namespace DataGridProject.ViewModel
{
    /// <summary>
    /// フルーツ表示モデル
    /// </summary>
    internal class FriutsViewModel
    {
        public string name { get; }

        public string color { get; }

        public int price { get; }

        public FriutsViewModel(string name, string color, int price)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }
    }
}
