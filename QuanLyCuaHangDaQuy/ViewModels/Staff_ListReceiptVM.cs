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
        public ICommand SelectedReceiptCommand { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand LoadEditCommand { get; set; }
        public ICommand TextSearchCommand { get; set; }
        // EditVM
        public class IN4Customer
        {
            private string _fulltName;
            public string FullName
            {
                get { return _fulltName; }
                set { _fulltName = value; }
            }
            private string _id;
            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
        }
        private string _stt;
        public string Stt
        {
            get { return _stt; }
            set { _stt = value; OnPropertyChanged(nameof(Stt)); }
        }
        private string _iD;
        public string ID
        {
            get { return _iD; }
            set { _iD = value; OnPropertyChanged(nameof(ID)); }
        }
        private DateTime _dateBooking;
        public DateTime DateBooking
        {
            get { return _dateBooking; }
            set { _dateBooking = value; OnPropertyChanged(nameof(DateBooking)); }
        }
        private string _dateBooking_format;
        public string DateBooking_format
        {
            get { return _dateBooking_format; }
            set { _dateBooking_format = value; OnPropertyChanged(nameof(DateBooking_format)); }
        }
        public ObservableCollection<IN4Customer> ListCustomer { get; set; } = new ObservableCollection<IN4Customer>();
        public IN4Customer SelectedCustomer { get; set; }
        public ICommand FuntionEdit { get; set; }
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
                  TextSearch = "";
                  ListReceipt.Clear();
                  LoadData();
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
                ListReceipt.Clear();
                LoadData();
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

                   //foreach (var item in DataProvider.Ins.DB.INFOCUSTOMERs.ToList())
                   //{
                   //    ListCustomer.Add(new IN4Customer { ID = item.ID, FullName = item.FullName });
                   //}
                   //staff_EditReceipt.ID.Text = SelectedReceipt.ID;
                   //staff_EditReceipt.Status.Text = SelectedReceipt.Stt;
                   //staff_EditReceipt.Bookingdate.Text = SelectedReceipt.DateBooking_format;
                   //Staff_EditReceipt staff_EditReceipt = new Staff_EditReceipt();
                   //staff_EditReceipt.ShowDialog();
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
                      ListReceipt.Clear();
                      LoadData();
                      TextSearch = "";
                  }
              }
          );
            FuntionEdit = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
            }
            );
        }
    }
}
