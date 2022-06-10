using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyCuaHangDaQuy.Resources.UserControls
{
    /// <summary>
    /// Interaction logic for CartUC.xaml
    /// </summary>
    public partial class CartUC : UserControl
    {
        public CartUC()
        {
            InitializeComponent();
        }

        private void listViewCart_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            listViewCart.SelectedItem = (sender as ListView).SelectedItem;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            listViewCart.SelectedItem = item;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            listViewCart.SelectedItem = item;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as Button;
            var item = cb.DataContext;
            listViewCart.SelectedItem = item;
        }

        //private void btnMinus_Click(object sender, RoutedEventArgs e)
        //{
        //    if (Selected.Quantity == 1)
        //    {
        //        CART cart = DataProvider.Ins.DB.CARTS.ToList().Where(x => x.IDItem == Selected.IDItem).FirstOrDefault();
        //        DataProvider.Ins.DB.CARTS.Remove(cart);
        //        DataProvider.Ins.DB.SaveChanges();
        //    }
        //    else
        //    {
        //        Selected.Quantity = Selected.Quantity - 1;
        //        CART cart = (from m in DataProvider.Ins.DB.CARTS
        //                     where m.IDItem == Selected.IDItem
        //                     select m).Single();
        //        cart.Quantity = Selected.Quantity;
        //        DataProvider.Ins.DB.SaveChanges();
        //    }
        //    GetItem();
        //    if (list.Count > 0)
        //    {
        //        listViewCart.ItemsSource = list;
        //        txtCount.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Quantity).ToString() + " item(s)";
        //        txtTotalAll.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Total).ToString() + "VND";
        //    }
        //    else
        //    {
        //        listViewCart.ItemsSource = null;
        //        txtCount.Text = "0 item(s)";
        //        txtTotalAll.Text = "0VND";
        //    }
        //}
        //private List<CART> cartList = new List<CART>();
        //private List<SelectedItem> list = new List<SelectedItem>();
        //string idmaterial = "";
        //string idform = "";
        //private void GetItem()
        //{
        //    list.Clear();
        //    cartList = DataProvider.Ins.DB.CARTS.ToList();
        //    list = new List<SelectedItem>();
        //    if (cartList != null)
        //    {
        //        int no = 1;
        //        foreach (var item in cartList)
        //        {
        //            idmaterial = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().IDMaterial;
        //            idform = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().IDForm;
        //            list.Add(new SelectedItem()
        //            {
        //                IDItem = item.IDItem,
        //                Total = item.Total,
        //                NameItem = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().NameItem,
        //                Quantity = (int)item.Quantity,
        //                NameMaterial = DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(x => x.ID == idmaterial).FirstOrDefault().NameMaterial,
        //                NameForm = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(x => x.ID == idform).FirstOrDefault().NameForm,
        //                Picture = ConvertImage.LoadImage(DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID == item.IDItem).FirstOrDefault().Picture)
        //            });
        //            no++;
        //        }
        //        if (no >= 2) { Selected = list[0]; }
        //    }
        //}
    }
}
