namespace DataGridProject.FriutListDataGrid
{
    /// <summary>
    /// フルーツデータグリッド列モデル
    /// </summary>
    /// <remarks>MainWindow.xaml→DataGrid.Columns のColumn要素と対応</remarks>
    public class FriutsDataGridColumnModel
    {
        /// <summary>
        /// 選択状態
        /// </summary>
        public bool _isSelected { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string _name { get; set; }

        /// <summary>
        /// 色
        /// </summary>
        public string _color { get; set; }

        /// <summary>
        /// 価格
        /// </summary>
        public int _price { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_name">名称</param>
        /// <param name="_color">色</param>
        /// <param name="_price">価格</param>
        public FriutsDataGridColumnModel(string _name, string _color, int _price)
        {
            _isSelected = false;
            this._name = _name;
            this._color = _color;
            this._price = _price;
        }
    }
}
