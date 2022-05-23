using QuanLyCuaHangDaQuy.Model;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_ListReceiptVM : BaseViewModel
    {
        public static string IDD;
        public ObservableCollection<Receipt> ListReceipt { get; set; } = new ObservableCollection<Receipt>();
        private Receipt _selectedReceipt { get; set; }
        public Receipt SelectedReceipt
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
            
            var List = DataProvider.Ins.DB.CUSSERVICEs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                var DatTen = new Receipt
                {
                    No = no,
                    IDCustomer = item.IDCustomer,
                    FullName = DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == item.IDCustomer).FirstOrDefault().FullName,
                    DateBooking_format = item.DateBooking.ToShortDateString(),
                    DateBooking = item.DateBooking,
                    ID = item.ID,
                    Stt = item.Stt,
                    ColorStt = (item.Stt == "unfinished") ? "#BCBCBC" : "#2CC33B",
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
                var List = DataProvider.Ins.DB.CUSSERVICEs.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    string FullName = DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == item.IDCustomer).FirstOrDefault().FullName;
                    if (FullName.Contains(TextSearch))
                    {
                        ListReceipt.Add(new Receipt
                        {
                            No = no,
                            IDCustomer = item.IDCustomer,
                            DateBooking_format = item.DateBooking.ToShortDateString(),
                            FullName = DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == item.IDCustomer).FirstOrDefault().FullName,
                            DateBooking = item.DateBooking,
                            ID = item.ID,
                            Stt = item.Stt,
                            ColorStt = (item.Stt == "unfinished") ? "#BCBCBC" : "#2CC33B",
                        });
                        no++;
                    }
                }
                if (no >= 2) { SelectedReceipt = ListReceipt[0]; }
            }
        }
        public ICommand SelectedReceiptCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand TextSearchCommand { get; set; }
      
        public Staff_ListReceiptVM()
        {
            LoadCommand = new RelayCommand<object>(
              (p) => { return true; },
              (p) =>
              {
                  LoadData();
              }
              );
            AddCommand = new RelayCommand<object>(
              (p) => { return true; },
              (p) =>
              {
                  Staff_AddReceipt staff_AddReceipt = new Staff_AddReceipt();
                  staff_AddReceipt.ShowDialog();
                  LoadDataAfterTextSearch();
              }
              );
            SelectedReceiptCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                IdReceipt = SelectedReceipt.ID;
                Staff_ListService staff_ListService = new Staff_ListService();
                staff_ListService.Titlee.Text += IdReceipt;
                staff_ListService.ShowDialog();
                LoadDataAfterTextSearch();
            }
            );
            TextSearchCommand = new RelayCommand<object>(
           (p) => { return true; },
           (p) =>
           {

               if (TextSearch == "" || TextSearch == null)
               {
                   ListReceipt.Clear();
                   LoadData();
               }
               else
               {
                   ListReceipt.Clear();
                   var List = DataProvider.Ins.DB.CUSSERVICEs.ToList();
                   int no = 1;
                   foreach (var item in List)
                   {
                       string FullName = DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == item.IDCustomer).FirstOrDefault().FullName;
                       if (FullName.Contains(TextSearch))
                       {
                           ListReceipt.Add(new Receipt
                           {
                               No = no,
                               IDCustomer = item.IDCustomer,
                               DateBooking_format = item.DateBooking.ToShortDateString(),
                               FullName = DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == item.IDCustomer).FirstOrDefault().FullName,
                               DateBooking = item.DateBooking,
                               ID = item.ID,
                               Stt = item.Stt,
                               ColorStt = (item.Stt == "unfinished") ? "#BCBCBC" : "#2CC33B",
                           });
                           no++;
                       }
                   }
                   if (no >= 2) { SelectedReceipt = ListReceipt[0]; }
               }
           }
       );
            Receipt.EditCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   IDD = SelectedReceipt.ID;
                   Staff_EditReceipt staff_EditReceipt=new Staff_EditReceipt();
                   staff_EditReceipt.ShowDialog();
                   LoadDataAfterTextSearch();
               }
           );
            Receipt.DeleteCommand = new RelayCommand<object>(
              (p) => { return true; },
              (p) =>
              {
                  
                  DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this receipt?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
                  if (result == System.Windows.Forms.DialogResult.Yes)
                  {
                      int IDtemp = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.IDCusService == SelectedReceipt.ID).Count();
                      while (IDtemp >= 1)
                      {
                          DataProvider.Ins.DB.SERVICELISTs.Remove(DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.IDCusService == SelectedReceipt.ID).FirstOrDefault());
                          IDtemp--;
                      }
                      DataProvider.Ins.DB.CUSSERVICEs.Remove(DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.ID == SelectedReceipt.ID).FirstOrDefault());
                      DataProvider.Ins.DB.SaveChanges();
                      LoadDataAfterTextSearch();
                  }
              }
          );
        }
    }
}
