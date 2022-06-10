using QuanLyCuaHangDaQuy.Models;
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
using System.Windows.Shapes;

namespace QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems
{
    /// <summary>
    /// Interaction logic for Admin_AddImportItem.xaml
    /// </summary>
    public partial class Admin_AddImportItem : Window
    {
        public Admin_AddImportItem()
        {
            InitializeComponent();
            dpDatePurchase.SelectedDate=DateTime.Now;
            var list = DataProvider.Ins.DB.INFOPROVIDERs.Select(x => x.NameProd).ToList();
            foreach (var i in list)
            {
                cbNameProd.Items.Add(i);
            }
            var listname = DataProvider.Ins.DB.ORIGINALITEMs.Select(x => x.NameItem).ToList();
            foreach (var i in listname)
            {
                cbNameItem.Items.Add(i);
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
