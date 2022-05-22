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
    public class Staff_AddReceiptVM :BaseViewModel
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
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public Staff_AddReceiptVM()
        {
            LoadCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                bool Flag = false;
                int Temp = 0;
                while (Flag == false)
                {
                    Temp++;
                    if(DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h=>h.ID== "CS" + (Temp).ToString()).FirstOrDefault()==null)
                    {
                        Flag = true;
                    }
                }
                
                ID ="CS" +(Temp).ToString();
                DateBooking = DateTime.Today;
                DateBooking_format= DateBooking.ToShortDateString();
                Stt = "unfinish";
                var List=  DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
                foreach (var item in List)
                {
                    ListCustomer.Add(new IN4Customer { FullName =item.FullName,ID=item.ID});
                }
            }
        );
            AddCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if(SelectedCustomer==null)
                {
                    MessageBox.Show("Please fill in all the information");
                    return;
                }    
                DataProvider.Ins.DB.CUSSERVICEs.Add(new CUSSERVICE
                {
                    DateBooking = DateBooking,
                    Stt = Stt,
                    ID = ID,
                    IDCustomer = SelectedCustomer.ID
                });
                DataProvider.Ins.DB.SaveChanges();
                (p as Window).Close();
            }
        );
        }

    }
}
