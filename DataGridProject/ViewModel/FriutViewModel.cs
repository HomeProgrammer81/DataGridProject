namespace DataGridProject.ViewModel
{
    internal class FriutViewModel
    {
        public string name { get; }

        public string color { get; }

        public int price { get; }

        public FriutViewModel(string name, string color, int price)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }
    }
}
