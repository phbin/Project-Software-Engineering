using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Views.Staff;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class MainStaffViewModel:BaseViewModel
    {
        ShopItemsClickViewModel ShopItemClickVM { get; set; }
        HomeViewModel HomeClickVM { get; set; }
        CartViewModel CartClickVM { get; set; }

        public ICommand HomeViewCommand { get; set; }
        public ICommand ShopViewCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }
        public ICommand CartViewCommand { get; set; }

        
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
        public MainStaffViewModel()
        {
            //click home
            HomeClickVM = new HomeViewModel();

            HomeViewCommand = new RelayCommand<HomeWindow>((p) => true, (p) => {
                CurrentView = HomeClickVM;
            });

            //click shop
            ShopViewCommand = new RelayCommand<ShopWindow>((p) => true, (p) => {
                CurrentView = this;
            });
            //click item in shop
            ShopItemClickVM = new ShopItemsClickViewModel();

            ItemClickCommand = new RelayCommand<ShopItemsClick>((p) => true, (p) =>
            {
                CurrentView = ShopItemClickVM;
            });
            //click  cart
            CartClickVM = new CartViewModel();

            CartViewCommand = new RelayCommand<CartUC>((p) => true, (p) => {
                CurrentView = CartClickVM;
            });
        }
    }
}
