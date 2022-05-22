using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SelectedProductCartUC.xaml
    /// </summary>
    public partial class SelectedProductCartUC : UserControl
    {
        public SelectedProductCartUC()
        {
            InitializeComponent();
        }
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            txtQuantity.Text = (Int32.Parse(txtQuantity.Text)+1).ToString();
            CART cart = (from m in DataProvider.Ins.DB.CARTS
                         where m.IDItem == txtIDItem.Text
                         select m).Single();
            cart.Quantity = Int32.Parse(txtQuantity.Text);
            DataProvider.Ins.DB.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuantity.Text == "1")
            {
                btnMinus.IsEnabled = false;
            }
            else
            {
                txtQuantity.Text = (Int32.Parse(txtQuantity.Text) - 1).ToString();
                CART cart = (from m in DataProvider.Ins.DB.CARTS
                             where m.IDItem == txtIDItem.Text
                             select m).Single();
                cart.Quantity = Int32.Parse(txtQuantity.Text);
                DataProvider.Ins.DB.SaveChanges();
            }
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            CART cart = DataProvider.Ins.DB.CARTS.ToList().Where(x => x.IDItem == txtIDItem.Text).FirstOrDefault();
            DataProvider.Ins.DB.CARTS.Remove(cart);
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}

