using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_AddServiceVM : BaseViewModel
    {
        public class IN4Service
        {
            private string _nameService;
            public string NameService
            {
                get { return _nameService; }
                set { _nameService = value; }
            }
            private string _id;
            public string ID
            {
                get { return _id; }
                set { _id = value; }
            }
        }
        private string _repay;
        public string Repay
        {
            get { return _repay; }
            set { _repay = value; OnPropertyChanged(nameof(Repay)); }
        }
        private string _cost;
        public string Cost
        {
            get { return _cost; }
            set { _cost = value; OnPropertyChanged(nameof(Cost)); }
        }
        private DateTime _returnDate;
        public DateTime ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; OnPropertyChanged(nameof(ReturnDate)); }
        }
        private string _returnDate_format;
        public string ReturnDate_format
        {
            get { return _returnDate_format; }
            set { _returnDate_format = value; OnPropertyChanged(nameof(ReturnDate_format)); }
        }
        private string _priceDiscounted;
        public string PriceDiscounted
        {
            get { return _priceDiscounted; }
            set { _priceDiscounted = value; OnPropertyChanged(nameof(PriceDiscounted)); }
        }
        private string _remain;
        public string Remain
        {
            get { return _remain; }
            set { _remain = value; OnPropertyChanged(nameof(Remain)); }
        }
        public ObservableCollection<IN4Service> ListService { get; set; } = new ObservableCollection<IN4Service>();
        private IN4Service _selectedService;
        public IN4Service SelectedService
        {
            get { return _selectedService; }
            set { _selectedService = value; OnPropertyChanged(nameof(SelectedService)); }
        }
        public ObservableCollection<int> QTT { get; set; } = new ObservableCollection<int>();
        private int _qTTSL;
        public int QTTSL
        {
            get { return _qTTSL; }
            set { _qTTSL = value; OnPropertyChanged(nameof(QTTSL)); }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }

        public ICommand CostChangedCommand { get; set; }
        public ICommand RepayChangedCommand { get; set; }
        public ICommand QTTChangedCommand { get; set; }

        public Staff_AddServiceVM()
        {
            LoadCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                for (int i = 1; i <= 100; i++) QTT.Add(i);
                var List = DataProvider.Ins.DB.SERVICECATEGORies.ToList();
                foreach (var item in List)
                {
                    ListService.Add(new IN4Service
                    {
                        ID = item.ID,
                        NameService = item.NameService,
                    });
                }
                QTTSL = 1;
                Remain = "0";
                Repay = "0";
                PriceDiscounted = "0";
                Cost = "0";
            }
        );
            AddCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if (SelectedService == null || Repay == "" || Cost == "" || ReturnDate_format == "")
                {
                    MessageBox.Show("Please fill in all the information");
                    return;
                }
                if (Convert.ToInt64(Repay) < Convert.ToInt64(Remain) || Convert.ToInt64(Remain) < 0)
                {
                    MessageBox.Show("Total * 0.5 <= Prepay <= Total");
                    Repay = "";
                    return;
                }
                bool Flag = false;
                int Temp = 0;
                while (Flag == false)
                {
                    Temp++;
                    if (DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == "SL" + (Temp).ToString()).FirstOrDefault() == null)
                    {
                        Flag = true;
                    }
                }
                DataProvider.Ins.DB.SERVICELISTs.Add(new SERVICELIST
                {
                    IDService = SelectedService.ID,
                    Costs = double.Parse(Cost),
                    IDCusService = Staff_ListReceiptVM.IdReceipt,
                    Prepay = double.Parse(Repay),
                    PriceDiscounted = double.Parse(PriceDiscounted),
                    Quantity = QTTSL,
                    Remain = double.Parse(Remain),
                    Stt = "unfinished",
                    Total = double.Parse(Remain) + double.Parse(Repay),
                    DateReturn = DateTime.Parse(ReturnDate_format, CultureInfo.InvariantCulture),
                    ID = "SL" + Temp.ToString(),
                });
                DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.ID == Staff_ListReceiptVM.IdReceipt).FirstOrDefault().Stt = "unfinished";
                DataProvider.Ins.DB.SaveChanges();
                (p as Window).Close();
            }
        );
            SelectionChangedCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                PriceDiscounted = (Convert.ToInt64(DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault().Price) + Convert.ToInt64(Cost)).ToString();
                Remain = ((Convert.ToInt64(PriceDiscounted) * QTTSL) - Convert.ToInt64(Repay)).ToString();
            }
        );
            CostChangedCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if (Cost.Length == 11)
                {
                    MessageBox.Show("Cost too long");
                    Cost = "0";
                    return;
                }
                if (Cost != "" && SelectedService != null && Repay != "")
                {
                    PriceDiscounted = (Convert.ToInt64(DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault().Price) + Convert.ToInt64(Cost)).ToString();
                    Remain = ((Convert.ToInt64(PriceDiscounted) * QTTSL) - Convert.ToInt64(Repay)).ToString();
                }

            }
        );
            RepayChangedCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if (Repay.Length == 11)
                {
                    MessageBox.Show("Repay too long");
                    Repay = "0";
                    return;
                }
                if (Repay != "" && SelectedService != null)
                {
                    Remain = ((Convert.ToInt64(PriceDiscounted) * QTTSL) - Convert.ToInt64(Repay)).ToString();
                }


            }
        );
            QTTChangedCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if (Repay != "" && SelectedService != null)
                {
                    Remain = ((Convert.ToInt64(PriceDiscounted) * QTTSL) - Convert.ToInt64(Repay)).ToString();
                }
            }
        );
        }

    }
}
