using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using QuanLyCuaHangDaQuy.ViewModels;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using QuanLyCuaHangDaQuy.Views;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class CustomerViewModel:BaseViewModel
    {
        //private MainWindow mainWindow;
        //private List<CustomerControl> ListCustomerControl = new List<CustomerControl>();
        //private CustomerControl customerControl;
        private string name;
        private string phoneNumber;
        private string mail;
        private string point;
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string PhoneNumber { get => phoneNumber; set { phoneNumber = value; OnPropertyChanged(); } }
        public string Mail { get => mail; set { mail = value; OnPropertyChanged(); } }
        public string Point { get => point; set { point = value; OnPropertyChanged(); } }
        public ICommand EditCommand { get; set; }
    }

}
