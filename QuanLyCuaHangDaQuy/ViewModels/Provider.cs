using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;


namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class Provider:BaseViewModel
    {
        public static ICommand DeleteCommand { get; set; }
        public static ICommand EditCommand { get; set; }

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameProd;
        public string NameProd { get { return _nameProd; } set { _nameProd = value; OnPropertyChanged(nameof(NameProd)); } }

        private string _addr;
        public string Addr { get { return _addr; } set { _addr = value; OnPropertyChanged(nameof(Addr)); } }

        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(nameof(Phone)); } }
        public Nullable<int> stt { get; set; }
    }
}
