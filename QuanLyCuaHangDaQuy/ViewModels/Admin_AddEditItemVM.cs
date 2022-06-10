using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class Admin_AddEditItemVM : BaseViewModel
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
        public static ICommand CreateCommand { get; set; }
        public static ICommand UpdateCommand { get; set; }
        public Admin_AddEditItemVM()
        {
            CreateCommand = new RelayCommand<object>((p) => true, (p) => ImportItem());
            UpdateCommand = new RelayCommand<object>((p) => true, (p) => UpdateItem());
        }

        private void UpdateItem()
        {
           
        }

        private void ImportItem()
        {
            if (NameItem == null || NameProd == null || Quantity == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
            if (DatePurchase == null)
            {
                DatePurchase = DateTime.Now.ToShortDateString();
            }

            bool Flag = false;
            int Temp = 0;
            bool flag = false;
            int temp = 0;
            while (Flag == false)
            {
                Temp++;
                if (DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == "SP" + (Temp).ToString()).FirstOrDefault() == null)
                {
                    Flag = true;

                }
            }
            while (flag == false)
            {
                temp++;
                if (DataProvider.Ins.DB.ITEMBILLs.ToList().Where(h => h.ID == "IB" + (temp).ToString()).FirstOrDefault() == null)
                {
                    flag = true;

                }
            }
            var idProd = DataProvider.Ins.DB.INFOPROVIDERs.Where(x => x.NameProd == NameProd).FirstOrDefault().ID;
            var idOrgItem = DataProvider.Ins.DB.ORIGINALITEMs.Where(x => x.NameItem == NameItem).FirstOrDefault().ID;

            var idMaterial = DataProvider.Ins.DB.ORIGINALITEMs.Where(x => x.ID == idOrgItem).FirstOrDefault().IDMaterial;
            var profit = DataProvider.Ins.DB.MATERIALCATEGORies.Where(x => x.ID == idMaterial).FirstOrDefault().Profit;
            MessageBox.Show("" + profit);

            DataProvider.Ins.DB.IMPORTEDITEMS.Add(new IMPORTEDITEM { ID = "SP" + (Temp).ToString(), IDProd = idProd, IDOrgItem = idOrgItem, Quantity = Quantity, Total = Quantity*PurchasePrice, PurchasePrice = PurchasePrice, DatePurchase = DateTime.Parse(DatePurchase, CultureInfo.InvariantCulture) });
            DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == idOrgItem).FirstOrDefault().Price = PurchasePrice + (PurchasePrice * profit);

            DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == idOrgItem).FirstOrDefault().Price = PurchasePrice+(PurchasePrice* profit);
            DataProvider.Ins.DB.ITEMBILLs.Add(new ITEMBILL { ID = "IB" + (temp).ToString(), IDItemBillForm= IDItemBillForm,IDItem= "SP" + (Temp).ToString() });

            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
