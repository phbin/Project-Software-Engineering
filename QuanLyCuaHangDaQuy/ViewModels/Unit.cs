using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class Unit:BaseViewModel
    {
        public static ICommand EditCommand { get; set; }

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameunit;
        public string NameUnit { get { return _nameunit; } set { _nameunit = value; OnPropertyChanged(nameof(NameUnit)); } }

    }
}
