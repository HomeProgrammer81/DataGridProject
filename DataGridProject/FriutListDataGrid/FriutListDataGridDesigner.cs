using DataGridProject.HeaderName;
using DataGridProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataGridProject.FriutListDataGrid
{
    /// <summary>
    /// フルーツリストデータグリッドデザイナー
    /// </summary>
    internal class FriutListDataGridDesigner
    {
        private readonly Grid grid;

        private HeaderNames headerNames;

        public FriutsListGridModel friutsListGridModels { get; set; }

        private string sortMemberPath;

        private ListSortDirection? sortDirection;

        public FriutListDataGridDesigner(Grid grid, HeaderNames headerNames)
        {
            this.grid = grid;
            this.headerNames = headerNames;

            friutsListGridModels = new FriutsListGridModel();

            sortMemberPath = "";

            grid.DataContext = friutsListGridModels;

            sortDirection = null;
        }

        public void Draw(List<FriutViewModel> friutViewModels)
        {
            ObservableCollection<FriutsModel> friutsListModelList = new ObservableCollection<FriutsModel>();
            foreach( var model in friutViewModels)
            {
                FriutsModel friutsModel = new FriutsModel(model.name, model.color, model.price);
                friutsListModelList.Add(friutsModel);
            }

            /*
            friutsModels = new FriutsListModel(
                headerNames.SearchNormalName("_nameHeader"),
                headerNames.SearchNormalName("_colorHeader"),
                headerNames.SearchAscendingName("_priceHeader"),
                friutsListModelList);
            */

            string nameHeader = headerNames.SearchNormalName("_name");
            friutsListGridModels._nameHeader = nameHeader;
            friutsListGridModels.NotifyPropertyChanged("_nameHeader");

            //friutsModels.SetHeaderName("_nameHeader", nameHeader);
            //friutsModels.NotifyPropertyChanged("_nameHeader");

            string colorHeader = headerNames.SearchNormalName("_color");
            friutsListGridModels._colorHeader = colorHeader;
            friutsListGridModels.NotifyPropertyChanged("_colorHeader");
            //friutsModels.SetHeaderName("_colorHeader", colorHeader);
            //friutsModels.NotifyPropertyChanged("_colorHeader");

            string priceHeader = headerNames.SearchNormalName("_price");
            friutsListGridModels._priceHeader = priceHeader;
            friutsListGridModels.NotifyPropertyChanged("_priceHeader");
            //friutsModels.SetHeaderName("_priceHeader", priceHeader);
            //friutsModels.NotifyPropertyChanged("_priceHeader");

            friutsListGridModels._friutsModelList = friutsListModelList;
            friutsListGridModels.NotifyPropertyChanged("_friutsModelList");



            // ソート実行する
            // 前回のパスが存在しないなら終了
            if (!headerNames.ExistPropertyName(sortMemberPath))
            {
                friutsListGridModels.NotifyPropertyChanged("friutsModelList");
                return;
            }

            // 昇順でない → 降順
            if (ListSortDirection.Ascending != sortDirection)
            {
                friutsListGridModels.SortByDescending(sortMemberPath);
                friutsListGridModels.NotifyPropertyChanged("friutsModelList");

                string sortDescendingName = headerNames.SearchDescendingName(sortMemberPath);
                friutsListGridModels.SetHeaderName(sortMemberPath, sortDescendingName);
                friutsListGridModels.NotifyPropertyChanged(sortMemberPath);
                return;
            }

            // 降順 → 昇順
            friutsListGridModels.SortBy(sortMemberPath);
            friutsListGridModels.NotifyPropertyChanged("friutsModelList");


            string sortAscendingName = headerNames.SearchAscendingName(sortMemberPath);
            friutsListGridModels.SetHeaderName(sortMemberPath, sortAscendingName);
            friutsListGridModels.NotifyPropertyChanged(sortMemberPath);
            return;
        }

        public void Sort(string sortMemberPath)
        {
            string beforeSortMemberPath = this.sortMemberPath;

            // 前回と違う名前のヘッダー
            if ( !this.sortMemberPath.Equals(sortMemberPath))
            {
                // 昇順に変更
                friutsListGridModels.SortBy(sortMemberPath);
                friutsListGridModels.NotifyPropertyChanged("friutsModelList");

                // パス変更
                this.sortMemberPath = sortMemberPath;
                sortDirection = ListSortDirection.Ascending;

                // 新規のヘッダー名称変更
                string sortAscendingName = headerNames.SearchAscendingName(sortMemberPath);
                friutsListGridModels.SetHeaderName(sortMemberPath, sortAscendingName);
                friutsListGridModels.NotifyPropertyChanged(sortMemberPath);

                if( !headerNames.ExistPropertyName(beforeSortMemberPath))
                {
                    return;
                }

                // 前回のヘッダー名称変更
                string sortNormalNameBef = headerNames.SearchNormalName(beforeSortMemberPath);
                friutsListGridModels.SetHeaderName(beforeSortMemberPath, sortNormalNameBef);

                return;
            }

            // 同じ名前のヘッダー 昇順でない → 昇順にする
            if (ListSortDirection.Ascending != sortDirection)
            {
                // 昇順に変更
                friutsListGridModels.SortBy(sortMemberPath);
                friutsListGridModels.NotifyPropertyChanged("friutsModelList");

                // パス変更
                this.sortMemberPath = sortMemberPath;
                sortDirection = ListSortDirection.Ascending;

                string sortAscendingName = headerNames.SearchAscendingName(sortMemberPath);
                friutsListGridModels.SetHeaderName(sortMemberPath, sortAscendingName);
                friutsListGridModels.NotifyPropertyChanged(sortMemberPath);

                return;
            }

            // 同じ名前のヘッダー昇順 → 降順にする

            // 降順に変更
            friutsListGridModels.SortByDescending(sortMemberPath);
            friutsListGridModels.NotifyPropertyChanged("friutsModelList");

            // パス変更
            this.sortMemberPath = sortMemberPath;
            sortDirection = ListSortDirection.Descending;

            string sortDescendingName = headerNames.SearchDescendingName(sortMemberPath);
            friutsListGridModels.SetHeaderName(sortMemberPath, sortDescendingName);
            friutsListGridModels.NotifyPropertyChanged(sortMemberPath);

        }
    }
}
