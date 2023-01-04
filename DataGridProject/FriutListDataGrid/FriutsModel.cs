using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridProject.FriutListDataGrid
{
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
