using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class CartViewModel : BaseViewModel
    {
        public ICommand LoadCartCommand { get; set; }
       
        private SelectedItem _selecteditem{ get; set; }

        public SelectedItem Selected
        {
            get { return _selecteditem; }
            set { _selecteditem = value; OnPropertyChanged(nameof(Selected)); }
        }

        public CartViewModel()
        {
            LoadCartCommand = new RelayCommand<CartUC>((p) => true, (p) =>
            {
                GetItem();
                if (list.Count > 0) p.listViewCart.ItemsSource = list;

            });

            SelectedItem.DeleteCommand = new RelayCommand<CartUC>((p) => true, (p) =>
            {
                CART cart = DataProvider.Ins.DB.CARTS.ToList().Where(x => x.IDItem == Selected.IDItem).FirstOrDefault();
                DataProvider.Ins.DB.CARTS.Remove(cart);
                DataProvider.Ins.DB.SaveChanges();
                GetItem();
                if (list.Count > 0) p.listViewCart.ItemsSource = list;
                else p.listViewCart.ItemsSource = null;

            });
            SelectedItem.MinusCommand = new RelayCommand<CartUC>((p) => true, (p) =>
             {
                 if (Selected.Quantity == 1)
                 {
                     CART cart = DataProvider.Ins.DB.CARTS.ToList().Where(x => x.IDItem == Selected.IDItem).FirstOrDefault();
                     DataProvider.Ins.DB.CARTS.Remove(cart);
                     DataProvider.Ins.DB.SaveChanges();
                 }
                 else
                 {
                     Selected.Quantity = Selected.Quantity - 1;
                     CART cart = (from m in DataProvider.Ins.DB.CARTS
                                  where m.IDItem == Selected.IDItem
                                  select m).Single();
                     cart.Quantity = Selected.Quantity;
                     DataProvider.Ins.DB.SaveChanges();
                 }
                 GetItem();
                 if (list.Count > 0) p.listViewCart.ItemsSource = list;
                 else p.listViewCart.ItemsSource = null;
             });

            SelectedItem.PlusCommand = new RelayCommand<CartUC>((p) => true, (p) =>
            {
                Selected.Quantity = Selected.Quantity + 1;
                CART cart = (from m in DataProvider.Ins.DB.CARTS
                             where m.IDItem == Selected.IDItem
                             select m).Single();
                cart.Quantity = Selected.Quantity;
                DataProvider.Ins.DB.SaveChanges();
                GetItem();
                if (list.Count > 0) p.listViewCart.ItemsSource = list;
            });
        }
        private List<CART> cartList = new List<CART>();
        private List<SelectedItem> list = new List<SelectedItem>();
        string idmaterial = "";
        string idform = ""; 
        private void GetItem()
        {
            list.Clear();
            cartList = DataProvider.Ins.DB.CARTS.ToList();
            list = new List<SelectedItem>();
            if (cartList!=null)
            {
                int no = 1;
                foreach (var item in cartList)
                {
                    idmaterial = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().IDMaterial;
                    idform = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().IDForm;
                    list.Add(new SelectedItem()
                    {
                        IDItem = item.IDItem,
                        Total = item.Total,
                        NameItem = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().NameItem,
                        Quantity = (int)item.Quantity,
                        NameMaterial = DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(x => x.ID == idmaterial).FirstOrDefault().NameMaterial,
                        NameForm = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(x => x.ID == idform).FirstOrDefault().NameForm,
                        Picture = ConvertImage.LoadImage(DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().Picture)
                    });
                    no++;
                }
                if (no >= 2) { Selected = list[0]; }
            }
        }
        //private void btnExit_Click(CartUC window)
        //{
        //    CART cart = DataProvider.Ins.DB.CARTS.ToList().Where(x => x.IDItem == window.txtIDItem.Text).FirstOrDefault();
        //    DataProvider.Ins.DB.CARTS.Remove(cart);
        //    DataProvider.Ins.DB.SaveChanges();
        //}
    }
}

