using QuanLyCuaHangDaQuy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_EditReceiptVM :BaseViewModel
    {
        
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
        
        private string _dateBooking_format;
        public string DateBooking_format
        {
            get { return _dateBooking_format; }
            set { _dateBooking_format = value; OnPropertyChanged(nameof(DateBooking_format)); }
        }
        public ObservableCollection<IN4Customer> ListCustomer { get; set; } = new ObservableCollection<IN4Customer>();
        private IN4Customer _selectedCustomer;
        public IN4Customer SelectedCustomer {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; OnPropertyChanged(nameof(SelectedCustomer)); }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public Staff_EditReceiptVM()
        {
            LoadCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
                foreach (var item in List)
                {
                    ListCustomer.Add(new IN4Customer { FullName = item.FullName, ID = item.ID });
                }
                //Load
                ID = Staff_ListReceiptVM.IDD;
                DateBooking_format= DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h=>h.ID== Staff_ListReceiptVM.IDD).FirstOrDefault().DateBooking.ToShortDateString();
                Stt = DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.ID == Staff_ListReceiptVM.IDD).FirstOrDefault().Stt;
                string idcs = DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(a => a.ID == Staff_ListReceiptVM.IDD).FirstOrDefault().IDCustomer;
                SelectedCustomer = ListCustomer.ToList().Where(h => h.ID == idcs).FirstOrDefault();
            }
        );
            EditCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.ID == Staff_ListReceiptVM.IDD).FirstOrDefault().IDCustomer = SelectedCustomer.ID;
                DataProvider.Ins.DB.SaveChanges();
                (p as Window).Close();
            }
        );
        }
    }
}
