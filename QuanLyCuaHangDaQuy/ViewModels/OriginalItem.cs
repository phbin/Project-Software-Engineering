using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class OriginalItem:BaseViewModel
    {
        public static ICommand EditCommand { get; set; }

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameitem;
        public string NameItem { get { return _nameitem; } set { _nameitem = value; OnPropertyChanged(nameof(NameItem)); } }

        private string _idform;
        public string IDForm { get { return _idform; } set { _idform = value; OnPropertyChanged(nameof(IDForm)); } }

        private string _idmaterial;
        public string IDMaterial { get { return _idmaterial; } set { _idmaterial = value; OnPropertyChanged(nameof(IDMaterial)); } }

        private string _nameform;
        public string NameForm { get { return _nameform; } set { _nameform = value; OnPropertyChanged(nameof(NameForm)); } }

        private string _namematerial;
        public string NameMaterial { get { return _namematerial; } set { _namematerial = value; OnPropertyChanged(nameof(NameMaterial)); } }

        private int? _quantity;
        public int? Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }

        private int? _sellqty;
        public int? SellQty { get { return _sellqty; } set { _sellqty = value; OnPropertyChanged(nameof(SellQty)); } }

        private double? _price;
        public double? Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }

        private string _descript;
        public string Descript { get { return _descript; } set { _descript = value; OnPropertyChanged(nameof(Descript)); } }

        private byte[] _picture;
        public byte[] Picture { get { return _picture; } set { _picture = value; OnPropertyChanged(nameof(Picture)); } }
    }
}
