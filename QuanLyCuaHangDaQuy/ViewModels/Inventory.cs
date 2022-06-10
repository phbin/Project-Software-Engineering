using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class Inventory:BaseViewModel
    {
        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }

        private string _opening;
        public string Opening { get { return _opening; } set { _opening = value; OnPropertyChanged(nameof(Opening)); } }

        private int? _qtypurchased;
        public int? QtyPurchased { get { return _qtypurchased; } set { _qtypurchased = value; OnPropertyChanged(nameof(QtyPurchased)); } }

        private int? _qtysold;
        public int? QtySold { get { return _qtysold; } set { _qtysold = value; OnPropertyChanged(nameof(QtySold)); } }

        private int? _closing;
        public int? Closing { get { return _closing; } set { _closing = value; OnPropertyChanged(nameof(Closing)); } }

        private string _unit;
        public string Unit { get { return _unit; } set { _unit = value; OnPropertyChanged(nameof(Unit)); } }

        private string _getdate;
        public string GetDate { get { return _getdate; } set { _getdate = value; OnPropertyChanged(nameof(GetDate)); } }
    }
}
