using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class ImportedItem:BaseViewModel
    {
   
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }

        private string _nameitem;
        public string NameItem
        {
            get { return _nameitem; }
            set { _nameitem = value; OnPropertyChanged(nameof(NameItem)); }
        }
        private string _idprod;
        public string IDprod
        {
            get { return _idprod; }
            set { _idprod = value; OnPropertyChanged(nameof(IDprod)); }
        }

        private string _idorgitem;
        public string IDOrgItem
        {
            get { return _idorgitem; }
            set { _idorgitem = value; OnPropertyChanged(nameof(IDOrgItem)); }
        }
        private double _purchaseprice;
        public double PurchasePrice
        {
            get { return _purchaseprice; }
            set { _purchaseprice = value; OnPropertyChanged(nameof(PurchasePrice)); }
        }

        private string _nameprod;
        public string NameProd
        {
            get { return _nameprod; }
            set { _nameprod = value; OnPropertyChanged(nameof(NameProd)); }
        }

        private int? _quantity;
        public int? Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        private int? _total;
        public int? Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }

        private string _datepurchase;
        public string DatePurchase
        {
            get { return _datepurchase; }
            set { _datepurchase = value; OnPropertyChanged(nameof(DatePurchase)); }
        }
        private string _iditembillform;
        public string IDItemBillForm
        {
            get { return _iditembillform; }
            set { _iditembillform = value; OnPropertyChanged(nameof(IDItemBillForm)); }
        }
    }
}
