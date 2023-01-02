using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DataGridProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<FriutsModel> FriutsList = new ObservableCollection<FriutsModel>()
        {
            new FriutsModel("りんご", "赤", 148),
            new FriutsModel("みかん", "オレンジ", 130),
            new FriutsModel("キウイ", "緑", 136),
            new FriutsModel("ぶどう", "赤", 540),
            new FriutsModel("かき", "オレンジ", 120),
            new FriutsModel("ばなな", "黄", 108),
        };

        public MainWindow()
        {
            InitializeComponent();

            DataGrid_FruitsList.ItemsSource = new ObservableCollection<FriutsModel>();
            DataGrid_FruitsList.ItemsSource = FriutsList;
        }

        private void DataGrid_FruitsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // _isSelectedがtrueのものが選択中
            FriutsModel? model = FriutsList.FirstOrDefault(obj => obj._isSelected);
            if (model == null)
            {
                return;
            }

            TextBox_Name.Text = model._name;
            TextBox_Color.Text = model._color;
            TextBox_Price.Text = model._price.ToString();
        }

        private void Click_EditButton(object sender, RoutedEventArgs e)
        {

        }
    }

    public class FriutsModel
    {
        // 選択状態を追加
        public bool _isSelected { get; set; }

        public string _name { get; set; }

        public string _color { get; set; }

        public int _price { get; set; }

        public FriutsModel(string _name, string _color, int _price)
        {
            _isSelected = false;
            this._name = _name;
            this._color = _color;
            this._price = _price;
        }
    }
}
