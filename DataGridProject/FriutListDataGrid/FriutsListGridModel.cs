using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataGridProject.FriutListDataGrid
{
    /// <summary>
    /// フルーツリストグリッドモデル
    /// </summary>
    /// <remarks>MainWindow.xaml→Grid_FruitsList と対応</remarks>
    public class FriutsListGridModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// 名称ヘッダー
        /// </summary>
        public string _nameHeader { get; set; }

        /// <summary>
        /// 色ヘッダー
        /// </summary>
        public string _colorHeader { get; set; }

        /// <summary>
        /// 価格ヘッダー
        /// </summary>
        public string _priceHeader { get; set; }

        /// <summary>
        /// フルーツデータグリッド列モデル一覧
        /// </summary>
        public ObservableCollection<FriutsDataGridColumnModel> _friutsModelList { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FriutsListGridModel()
        {
            _nameHeader = "";
            _colorHeader = "";
            _priceHeader = "";
            _friutsModelList = new ObservableCollection<FriutsDataGridColumnModel>();
        }

        /// <summary>
        /// ヘッダーを設定する
        /// </summary>
        /// <param name="headerProperty">ヘッダープロパティ</param>
        /// <param name="headerName">ヘッダー名</param>
        public void SetHeaderName(string headerProperty, string headerName)
        {
            var property = typeof(FriutsListGridModel).GetProperty(headerProperty);
            property?.SetValue(this, headerName);
            NotifyPropertyChanged(headerProperty);
        }

        /// <summary>
        /// フルーツデータグリッド列モデル一覧を設定する
        /// </summary>
        /// <param name="_friutsModelList"></param>
        public void SetFriutsDataGridColumnModelList(ObservableCollection<FriutsDataGridColumnModel> _friutsModelList)
        {
            this._friutsModelList = _friutsModelList;
            NotifyPropertyChanged(nameof(FriutsListGridModel._friutsModelList));
        }

        /// <summary>
        /// 降順にソートする
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        public void SortByDescending( string sortMemberPath)
        {
            _friutsModelList = new ObservableCollection<FriutsDataGridColumnModel>(
                _friutsModelList.OrderByDescending(c => typeof(FriutsDataGridColumnModel).GetProperty(sortMemberPath)?.GetValue(c))
                );
            NotifyPropertyChanged(nameof(FriutsListGridModel._friutsModelList));
        }

        /// <summary>
        /// 昇順にソートする
        /// </summary>
        /// <param name="sortMemberPath">ソートメンバーパス</param>
        public void SortByAscending(string sortMemberPath)
        {
            _friutsModelList = new ObservableCollection<FriutsDataGridColumnModel>(
                _friutsModelList.OrderBy(c => typeof(FriutsDataGridColumnModel).GetProperty(sortMemberPath)?.GetValue(c))
                );
            NotifyPropertyChanged(nameof(FriutsListGridModel._friutsModelList));
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}

