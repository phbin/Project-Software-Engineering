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
    public class Staff_EditServiceVM : BaseViewModel
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
        public ICommand EditCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }

        public ICommand CostChangedCommand { get; set; }
        public ICommand RepayChangedCommand { get; set; }
        public ICommand QTTChangedCommand { get; set; }

        public Staff_EditServiceVM()
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
                QTTSL = Convert.ToInt32(DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Quantity);
                Repay = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Prepay.ToString();
                Remain = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Remain.ToString();
                Cost = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Costs.ToString();
                PriceDiscounted = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().PriceDiscounted.ToString();
                ReturnDate = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().DateReturn;
                ReturnDate_format = ReturnDate.ToShortDateString();
                SelectedService = ListService.ToList().Where(h => h.ID == DataProvider.Ins.DB.SERVICELISTs.ToList().Where(a => a.ID == Staff_ListServiceVM.IDD).FirstOrDefault().IDService).FirstOrDefault();
            }
        );
            EditCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if (SelectedService == null || Repay == "" || Cost == "" || ReturnDate_format == "")
                {
                    MessageBox.Show("Please fill in all the information");
                    return;
                }
                if (Convert.ToInt32(Repay) < Convert.ToInt32(Remain))
                {
                    MessageBox.Show("Repay >= Total * 0.5");
                    Repay = "0";
                    return;
                }
                DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Quantity = QTTSL;
                DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Remain = double.Parse(Remain);
                DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Costs = double.Parse(Cost);
                DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().Prepay = double.Parse(Repay);
                DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().PriceDiscounted = double.Parse(PriceDiscounted);
                DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().DateReturn = DateTime.Parse(ReturnDate_format, CultureInfo.InvariantCulture);
                DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.ID == Staff_ListServiceVM.IDD).FirstOrDefault().IDService = SelectedService.ID;
                DataProvider.Ins.DB.SaveChanges();
                (p as Window).Close();
            }
        );
            SelectionChangedCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                PriceDiscounted = (Convert.ToInt32(DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault().Price) + Convert.ToInt32(Cost)).ToString();
                Remain = ((Convert.ToInt32(PriceDiscounted) * QTTSL) - Convert.ToInt32(Repay)).ToString();
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
                    PriceDiscounted = (Convert.ToInt32(DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault().Price) + Convert.ToInt32(Cost)).ToString();
                    Remain = ((Convert.ToInt32(PriceDiscounted) * QTTSL) - Convert.ToInt32(Repay)).ToString();
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
                    Remain = ((Convert.ToInt32(PriceDiscounted) * QTTSL) - Convert.ToInt32(Repay)).ToString();
                }


            }
        );
            QTTChangedCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if (Repay != "" && SelectedService != null)
                {
                    Remain = ((Convert.ToInt32(PriceDiscounted) * QTTSL) - Convert.ToInt32(Repay)).ToString();
                }
            }
        );
        }
    }
}
