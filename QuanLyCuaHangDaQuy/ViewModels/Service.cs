using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Service :BaseViewModel
    {
        public static ICommand EditCommand { get; set; }
        public static ICommand DeleteCommand { get; set; }
        public static ICommand SttCommand { get; set; }
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private int _no;
        public int No
        {
            get { return _no; }
            set { _no = value; OnPropertyChanged(nameof(No)); }
        }
        private string _idService;
        public string IDService
        {
            get { return _idService; }
            set { _idService = value; OnPropertyChanged(nameof(IDService)); }
        }
        private string _nameService;
        public string NameService
        {
            get { return _nameService; }
            set { _nameService = value; OnPropertyChanged(nameof(NameService)); }
        }
        private string _idCusService;
        public string IDCusService
        {
            get { return _idCusService; }
            set { _idCusService = value; OnPropertyChanged(nameof(IDCusService)); }
        }
        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }
        private string _cost;
        public string Cost
        {
            get { return _cost; }
            set { _cost = value; OnPropertyChanged(nameof(Cost)); }
        }
        private string _priceDiscounted;
        public string PriceDiscounted
        {
            get { return _priceDiscounted; }
            set { _priceDiscounted = value; OnPropertyChanged(nameof(PriceDiscounted)); }
        }
        private string _total;
        public string Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }
        private string _prepay;
        public string Prepay
        {
            get { return _prepay; }
            set { _prepay = value; OnPropertyChanged(nameof(Prepay)); }
        }
        private string _remain;
        public string Remain
        {
            get { return _remain; }
            set { _remain = value; OnPropertyChanged(nameof(Remain)); }
        }
        private DateTime _dateReturn;
        public DateTime DateReturn
        {
            get { return _dateReturn; }
            set { _dateReturn = value; OnPropertyChanged(nameof(DateReturn)); }
        }
        private string _dateReturn_Format;
        public string DateReturn_Format
        {
            get { return _dateReturn_Format; }
            set { _dateReturn_Format = value; OnPropertyChanged(nameof(DateReturn_Format)); }

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
    }
}
