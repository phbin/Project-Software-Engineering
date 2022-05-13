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
using MaterialDesignThemes.Wpf;


namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        public ICommand NavigateCommand { get; set; }
        public ICommand GetUidCommand { get; set; }
        public ICommand MouseLeaveCommand { get; set; }

        private int menubar_flag = 0;

        public ICommand SwitchMenuButton { get; set; }

        private string uid;
        public string Uid { get => uid; set => uid = value; }
        public AdminViewModel()
        {

            SwitchMenuButton = new RelayCommand<AdminWindow>((p) => true, (p) => ScrollMenu(p));
            NavigateCommand = new RelayCommand<AdminWindow>((p) => true, (p) => Navigate(p));
            GetUidCommand = new RelayCommand<Button>((p) => true, (p) => Uid = p.Uid);

            NavigateCommand = new RelayCommand<AdminWindow>(p => true, p => Navigate(p));
            MouseLeaveCommand = new RelayCommand<Button>(p => true, p => MouseLeave(p));
        

        void ScrollMenu(AdminWindow window)
            {
                if (menubar_flag == 0)
                {
                    window.grdMenuButton.Width = 330;
                    window.MenuSrV.ScrollToHorizontalOffset(5);
                    window.IconSwitchBt.Kind = PackIconKind.ChevronLeft;

                    menubar_flag = 1;
                }
                else if (menubar_flag == 1)
                {
                    window.grdMenuButton.Width = 550;
                    window.MenuSrV.ScrollToHome();
                    window.IconSwitchBt.Kind = PackIconKind.ChevronRight;
                    menubar_flag = 0;
                }



            }
            void MouseLeave(Button btn)
            {
                if (btn.IsFocused)
                {
                    return;
                }
            }

            void Navigate(AdminWindow window)
            {    int index = int.Parse(Uid);
                window.grHR.Visibility = Visibility.Collapsed;

                window.grAccount.Visibility= Visibility.Collapsed;
                window.grCustomer.Visibility = Visibility.Collapsed;
                window.grProvider.Visibility = Visibility.Collapsed;
                window.grMaterial.Visibility = Visibility.Collapsed;


                string backgr_enable = "#E0A645";
                string backgr_disable = "#585858";

                window.btHR.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btAccount.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btCustomer.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btProvider.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btCatelogy.Background=(Brush)new BrushConverter().ConvertFrom(backgr_disable);


                switch (index)
                {
                    case 10:
                        window.grHR.Visibility = Visibility.Visible;
                        window.btHR.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        break;
                    case 20:
                        window.grAccount.Visibility = Visibility.Visible;
                        window.btAccount.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        break;
                    case 30:
                        window.grCustomer.Visibility = Visibility.Visible;
                        window.btCustomer.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        break;
                    case 40:
                        window.grProvider.Visibility = Visibility.Visible;
                        window.btProvider.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        break;
                    case 50:
                        window.grMaterial.Visibility = Visibility.Visible;
                        window.btCatelogy.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        break;

                }

            }
        }
    }
}
