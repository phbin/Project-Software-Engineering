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
    public class Staff : BaseViewModel
    {
        public static ICommand DeleteCommand { get; set; }
        public static ICommand EditCommand { get; set; }

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _fullname;
        public string FullName { get { return _fullname; } set { _fullname = value; OnPropertyChanged(nameof(FullName)); } }

        private DateTime _dob;
        public DateTime DoB { get { return _dob; } set { _dob = value; OnPropertyChanged(nameof(DoB)); } }

        private string _dob_format;
        public string Dob_Format { get { return _dob_format; } set { _dob_format = value; OnPropertyChanged(nameof(Dob_Format)); } }

        private string _sex;
        public string Sex { get { return _sex; } set { _sex = value; OnPropertyChanged(nameof(Sex)); } }

        private string _addr;
        public string Addr { get { return _addr; } set { _addr = value; OnPropertyChanged(nameof(Addr)); } }

        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(nameof(Phone)); } }

        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(nameof(Email)); } }

        private long _idpersonal;
        public long IDPersonal { get { return _idpersonal; } set { _idpersonal = value; OnPropertyChanged(nameof(IDPersonal)); } }

        private byte[] _avatar;
        public byte[] Avatar
        {
            get { return _avatar; }
            set { _avatar = value; OnPropertyChanged(nameof(Avatar)); }
        }

    }

}
