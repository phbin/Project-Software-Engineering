using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class CartBill : BaseViewModel
    {
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
        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged(nameof(Category)); }
        }
        private string _product;
        public string Product
        {
            get { return _product; }
            set { _product = value; OnPropertyChanged(nameof(Product)); }
        }
        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; OnPropertyChanged(nameof(Unit)); }
        }
        private string _unitPrice;
        public string UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; OnPropertyChanged(nameof(UnitPrice)); }
        }
        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(nameof(Amount)); }
        }
        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

    }
    public class CheckOutBillVM:BaseViewModel
    {
        private string _today;
        public string Today
        {
            get { return _today; }
            set { _today = value; OnPropertyChanged(nameof(Today)); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        private string _adress;
        public string Adress
        {
            get { return _adress; }
            set { _adress = value; OnPropertyChanged(nameof(Adress)); }
        }
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        public ObservableCollection<CartBill> ListCartBill { get; set; } = new ObservableCollection<CartBill>();
        public ICommand LoadCommand { get; set; }
        public CheckOutBillVM()
        {
            LoadCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                 var List = DataProvider.Ins.DB.CARTS.ToList();
                 int no = 1;
                 bool Flag = false;
                 int Temp = 0;
                 while (Flag == false)
                 {
                     Temp++;
                     if (DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.ID == "IB" + (Temp).ToString()).FirstOrDefault() == null)
                     {
                         Flag = true;

                     }
                 }
                 Today = "Date: " + DateTime.Now.ToString("MM/dd/yyyy");
                 ID = "Receipt #IB" + (Temp).ToString();
                 foreach (var item in List)
                 {
                     var DatTen = new CartBill
                     {
                         No = no,
                         ID = item.ID,
                         Quantity = item.Quantity.ToString(),
                         Product = item.ORIGINALITEM.NameItem,
                         Category = item.ORIGINALITEM.MATERIALCATEGORY.NameMaterial,
                         Unit = item.ORIGINALITEM.MATERIALCATEGORY.UNIT.NameUnit,
                         UnitPrice = item.ORIGINALITEM.Price.ToString(),
                         Amount = (item.Quantity * item.ORIGINALITEM.Price).ToString()

                         //UnitPrice = (DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDOrgItem).FirstOrDefault().PurchasePrice != 0) ? (string.Format("{0:0,0đ}", DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDOrgItem).FirstOrDefault().PurchasePrice)) : ("0đ"),
                         //Amount = ((item.Quantity * DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDOrgItem).FirstOrDefault().PurchasePrice) != 0) ? (string.Format("{0:0,0đ}", (item.Quantity * DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDOrgItem).FirstOrDefault().PurchasePrice))) : ("0đ")
                     };
                     ListCartBill.Add(DatTen);
                     no++;
                 }
             }
         );
        }
    }
}
