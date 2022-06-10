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
    /// Interaction logic for UnitManageWindow.xaml
    /// </summary>
    public partial class UnitManageWindow : Window
    {
        public UnitManageWindow()
        {
            InitializeComponent();
        }
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            UpdateUnit();
            this.Close();
        }
        private void UpdateUnit()
        {
            if (textNameUnit.Text.ToString() == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the info rmation");
                return;
            }
            //var user = DataProvider.Ins.DB.ACCOUNTs.Select(x => x.UserName).ToList();
            MessageBox.Show("" + textID.Text);
            DataProvider.Ins.DB.UNITs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().NameUnit = textNameUnit.Text;
            DataProvider.Ins.DB.SaveChanges();
            System.Windows.Application.Current.Windows[1].Close();
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
