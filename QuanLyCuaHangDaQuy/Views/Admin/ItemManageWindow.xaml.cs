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

namespace QuanLyCuaHangDaQuy.Views.Admin
{
    /// <summary>
    /// Interaction logic for ItemManageWindow.xaml
    /// </summary>
    public partial class ItemManageWindow : Window
    {
        public ItemManageWindow()
        {
            InitializeComponent();
            var list = DataProvider.Ins.DB.MATERIALCATEGORies.Select(x => x.NameMaterial).ToList();
            foreach (var i in list)
            {
                cbNameMaterial.Items.Add(i);

            }
            list = DataProvider.Ins.DB.FORMCATEGORies.Select(x => x.NameForm).ToList();
            foreach (var i in list)
            {
                cbNameForm.Items.Add(i);

            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UpdateOriginalItem();
        }

        private void UpdateOriginalItem()
        {

            if (textName.Text == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
            var idform = DataProvider.Ins.DB.FORMCATEGORies.Where(x => x.NameForm == cbNameForm.Text).FirstOrDefault().ID;
            var idmaterial = DataProvider.Ins.DB.MATERIALCATEGORies.Where(x => x.NameMaterial == cbNameMaterial.Text).FirstOrDefault().ID;

            DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().NameItem = textName.Text;
            DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().IDForm = idform;
            DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().IDMaterial = idmaterial;
            DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Descript = textDescript.Text;
            //DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Picture = null;
            //DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().SellQty = Convert.ToInt32(textSellQty.Text.ToString());
            //DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Quantity = Convert.ToInt32(textQuantity.Text.ToString());
            //DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Price = Convert.ToInt32(textPrice.Text.ToString());

            //DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == SelectedItem.ID).FirstOrDefault().IDMaterial = idmaterial;
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
