using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        public ControlBarUC()
        {
            InitializeComponent();
        }
        //private void ShowFormLogin()
        //{
        //    LoginWindow frmLogin = new LoginWindow();
        //    frmLogin.Show();
        //}
        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    Thread thread = new Thread(new ThreadStart(ShowFormLogin)); //Create new thread 
        //    thread.Start(); //Start thread
        //    LoginWindow frmLogin = new LoginWindow();
        //    frmLogin.Show();
        //    this.Close(); //Close current form
        //}
    }
}
