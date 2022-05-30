using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class ItemImport : BaseViewModel
    {
        public static ICommand EditCommand { get; set; }
        public static ICommand DeleteCommand { get; set; }
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
    public class Admin_ListImportItemVM : BaseViewModel
    {
        public ObservableCollection<ItemImport> ListItemImport { get; set; } = new ObservableCollection<ItemImport>();
        public static string IDD;

        private ItemImport _selectedItemImport;
        public ItemImport SelectedItemImport
        {
            get { return _selectedItemImport; }
            set { _selectedItemImport = value; OnPropertyChanged(nameof(SelectedItemImport)); }
        }
        public void LoadData()
        {
            ListItemImport.Clear();
            var List = DataProvider.Ins.DB.ITEMBILLs.ToList().Where(h => h.IDItemBillForm == Admin_ListReceiptVM.IdReceipt);
            int no = 1;
            foreach (var item in List)
            {
                var DatTen = new ItemImport
                {
                    No = no,
                    ID = item.ID,
                    Quantity = item.Quantity.ToString(),
                    Product = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().NameItem,
                    Category = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(h => h.ID == DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(a => a.ID == item.IDItem).FirstOrDefault().IDForm).FirstOrDefault().NameForm,
                    UnitPrice = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice.ToString(),
                    Amount = (item.Quantity * DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice).ToString(),
                    Unit = DataProvider.Ins.DB.UNITs.ToList().Where(b => b.ID == DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(a => a.ID == DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().IDMaterial).FirstOrDefault().IDUnit).FirstOrDefault().NameUnit,
                };
                ListItemImport.Add(DatTen);
                no++;
            }

        }


        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public Admin_ListImportItemVM()
        {
            LoadCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    var List = DataProvider.Ins.DB.ITEMBILLs.ToList().Where(h => h.IDItemBillForm == Admin_ListReceiptVM.IdReceipt);
                    int no = 1;
                    foreach (var item in List)
                    {
                        var DatTen = new ItemImport
                        {
                            No = no,
                            ID = item.ID,
                            Quantity = item.Quantity.ToString(),
                            Product = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().NameItem,
                            Category = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(h => h.ID == DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(a => a.ID == item.IDItem).FirstOrDefault().IDForm).FirstOrDefault().NameForm,
                            UnitPrice = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice.ToString(),
                            Amount = (item.Quantity * DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().PurchasePrice).ToString(),
                            Unit = DataProvider.Ins.DB.UNITs.ToList().Where(b => b.ID == DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(a => a.ID == DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == item.IDItem).FirstOrDefault().IDMaterial).FirstOrDefault().IDUnit).FirstOrDefault().NameUnit,
                        };
                        ListItemImport.Add(DatTen);
                        no++;
                    }
                }
            );
            AddCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    Admin_AddImportItem admin_AddImportItem = new Admin_AddImportItem();
                    admin_AddImportItem.ShowDialog();
                    LoadData();
                }
            );
            ItemImport.EditCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   Admin_AddImportItem admin_AddImportItem = new Admin_AddImportItem();
                   admin_AddImportItem.ShowDialog();
                   LoadData();
               }
           );
            ItemImport.DeleteCommand = new RelayCommand<object>(
                           (p) => { return true; },
                           (p) =>
                           {
                               DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this item?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
                               if (result == System.Windows.Forms.DialogResult.Yes)
                               {
                                   DataProvider.Ins.DB.ITEMBILLs.Remove(DataProvider.Ins.DB.ITEMBILLs.ToList().Where(h => h.ID == SelectedItemImport.ID).FirstOrDefault());
                                   DataProvider.Ins.DB.SaveChanges();
                                   LoadData();
                               }
                           }
                       );
        }
    }
 }
