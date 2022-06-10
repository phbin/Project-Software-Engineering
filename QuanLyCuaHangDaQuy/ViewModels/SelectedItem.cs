using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class SelectedItem:BaseViewModel
    {
        //private string _id;
        //private string _iditem;
        //private int _quantity;
        //private string _nameitem;
        //private string _namematerial;
        //private BitmapImage _picture;
        //private string _nameform;
        //private double? _total;
        public static ICommand DeleteCommand { get; set; }
        public static ICommand PlusCommand { get; set; }
        public static ICommand MinusCommand { get; set; }
        private string _nameitem { get; set; }

        public string NameItem
        {
            get { return _nameitem; }
            set { _nameitem = value; OnPropertyChanged(nameof(NameItem)); }
        }
        private string _iditem { get; set; }

        public string IDItem
        {
            get { return _iditem; }
            set { _iditem = value; OnPropertyChanged(nameof(IDItem)); }
        }
        private string _namematerial { get; set; }

        public string NameMaterial
        {
            get { return _namematerial; }
            set { _namematerial = value; OnPropertyChanged(nameof(NameMaterial)); }
        }
        private string _nameform { get; set; }

        public string NameForm
        {
            get { return _nameform; }
            set { _nameform = value; OnPropertyChanged(nameof(NameForm)); }
        }
        private double? _total { get; set; }

        public double? Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }
        private int _quantity { get; set; }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }
        private BitmapImage _picture { get; set; }

        public BitmapImage Picture
        {
            get { return _picture; }
            set { _picture = value; OnPropertyChanged(nameof(Picture)); }
        }
        //public string NameItem { get; set; }
        //public string IDItem { get; set; }
        //public string NameMaterial { get; set; }
        //public string NameForm { get; set; }
        //public double? Total { get; set; }
        //public int Quantity { get; set; }
        //public BitmapImage Picture { get; set; }
        public SelectedItem(string nameitem, string iditem, string namematerial, string nameform, double? total, int qty, BitmapImage pic)
        {
            NameItem = nameitem;
            NameForm = nameform;
            NameMaterial = namematerial;
            IDItem = iditem;
            Total = total;
            Quantity = qty;
            Picture = pic;
        }

        public SelectedItem()
        {
        }
    }
}
