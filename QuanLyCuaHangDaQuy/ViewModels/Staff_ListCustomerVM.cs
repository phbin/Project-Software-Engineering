using QuanLyCuaHangDaQuy.Model;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            set { _selectedCustomer = value; OnPropertyChanged(nameof(_selectedCustomer)); }
        }
        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(_textSearch)); }
        }
        public ICommand LoadCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
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
                        ListCustomer.Add(new Customer { No = no, DoB = item.DoB, DoB_Format = item.DoB.ToShortDateString(), FullName = item.FullName, ID = item.ID, IDPersonal = item.IDPersonal, Phone = item.Phone, Points = item.Points, Email = item.Email ,Colorr= "#FCC871" });
                        no++;
                    }
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
                }
            );
            EditCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                 Staff_EditCustomer staff_EditCustomer = new Staff_EditCustomer();
                 staff_EditCustomer.ShowDialog();
             }
         );
            DeleteCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                 MessageBox.Show("Xóa","dsda");
             }
         );
            // SearchCommand = new RelayCommand<object>(
            //    (p) => { return true; },
            //    (p) =>
            //    {
            //        MessageBox.Show(TextSearch);
            //        if (String.Equals(TextSearch, "") == false || TextSearch != string.Empty)
            //        {
            //            ListCustomer.Clear();
            //            var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
            //            int no = 1;
            //            foreach (var item in List)
            //            {
            //                if (item.FullName.Contains(TextSearch))
            //                {
            //                    ListCustomer.Add(new Customer { No = no, DoB = item.DoB, DoB_Format = item.DoB.ToShortDateString(), FullName = item.FullName, ID = item.ID, IDPersonal = item.IDPersonal, Phone = item.Phone, Points = item.Points, Email = item.Email, Colorr = "#FCC871" });
            //                    no++;
            //                }

            //            }
            //        }
            //    }
            //);
            TextSearchCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                 if(TextSearch=="")
                 {
                     ListCustomer.Clear();
                     var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
                     int no = 1;
                     foreach (var item in List)
                     {
                         ListCustomer.Add(new Customer { No = no, DoB = item.DoB, DoB_Format = item.DoB.ToShortDateString(), FullName = item.FullName, ID = item.ID, IDPersonal = item.IDPersonal, Phone = item.Phone, Points = item.Points, Email = item.Email, Colorr = "#FCC871" });
                         no++;
                     }
                 }
                 else
                 {
                     ListCustomer.Clear();
                     var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
                     int no = 1;
                     foreach (var item in List)
                     {
                         if (item.FullName.Contains(TextSearch) && TextSearch != null)
                         {
                             ListCustomer.Add(new Customer { No = no, DoB = item.DoB, DoB_Format = item.DoB.ToShortDateString(), FullName = item.FullName, ID = item.ID, IDPersonal = item.IDPersonal, Phone = item.Phone, Points = item.Points, Email = item.Email, Colorr = "#FCC871" });
                             no++;
                         }

                     }
                 }
             }
         );
        }

    }
}
