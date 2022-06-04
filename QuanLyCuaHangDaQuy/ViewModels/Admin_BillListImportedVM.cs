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
    public class BillItemImport : BaseViewModel
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
    public class Admin_BillListImportedVM : BaseViewModel
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
        public ObservableCollection<BillItemImport> BillListItemImport { get; set; } = new ObservableCollection<BillItemImport>();
        public ICommand LoadCommand { get; set; }
        public Admin_BillListImportedVM()
        {
            LoadCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                 var List = DataProvider.Ins.DB.ITEMBILLs.ToList().Where(h => h.IDItemBillForm == Admin_ListReceiptVM.IdReceipt);
                 int no = 1;
                 Today = "Date: " + DateTime.Now.ToString("MM/dd/yyyy");
                 ID = "Receipt #" + Admin_ListReceiptVM.IdReceipt;
                 string idp = DataProvider.Ins.DB.ITEMBILLFORMs.ToList().Where(h => h.ID == Admin_ListReceiptVM.IdReceipt).FirstOrDefault().IDProd;
                 Name = DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == idp).FirstOrDefault().NameProd;
                 Phone = DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == idp).FirstOrDefault().Phone;
                 Adress = DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == idp).FirstOrDefault().Addr;
                 foreach (var item in List)
                 {
                     var DatTen = new BillItemImport
                     {
                         No = no,
                         ID = item.ID,
                         Quantity = item.Quantity.ToString(),
                         Product = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().NameItem,
                         Category = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(h => h.ID == DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(a => a.ID == item.IDItem).FirstOrDefault().IDForm).FirstOrDefault().NameForm,
                         UnitPrice = (DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice != 0) ? (string.Format("{0:0,0đ}", DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice)) : ("0đ"),
                         Amount = ((item.Quantity * DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice) != 0) ? (string.Format("{0:0,0đ}", (item.Quantity * DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice))) : ("0đ"),
                         Unit = DataProvider.Ins.DB.UNITs.ToList().Where(b => b.ID == DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(a => a.ID == DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().IDMaterial).FirstOrDefault().IDUnit).FirstOrDefault().NameUnit,
                     };
                     BillListItemImport.Add(DatTen);
                     no++;
                 }
             }
         );
        }

    }
}
