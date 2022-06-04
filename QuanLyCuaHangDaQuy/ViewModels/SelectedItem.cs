using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class SelectedItem
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
        public string NameItem { get; set; }
        public string IDItem { get; set; }
        public string NameMaterial { get; set; }
        public string NameForm { get; set; }
        public double? Total { get; set; }
        public int Quantity { get; set; }
        public BitmapImage Picture { get; set; }
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
