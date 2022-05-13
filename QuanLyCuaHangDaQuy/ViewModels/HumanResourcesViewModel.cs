using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class HumanResourcesViewModel : BaseViewModel
    {
        private string uid;
        public string Uid { get => uid; set => uid = value; }

        public ICommand GetUidCommand { get; set; }
        public ICommand IsTextBoxEmpty { get; set; }
        public HumanResourcesViewModel()
        {
        }
    }


}
