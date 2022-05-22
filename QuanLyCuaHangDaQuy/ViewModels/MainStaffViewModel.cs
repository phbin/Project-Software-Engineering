using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Views.Staff;
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


        // public ICommand LoadedWindowCommand { get; set; }
        public ICommand HomeViewCommand { get; set; }
        public ICommand ShopViewCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }
        public ICommand CartViewCommand { get; set; }
        public ICommand CategoryTreeView { get; set; }
        public ICommand LoadItemCommand { get; set; }


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

            LoadItemCommand = new RelayCommand<ShopWindow>((p) => true, (p) => {
                LoadItem(p);
            });
           
            //click  cart
            CartClickVM = new CartViewModel();

            CartViewCommand = new RelayCommand<CartUC>((p) => true, (p) => {
                CurrentView = CartClickVM;
            });
        }
        private List<IMPORTEDITEM> itemList = DataProvider.Ins.DB.IMPORTEDITEMS.ToList();
        public void LoadItem(ShopWindow window)
        {
            window.wrpItem.Children.Clear();
            foreach ( var items in itemList)
            //for (int i = 0; i < itemList.Count; i++)
            {
                if (items.SellQty > 0)
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
            ShopItemsClickViewModel ShopItemClickVM = new ShopItemsClickViewModel((curBtn.Tag as IMPORTEDITEM).ID);
            CurrentView = ShopItemClickVM;
        }
    }
}
