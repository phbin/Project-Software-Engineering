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
    public class Add_Service : BaseViewModel
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
        private string _provider;
        public string Provider
        {
            get { return _provider; }
            set { _provider = value; OnPropertyChanged(nameof(Provider)); }
        }
        private string _idprovider;
        public string IDProvider
        {
            get { return _idprovider; }
            set { _idprovider = value; OnPropertyChanged(nameof(IDProvider)); }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
    }
    public class Admin_ListReceiptVM :BaseViewModel
    {
        public static string IDD;
        public ObservableCollection<Add_Service> ListReceipt { get; set; } = new ObservableCollection<Add_Service>();
        private Add_Service _selectedReceipt { get; set; }
        public Add_Service SelectedReceipt
        {
            get { return _selectedReceipt; }
            set { _selectedReceipt = value; OnPropertyChanged(nameof(SelectedReceipt)); }
        }
        private static string _idReceipt;
        public static string IdReceipt
        {
            get { return _idReceipt; }
            set { _idReceipt = value; }
        }
        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public void LoadData()
        {

            var List = DataProvider.Ins.DB.ITEMBILLFORMs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                var DatTen = new Add_Service
                {
                    No = no,
                    ID = item.ID,
                    IDProvider=item.IDProd,
                    Date=item.DateBooking.ToShortDateString(),
                    Provider=DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h=>h.ID==item.IDProd).FirstOrDefault().NameProd,
                };
                ListReceipt.Add(DatTen);
                no++;
            }
            if (no >= 2) { SelectedReceipt = ListReceipt[0]; }
        }
        public void LoadDataAfterTextSearch()

        {
            if (TextSearch == "" || TextSearch == null)
            {
                ListReceipt.Clear();
                LoadData();
            }
            else
            {
                ListReceipt.Clear();
                var List = DataProvider.Ins.DB.ITEMBILLFORMs.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    string FullName = DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == item.IDProd).FirstOrDefault().NameProd;
                    if (FullName.Contains(TextSearch))
                    {
                        ListReceipt.Add(new Add_Service
                        {
                            No = no,
                            ID = item.ID,
                            IDProvider = item.IDProd,
                            Date = item.DateBooking.ToShortDateString(),
                            Provider = DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == item.IDProd).FirstOrDefault().NameProd,
                        });
                        no++;
                    }
                }
                if (no >= 2) { SelectedReceipt = ListReceipt[0]; }
            }
        }
        public ICommand SelectedReceiptCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand TextSearchCommand { get; set; }

        public Admin_ListReceiptVM()
        {
            LoadCommand = new RelayCommand<object>(
              (p) => { return true; },
              (p) =>
              {
                  LoadData();
              }
              );
            SelectedReceiptCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                IdReceipt = SelectedReceipt.ID;

                Admin_ListImportItem Admin_ListImportItem = new Admin_ListImportItem();
                Admin_ListImportItem.Titlee.Text += SelectedReceipt.ID;
                Admin_ListImportItem.ShowDialog();
                LoadDataAfterTextSearch();
            }
            );
            TextSearchCommand = new RelayCommand<object>(
           (p) => { return true; },
           (p) =>
           {
               LoadDataAfterTextSearch();

           }
       );
            Add_Service.EditCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   IDD = SelectedReceipt.ID;
                   Admin_EditReceipt admin_EditReceipt = new Admin_EditReceipt();
                   admin_EditReceipt.ShowDialog();
                   LoadDataAfterTextSearch();
               }
           );
            Add_Service.DeleteCommand = new RelayCommand<object>(
              (p) => { return true; },
              (p) =>
              {

                  DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this receipt?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
                  if (result == System.Windows.Forms.DialogResult.Yes)
                  {
                      int IDtemp = DataProvider.Ins.DB.ITEMBILLs.ToList().Where(h => h.IDItemBillForm == SelectedReceipt.ID).Count();
                      while (IDtemp >= 1)
                      {
                          DataProvider.Ins.DB.ITEMBILLs.Remove(DataProvider.Ins.DB.ITEMBILLs.ToList().Where(h => h.IDItemBillForm == SelectedReceipt.ID).FirstOrDefault());
                          DataProvider.Ins.DB.SaveChanges();
                          IDtemp--;
                      }
                      DataProvider.Ins.DB.ITEMBILLFORMs.Remove(DataProvider.Ins.DB.ITEMBILLFORMs.ToList().Where(h => h.ID == SelectedReceipt.ID).FirstOrDefault());
                      DataProvider.Ins.DB.SaveChanges();
                      LoadDataAfterTextSearch();
                  }
              }
          );
        }
    }
}
