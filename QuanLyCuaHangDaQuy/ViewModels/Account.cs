using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class Account:BaseViewModel
    {
        public static ICommand DeleteCommand { get; set; }
        public static ICommand EditCommand { get; set; }

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _fullname;
        public string Fullname { get { return _fullname; } set { _fullname = value; OnPropertyChanged(nameof(Fullname)); } }

        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(Username)); } }

        private string _pass;
        public string Pass { get { return _pass; } set { _pass = value; OnPropertyChanged(nameof(Pass)); } }

        private string _acctype;
        public string AccType { get { return _acctype; } set { _acctype = value; OnPropertyChanged(nameof(AccType)); } }
    }
}
