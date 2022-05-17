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
                    SelectedCustomer = ListCustomer[0];
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
                         ListCustomer.Add(new Customer { No = no, DoB = item.DoB, DoB_Format = item.DoB.ToShortDateString(), FullName = item.FullName, ID = item.ID, IDPersonal = item.IDPersonal, Phone = item.Phone, Points = item.Points, Email = item.Email });
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
                             ListCustomer.Add(new Customer { No = no, DoB = item.DoB, DoB_Format = item.DoB.ToShortDateString(), FullName = item.FullName, ID = item.ID, IDPersonal = item.IDPersonal, Phone = item.Phone, Points = item.Points, Email = item.Email });
                             no++;
                         }

                     }
                 }
             }
         );
            Customer.EditCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                Staff_EditCustomer staff_EditCustomer = new Staff_EditCustomer();
                staff_EditCustomer.FullName.Text =  SelectedCustomer.FullName.ToString();
                staff_EditCustomer.ShowDialog();
            }
        );
            Customer.DeleteCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this customer?","", (MessageBoxButtons)MessageBoxButton.YesNo);
                if(result == System.Windows.Forms.DialogResult.Yes)
                {
                 
                }
                else
                {
                  
                }
            }
        );


        }


    }
}
