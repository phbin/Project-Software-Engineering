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
        private Button bla;
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

            string backgr = "#E0A645";


            switch (index)
            {
                case 10:
                    window.grHR.Visibility = Visibility.Visible;
                    window.btHR.Foreground = (Brush)new BrushConverter().ConvertFrom(backgr);
                    break;
                case 20:
                    window.grProduct.Visibility = Visibility.Visible;
                    window.btProduct.Foreground = (Brush)new BrushConverter().ConvertFrom(backgr);
                    break;
                case 30:
                    window.grCustomer.Visibility = Visibility.Visible;
                    window.btCustomer.Foreground = (Brush)new BrushConverter().ConvertFrom(backgr);
                    break;
                //case 40:
                //    window.grService.Visibility = Visibility.Visible;
                //    window.btService.Foreground = (Brush)new BrushConverter().ConvertFrom(backgr);
                //    break;
                //case 50:
                //    window.grImportation.Visibility = Visibility.Visible;
                //    window.btImportation.Foreground = (Brush)new BrushConverter().ConvertFrom(backgr);
                //    break;
                case 60:
                    window.grDiscount.Visibility = Visibility.Visible;
                    window.btDiscount.Foreground = (Brush)new BrushConverter().ConvertFrom(backgr);
                    break;
            }

        }
    }
}
