using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Views.Admin.Admin_Service;
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
    public class Admin_Service : BaseViewModel
    {
        public static ICommand EditCommand { get; set; }
        public static ICommand DeleteCommand { get; set; }
        private string _stt;
        public string Stt
        {
            get { return _stt; }
            set { _stt = value; OnPropertyChanged(nameof(Stt)); }
        }
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private int _no;
        public int No
        {
            get { return _no; }
            set { _no = value; OnPropertyChanged(nameof(No)); }
        }
        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
    }
    public class Admin_ListServiceVM : BaseViewModel
    {
        public ObservableCollection<Admin_Service> ListService { get; set; } = new ObservableCollection<Admin_Service>();

        private Admin_Service _selectedService;
        public static string IDService;
        public Admin_Service SelectedService
        {
            get { return _selectedService; }
            set { _selectedService = value; OnPropertyChanged(nameof(SelectedService)); }
        }
        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public void LoadData()
        {
            ListService.Clear();
            var List = DataProvider.Ins.DB.SERVICECATEGORies.ToList();
            int no = 1;
            foreach (var item in List)
            {
                if (item.Stt == 1)
                {
                    var DatTen = new Admin_Service
                    {
                        No = no,
                        Name = item.NameService,
                        Price = (item.Price != 0) ? (string.Format("{0:0,0đ}", item.Price)) : ("0đ"),
                        ID = item.ID,
                        Stt = item.Stt.ToString(),
                    };
                    ListService.Add(DatTen);
                    no++;
                }

            }
        }

        public void LoadDataAfterTextSearch()

        {
            if (TextSearch == "" || TextSearch == null)
            {
                LoadData();
            }
            else
            {
                ListService.Clear();
                var List = DataProvider.Ins.DB.SERVICECATEGORies.ToList();
                int no = 1;
                foreach (var item in List)

                {
                    if (item.Stt == 1)
                    {
                        if (item.NameService.Contains(TextSearch))
                        {
                            ListService.Add(new Admin_Service
                            {
                                No = no,
                                Name = item.NameService,
                                Price = (item.Price != 0) ? (string.Format("{0:0,0đ}", item.Price)) : ("0đ"),
                                ID = item.ID,
                            });
                            no++;
                        }
                    }

                }
            }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand TextSearchCommand { get; set; }
        public Admin_ListServiceVM()
        {
            LoadCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    var List = DataProvider.Ins.DB.SERVICECATEGORies.ToList();
                    int no = 1;
                    foreach (var item in List)
                    {
                        if (item.Stt == 1)
                        {
                            var DatTen = new Admin_Service
                            {
                                No = no,
                                Name = item.NameService,
                                Price = (item.Price != 0) ? (string.Format("{0:0,0đ}", item.Price)) : ("0đ"),
                                ID = item.ID,
                            };
                            ListService.Add(DatTen);
                            no++;
                        }
                    }
                }
            );
            AddCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    Admin_AddService addService = new Admin_AddService();
                    addService.ShowDialog();
                    TextSearch = "";
                    LoadData();
                }
            );
            TextSearchCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                 LoadDataAfterTextSearch();
             }
         );
            Admin_Service.EditCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                IDService = SelectedService.ID;
                Admin_EditService editService = new Admin_EditService();
                editService.ShowDialog();
                LoadDataAfterTextSearch();
            }
        );
            Admin_Service.DeleteCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this service?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == SelectedService.ID).FirstOrDefault().Stt = 0;
                    DataProvider.Ins.DB.SaveChanges();
                    LoadDataAfterTextSearch();
                }
            }
        );

        }
    }
}
