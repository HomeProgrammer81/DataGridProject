using DataGridProject.DataGridSort;
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
                new HeaderNameObj("_name", "_nameHeader",  "名前", "名前▲", "名前▼"),
                new HeaderNameObj("_color", "_colorHeader",  "色", "色▲", "色▼"),
                new HeaderNameObj("_price", "_priceHeader",  "価格", "価格▲", "価格▼")
            });

        private List<FriutsViewModel> FriutListViewModel = new List<FriutsViewModel>()
        {
            new FriutsViewModel("りんご", "赤", 148),
            new FriutsViewModel("みかん", "オレンジ", 130),
            new FriutsViewModel("キウイ", "緑", 136),
            new FriutsViewModel("ぶどう", "赤", 540),
            new FriutsViewModel("かき", "オレンジ", 120),
            new FriutsViewModel("ばなな", "黄", 108),
        };

        private DataGridSortDirector dataGridSortDirector;

        public FriutsListGridModel friutsListGridModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            friutsListGridModel = new FriutsListGridModel();

            Grid_FruitsList.DataContext = friutsListGridModel;

            HeaderNames.Loop(headerName =>
            {
                friutsListGridModel.SetHeaderName(headerName.headerProperty, headerName.normalName);
            });

            ObservableCollection<FriutsDataGridColumnModel> friutsListModelList = new ObservableCollection<FriutsDataGridColumnModel>();
            foreach (var model in FriutListViewModel)
            {
                FriutsDataGridColumnModel friutsModel = new FriutsDataGridColumnModel(model.name, model.color, model.price);
                friutsListModelList.Add(friutsModel);
            }

            friutsListGridModel.SetFriutsDataGridColumnModelList(friutsListModelList);

            dataGridSortDirector = new DataGridSortDirector(SortAscending, SortDescending, SortNormal);
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

            dataGridSortDirector.Sort(sortMemberPath);
        }

        /// <summary>
        /// 昇順にソートする
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        private void SortAscending( string sortMemberPath)
        {
            // 昇順にソート
            friutsListGridModel.SortByAscending(sortMemberPath);

            // ヘッダー名の変更
            HeaderNameObj? headerName = HeaderNames.GetHeaderName( sortMemberPath );
            if( headerName == null)
            {
                return;
            }
            friutsListGridModel.SetHeaderName(headerName.headerProperty, headerName.ascendingName);

        }

        /// <summary>
        /// 降順にソートする
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        private void SortDescending(string sortMemberPath)
        {
            // 降順にソート
            friutsListGridModel.SortByDescending(sortMemberPath);

            // ヘッダー名の変更
            HeaderNameObj? headerName = HeaderNames.GetHeaderName(sortMemberPath);
            if (headerName == null)
            {
                return;
            }
            friutsListGridModel.SetHeaderName(headerName.headerProperty, headerName.descendingName);
        }

        /// <summary>
        /// 通常にソートする
        /// </summary>
        /// <remarks>ソートはしない。ヘッダー名だけ変更</remarks>
        /// <param name="sortMemberPath"></param>
        private void SortNormal(string sortMemberPath)
        {
            // ヘッダー名の変更
            HeaderNameObj? headerNameBef = HeaderNames.GetHeaderName(sortMemberPath);
            if (headerNameBef == null)
            {
                return;
            }
            friutsListGridModel.SetHeaderName(headerNameBef.headerProperty, headerNameBef.normalName);
        }
    }
}
