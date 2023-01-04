using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataGridProject.FriutListDataGrid
{
    public class FriutsListGridModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string _nameHeader { get; set; }

        public string _colorHeader { get; set; }

        public string _priceHeader { get; set; }

        public ObservableCollection<FriutsModel> _friutsModelList { get; set; }

        public FriutsListGridModel()
        {
            _nameHeader = "";
            _colorHeader = "";
            _priceHeader = "";
            _friutsModelList = new ObservableCollection<FriutsModel>();
        }

        public FriutsListGridModel(string nameHeader, string colorHeader, string priceHeader, ObservableCollection<FriutsModel> friutsModels)
        {
            this._nameHeader = nameHeader;
            this._colorHeader = colorHeader;
            this._priceHeader = priceHeader;
            this._friutsModelList = friutsModels;
        }

        public void SetHeaderName(string sortMemberPath, string headerName)
        {
            var property = typeof(FriutsModel).GetProperty(sortMemberPath);
            property?.SetValue(this, headerName);
        }


        public void SortByDescending( string sortMemberPath)
        {
            _friutsModelList.OrderByDescending(c => typeof(FriutsModel).GetProperty(sortMemberPath)?.GetValue(c));
        }

        public void SortBy(string sortMemberPath)
        {
            _friutsModelList.OrderBy(c => typeof(FriutsModel).GetProperty(sortMemberPath)?.GetValue(c));
        }

        public void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}

