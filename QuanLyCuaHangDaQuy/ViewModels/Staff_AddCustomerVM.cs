using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_AddCustomerVM : BaseViewModel
    {
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(nameof(_fullName)); }
        }
        public ICommand AddCommand { get; set; }
        public Staff_AddCustomerVM()
        {
            AddCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   Staff_ListCustomer staff_ListCustomer = new Staff_ListCustomer();
                   staff_ListCustomer.Show();
               }
           );
        }
    }
}
