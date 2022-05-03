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
    public class AdminViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; set; }
        public ICommand GetUidCommand { get; set; }
        public ICommand MouseLeaveCommand { get; set; }


        private string uid;
        public string Uid { get => uid; set => uid = value; }
        public AdminViewModel()
        {
            NavigateCommand = new RelayCommand<AdminWindow>((p) => true, (p) => Navigate(p));
            GetUidCommand = new RelayCommand<Button>((p) => true, (p) => Uid = p.Uid);

            NavigateCommand = new RelayCommand<AdminWindow>(p => true, p => Navigate(p));
            MouseLeaveCommand = new RelayCommand<Button>(p => true, p => MouseLeave(p));
        }
        void MouseLeave(Button btn)
        {
            if (btn.IsFocused)
            {
                return;
            }
        }
        public void Navigate(AdminWindow window)
        {
            int index = int.Parse(Uid);
            window.grHR.Visibility = Visibility.Collapsed;
            window.grCustomer.Visibility = Visibility.Collapsed;
            window.grDiscount.Visibility = Visibility.Collapsed;
            window.grProduct.Visibility = Visibility.Collapsed;
            window.grImportation.Visibility = Visibility.Collapsed;
            window.grService.Visibility= Visibility.Collapsed;

            string backgr_enable= "#E0A645";
            string backgr_disable = "#585858";

            window.btHR.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
            window.btProduct.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
            window.btCustomer.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
            window.btService.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
            window.btImportation.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
            window.btDiscount.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);

            switch (index)
            {
                case 10:
                    window.grHR.Visibility = Visibility.Visible;
                    window.btHR.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                    break;
                case 20:
                    window.grProduct.Visibility = Visibility.Visible;
                    window.btProduct.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                    break;
                case 30:
                    window.grCustomer.Visibility = Visibility.Visible;
                    window.btCustomer.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                    break;
                //case 40:
                     //window.grService.Visibility = Visibility.Visible;
                     //window.btService.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                     //break;
                case 50:
                    window.grImportation.Visibility = Visibility.Visible;
                    window.btImportation.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                   break;
                case 60:
                    window.grDiscount.Visibility = Visibility.Visible;
                    window.btDiscount.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                    break;

            }

        }
    }
}
