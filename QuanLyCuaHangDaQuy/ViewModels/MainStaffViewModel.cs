using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Views.Staff;
using QuanLyCuaHangDaQuy.Views.Staff.Staff_Customer;
using QuanLyCuaHangDaQuy.Views.Staff.Staff_Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class MainStaffViewModel:BaseViewModel
    {
        HomeViewModel HomeClickVM { get; set; }
        CartViewModel CartClickVM { get; set; }
        Staff_ListReceiptVM ListReceiptVM { get; set; }
        Staff_ListCustomerVM ListCustomerVM { get; set; }
        //Staff_ReportYearVM ReportYearVM { get; set; }


        // public ICommand LoadedWindowCommand { get; set; }
        public ICommand HomeViewCommand { get; set; }
        public ICommand ShopViewCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }
        public ICommand CartViewCommand { get; set; }
        public ICommand CategoryTreeView { get; set; }
        public ICommand LoadItemCommand { get; set; }
        public ICommand ServiceViewCommand { get; set; }
        public ICommand CustomerViewCommand { get; set; }
        public ICommand ReportViewCommand { get; set; }
        public ICommand LogOutCommand { get; set; }


        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        //bool IsLoaded = false;
        public MainStaffViewModel()
        {
            HomeClickVM = new HomeViewModel();

            HomeViewCommand = new RelayCommand<HomeWindow>((p) => true, (p) => {
                CurrentView = HomeClickVM;
            });
            //click shop
            ShopViewCommand = new RelayCommand<ShopWindow>((p) => true, (p) => {
                CurrentView = this;
            });
            LogOutCommand = new RelayCommand<MainStaffWindow>((p) => true, (p) => {
                Logout(p);
            });
            LoadItemCommand = new RelayCommand<ShopWindow>((p) => true, (p) => {
                LoadItem(p);
            });
            //click service
            ListReceiptVM = new Staff_ListReceiptVM();

            ServiceViewCommand = new RelayCommand<Staff_ListReceipt>((p) => true, (p) => {
                CurrentView = ListReceiptVM;
            });
            //click report
            //ReportYearVM = new Staff_ReportYearVM();

            //ReportViewCommand = new RelayCommand<Views.Staff.ReportYearStaff>((p) => true, (p) => {
            //    CurrentView = ReportYearVM;
            //});
            //click customer
            ListCustomerVM = new Staff_ListCustomerVM();

            CustomerViewCommand = new RelayCommand<Views.Staff.Staff_Customer.Staff_ListCustomer>((p) => true, (p) => {
                CurrentView = ListCustomerVM;
            });
          
           
            //click  cart
            CartClickVM = new CartViewModel();

            CartViewCommand = new RelayCommand<CartUC>((p) => true, (p) => {
                CurrentView = CartClickVM;
            });
        }
        private List<ORIGINALITEM> itemList = DataProvider.Ins.DB.ORIGINALITEMs.ToList();
        public void LoadItem(ShopWindow window)
        {
            window.wrpItem.Children.Clear();
            foreach ( var items in itemList)
            //for (int i = 0; i < itemList.Count; i++)
            {
                if ((items.Quantity -items.SellQty) > 0)
                {
                    Resources.UserControls.ItemsControl control = new Resources.UserControls.ItemsControl();
                    control.txtName.Text = items.NameItem.ToString();
                    control.txbPrice.Text = items.Price.ToString();
                    control.txtQuantity.Text = items.SellQty.ToString();
                    control.txtDesc.Text = items.Descript.ToString();
                    control.txtID.Text = items.ID.ToString();
                    control.Tag = (object)items;
                    control.MouseLeftButtonDown += Control_MouseLeftButtonDown;
                    if (items.Picture != null)
                    {
                        control.imgGood.Source = ConvertImage.LoadImage(items.Picture);
                    }
                    window.wrpItem.Children.Add(control);
                }
            }
        }
      
        Resources.UserControls.ItemsControl curBtn = new Resources.UserControls.ItemsControl();
        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            curBtn = (Resources.UserControls.ItemsControl)sender;
            ShopItemsClickViewModel ShopItemClickVM = new ShopItemsClickViewModel((curBtn.Tag as ORIGINALITEM).ID);
            CurrentView = ShopItemClickVM;
        }
        private void Logout(MainStaffWindow wd)
        {
            LoginWindow frmLogin = new LoginWindow();
            frmLogin.Show();
            wd.Close();
        }
    }
}
