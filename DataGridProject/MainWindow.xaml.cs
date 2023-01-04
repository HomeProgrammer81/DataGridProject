using DataGridProject.FriutListDataGrid;
using DataGridProject.HeaderName;
using DataGridProject.ViewModel;
using System.Collections.Generic;
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
        private HeaderNames HeaderNames = new HeaderNames(
            new List<HeaderNameObj>()
            {
                new HeaderNameObj("名前", "名前▲", "名前▼", "_name"),
                new HeaderNameObj("色", "色▲", "色▼", "_color"),
                new HeaderNameObj("価格", "価格▲", "価格▼", "_price")
            });

        private List<FriutViewModel> FriutViewModelList = new List<FriutViewModel>()
        {
            new FriutViewModel("りんご", "赤", 148),
            new FriutViewModel("みかん", "オレンジ", 130),
            new FriutViewModel("キウイ", "緑", 136),
            new FriutViewModel("ぶどう", "赤", 540),
            new FriutViewModel("かき", "オレンジ", 120),
            new FriutViewModel("ばなな", "黄", 108),
        };

        private FriutListDataGridDesigner friutListDataGridDesigner;

        public MainWindow()
        {
            InitializeComponent();

            friutListDataGridDesigner = new FriutListDataGridDesigner(Grid_FruitsList, HeaderNames);
            friutListDataGridDesigner.Draw(FriutViewModelList);
        }

        /// <summary>
        /// ヘッダーがクリックされたとき呼び出し
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;

            string sortMemberPath = e.Column.SortMemberPath;

            friutListDataGridDesigner.Sort(sortMemberPath);
        }
    }
}
