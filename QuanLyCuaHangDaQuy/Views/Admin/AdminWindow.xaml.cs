using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace QuanLyCuaHangDaQuy.Views.Admin
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        void Load()
        {
            //List<Inventory> list = new List<Inventory>();

            //datePicker.SelectedDate = DateTime.Now.ToString();
            //MessageBox.Show("" + datePicker.Text);
            //DateTime? selectedDate = datePicker.SelectedDate;
            //string format = selectedDate.Value.ToString("MM/yyyy");

            //var originalItem = DataProvider.Ins.DB.ORIGINALITEMs.ToList();
            //var importedItem = DataProvider.Ins.DB.IMPORTEDITEMS.ToList();
            //var itembillform = DataProvider.Ins.DB.ITEMBILLFORMs.ToList();
            //int? sum = 0;

            //foreach (var item in importedItem)
            //{
            //    if (item.DatePurchase.ToString("MM/yyyy") == format)
            //    {
            //        //var result = DataProvider.Ins.DB.IMPORTEDITEMS
            //        //            .GroupBy(i => i.IDOrgItem)
            //        //            .Select(group => new
            //        //            {
            //        //                sum = group.Sum(g => g.Quantity)
            //        //            });
            //        int no = 1;
            //        foreach (var ii in importedItem)
            //        {
            //            //var id = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.IDOrgItem == ii.IDOrgItem);
            //            //foreach (var i in id)
            //            //{
            //            //    sum = sum + i.Quantity;
            //            //}
            //            //MessageBox.Show(""+sum);
            //            //var nameMaterial = DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(x => x.ID == item.IDMaterial).FirstOrDefault().NameMaterial;
            //            //var nameForm = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(x => x.ID == item.IDForm).FirstOrDefault().NameForm;
            //            var inv = new Inventory
            //            {
            //                No = no,
            //                Name = ii.ORIGINALITEM.NameItem,
            //                Opening = ii.ID,
            //                QtyPurchased = sum,  // so luong mua vao getmonth() tinh tong
            //                QtySold = ii.ORIGINALITEM.SellQty,
            //                Unit = ii.ORIGINALITEM.MATERIALCATEGORY.UNIT.NameUnit,
            //                Closing = ii.IDOrgItem
            //            };
            //            list.Add(inv);
            //            no++;
            //            sum = 0;
            //        }
            //        ListInventory.ItemsSource = list;
            //    }
            //    else return;
            //}
        }
        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        private void btnExportInventory_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
