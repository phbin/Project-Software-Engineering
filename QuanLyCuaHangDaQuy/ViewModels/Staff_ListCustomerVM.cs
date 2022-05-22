using QuanLyCuaHangDaQuy.Model;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_ListCustomerVM:BaseViewModel
    {
        public ObservableCollection <Customer> ListCustomer { get; set; } = new ObservableCollection <Customer> ();

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; OnPropertyChanged(nameof(SelectedCustomer)); }
        }
        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public void LoadData()
        {
            ListCustomer.Clear();
            var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                var DatTen = new Customer
                {
                    No = no,
                    DoB = item.DoB,
                    DoB_Format = item.DoB.ToShortDateString(),
                    FullName = item.FullName,
                    ID = item.ID,
                    IDPersonal = item.IDPersonal,
                    Phone = item.Phone,
                    Points = item.Points,
                    Email = item.Email,
                };
                ListCustomer.Add(DatTen);
                no++;
            }
            if (no >= 2) { SelectedCustomer = ListCustomer[0]; }

        }

        public void LoadDataAfterTextSearch()

        {
            if (TextSearch == "" || TextSearch == null)
            {
                LoadData();
            }
            else
            {
                ListCustomer.Clear();
                var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    if (item.FullName.Contains(TextSearch))
                    {
                        ListCustomer.Add(new Customer { No = no, DoB = item.DoB, DoB_Format = item.DoB.ToShortDateString(), FullName = item.FullName, ID = item.ID, IDPersonal = item.IDPersonal, Phone = item.Phone, Points = item.Points, Email = item.Email });
                        no++;
                    }
                    if (no >= 2) { SelectedCustomer = ListCustomer[0]; }

                }
            }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SelectedCustomerCommand { get; set; }
        public ICommand TextSearchCommand { get; set; }
        public Staff_ListCustomerVM()
        {
            LoadCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
                    int no = 1;
                    foreach (var item in List)
                    {
                        var DatTen = new Customer
                        {
                            No = no,
                            DoB = item.DoB,
                            DoB_Format = item.DoB.ToShortDateString(),
                            FullName = item.FullName,
                            ID = item.ID,
                            IDPersonal = item.IDPersonal,
                            Phone = item.Phone,
                            Points = item.Points,
                            Email = item.Email,
                        };
                        ListCustomer.Add(DatTen);
                        no++;
                    }
                    if (no >= 2) { SelectedCustomer = ListCustomer[0]; }
                }
            );
            SelectedCustomerCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                    Staff_InfoCustomer staff_InfoCustomer = new Staff_InfoCustomer();
                   staff_InfoCustomer.FullName.Text = SelectedCustomer.FullName.ToString();
                   staff_InfoCustomer.Email.Text = SelectedCustomer.Email.ToString();
                   staff_InfoCustomer.Birthday.Text = SelectedCustomer.DoB_Format.ToString();
                   staff_InfoCustomer.IDPersonal.Text = SelectedCustomer.IDPersonal.ToString();
                   staff_InfoCustomer.Phonenumber.Text = SelectedCustomer.Phone.ToString();
                   staff_InfoCustomer.Point.Text = SelectedCustomer.Points.ToString();
                   staff_InfoCustomer.ShowDialog();
               }
           );
            AddCommand = new RelayCommand<object>(
                (p) => { return true; },
                (p) =>
                {
                    Staff_AddCustomer staff_AddCustomer = new Staff_AddCustomer();
                    staff_AddCustomer.ShowDialog();
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
            Customer.EditCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                Staff_EditCustomer staff_EditCustomer = new Staff_EditCustomer();
                staff_EditCustomer.FullName.Text =  SelectedCustomer.FullName.ToString();
                staff_EditCustomer.Email.Text = SelectedCustomer.Email.ToString();
                staff_EditCustomer.Birthday.Text = SelectedCustomer.DoB_Format.ToString();
                staff_EditCustomer.IDPersonal.Text = SelectedCustomer.IDPersonal.ToString();
                staff_EditCustomer.Phonenumber.Text = SelectedCustomer.Phone.ToString();
                staff_EditCustomer.Point.Text = SelectedCustomer.Points.ToString();
                staff_EditCustomer.ID.Text = SelectedCustomer.ID.ToString();
                staff_EditCustomer.ShowDialog();
                LoadDataAfterTextSearch();
            }
        );
            Customer.DeleteCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this customer?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int IDtemp = DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.IDCustomer==SelectedCustomer.ID).Count();
                    while( IDtemp >=1)
                    {
                        string IDItemform= DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.IDCustomer == SelectedCustomer.ID).FirstOrDefault().ID;
                        int IDtemp1 = DataProvider.Ins.DB.ITEMS.ToList().Where(h => h.IDItemForm == IDItemform).Count();
                        while(IDtemp1 >=1)
                        {
                            DataProvider.Ins.DB.ITEMS.Remove(DataProvider.Ins.DB.ITEMS.Where(h => h.IDItemForm == IDItemform).FirstOrDefault());
                            IDtemp1--;
                        }
                        DataProvider.Ins.DB.ITEMFORMs.Remove(DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.IDCustomer == SelectedCustomer.ID).FirstOrDefault());
                        IDtemp--;

                    }
                    IDtemp = DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.IDCustomer == SelectedCustomer.ID).Count();
                    while (IDtemp >= 1)
                    {
                        string IDService = DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.IDCustomer == SelectedCustomer.ID).FirstOrDefault().ID;
                        int IDtemp1 = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.IDService == IDService).Count();
                        while (IDtemp1 >= 1)
                        {
                            DataProvider.Ins.DB.SERVICELISTs.Remove(DataProvider.Ins.DB.SERVICELISTs.Where(h => h.IDService == IDService).FirstOrDefault());
                            IDtemp1--;
                        }
                        DataProvider.Ins.DB.CUSSERVICEs.Remove(DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.IDCustomer == SelectedCustomer.ID).FirstOrDefault());
                        IDtemp--;

                    }
                    DataProvider.Ins.DB.INFOCUSTOMERs.Remove(DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == SelectedCustomer.ID).FirstOrDefault());
                    DataProvider.Ins.DB.SaveChanges();
                    LoadDataAfterTextSearch();
                }
            }
        );

        }


    }
}
