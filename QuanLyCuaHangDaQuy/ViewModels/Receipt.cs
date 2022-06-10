using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Receipt : BaseViewModel
    {
        public static ICommand DeleteCommand { get; set; }
        public static ICommand EditCommand { get; set; }
        private int _no;
        public int No
        {
            get { return _no; }
            set { _no = value; OnPropertyChanged(nameof(No)); }
        }
        private string _iD;
        public string ID
        {
            get { return _iD; }
            set { _iD = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _idCustomer;
        public string IDCustomer
        {
            get { return _idCustomer; }
            set { _idCustomer = value; OnPropertyChanged(nameof(IDCustomer)); }
        }
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }
        private DateTime _dateBooking;
        public DateTime DateBooking
        {
            get { return _dateBooking; }
            set { _dateBooking = value; OnPropertyChanged(nameof(DateBooking)); }
        }
        private string _stt;

        public string Stt
        {
            get { return _stt; }
            set { _stt = value; OnPropertyChanged(nameof(Stt)); }

        }
        private string _colorstt;

        public string ColorStt
        {
            get { return _colorstt; }
            set { _colorstt = value; OnPropertyChanged(nameof(ColorStt)); }

        }
        private string _dateBooking_format;

        public string DateBooking_format
        {
            get { return _dateBooking_format; }
            set { _dateBooking_format = value; OnPropertyChanged(nameof(DateBooking_format)); }
        }
    }
}
