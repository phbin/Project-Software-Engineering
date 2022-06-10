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
using System.Windows.Shapes;

namespace QuanLyCuaHangDaQuy.Views
{
    /// <summary>
    /// Interaction logic for AccountManagerWindow.xaml
    /// </summary>
    public partial class AccountManagerWindow : Window
    {

        public AccountManagerWindow()
        {
         
            InitializeComponent();
            //var List = DataProvider.Ins.DB.ACCOUNTs.ToList();

           var list = DataProvider.Ins.DB.INFOSTAFFs.Select(x => x.FullName).ToList();
            foreach (var i in list)
            {
                textFullname.Items.Add(i);
            }
            textAccType.Items.Add("admin");
            textAccType.Items.Add("staff");

            //list = DataProvider.Ins.DB.ACCOUNTs.Select(x => x.AccType).ToList();
            //foreach (var i in list)
            //{
            //    textAccType.Items.Add(i);

            //}
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
