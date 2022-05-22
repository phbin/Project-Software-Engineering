using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.ViewModels;
using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Resources.UserControls;
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
using System.Collections.ObjectModel;
using QuanLyCuaHangDaQuy.Views.Admin;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {

        public ObservableCollection<INFOSTAFF> MyList = new ObservableCollection<INFOSTAFF>();


        private static AdminViewModel instance;
        public static AdminViewModel Instance
        {
            get { if (instance == null) instance = new AdminViewModel(); return AdminViewModel.instance; }
            private set { AdminViewModel.instance = value; }
        }

        public ICommand NavigateCommand { get; set; }
        public ICommand GetUidCommand { get; set; }
        public ICommand MouseLeaveCommand { get; set; }



        public ICommand SwitchMenuButton { get; set; }

        public ICommand OpenAddWindow { get; set; }

        private int menubar_flag = 0;

        private string uid;
        public string Uid { get => uid; set => uid = value; }
        public AdminViewModel()
        {
            MyList.Add(new INFOSTAFF { ID = "1", stt = 1, Addr = "sdsa", Phone = "213123", Sex = "fasd", Avatar = null, DoB = System.DateTime.Now, IDPersonal = 321312, Email = "dasdas" });

            SwitchMenuButton = new RelayCommand<AdminWindow>((p) => true, (p) => ScrollMenu(p));
            NavigateCommand = new RelayCommand<AdminWindow>((p) => true, (p) => Navigate(p));
            GetUidCommand = new RelayCommand<Button>((p) => true, (p) => Uid = p.Uid);
            MouseLeaveCommand = new RelayCommand<Button>(p => true, p => MouseLeave(p));
            OpenAddWindow = new RelayCommand<AdminWindow>((p) => true, (p) => ChooseAddWindow(p));


            void ScrollMenu(AdminWindow window)
            {
                if (menubar_flag == 0)
                {
                    window.MenuSrV.CanContentScroll = true;
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
                    window.MenuSrV.CanContentScroll = false;
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
            {
                int index = int.Parse(Uid);
                window.grHR.Visibility = Visibility.Collapsed;

                window.grAccount.Visibility = Visibility.Collapsed;
                window.grCustomer.Visibility = Visibility.Collapsed;
                window.grProvider.Visibility = Visibility.Collapsed;
                window.grMaterial.Visibility = Visibility.Collapsed;
                window.grMaterial.Visibility=Visibility.Collapsed;
                window.grForm.Visibility = Visibility.Collapsed;

                string backgr_enable = "#E0A645";
                string backgr_disable = "#585858";

                string foregr_enable = "#FFFFFF";

                window.btHR.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btAccount.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btCustomer.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btProvider.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btCatelogy.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btMaterial.Background = (Brush)new BrushConverter().ConvertFrom("#FFFFFF");
                window.btForm.Background = (Brush)new BrushConverter().ConvertFrom("#FFFFFF");
                window.btMaterial.Foreground = (Brush)new BrushConverter().ConvertFrom("#ABABAB");
                window.btForm.Foreground = (Brush)new BrushConverter().ConvertFrom("#ABABAB");

                window.btSwitchTableCatelogy.Visibility = Visibility.Collapsed;
                window.btAdd.Margin = new Thickness(0, 0, 0, 0);

                switch (index)
                {
                    case 10:
                        window.grHR.Visibility = Visibility.Visible;
                        window.btHR.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        HumanResourcesViewModel vm = new HumanResourcesViewModel();
                        vm.LoadToView(window);
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
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility=Visibility.Visible;
                        window.btCatelogy.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        break;

                    case 60:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility = Visibility.Visible;
                        window.grMaterial.Visibility = Visibility.Visible;
                        window.btMaterial.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btMaterial.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                        break;


                    case 70:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility = Visibility.Visible;
                        window.grForm.Visibility = Visibility.Visible;
                        window.btForm.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);                        
                        window.btForm.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                        break;

                }

            }


            void ChooseAddWindow(AdminWindow window)
            {
                int index = int.Parse(Uid);
                switch (index)
                {
                    case 10:

                        HumanResourcesViewModel humanresourcesVM=window.grHR.DataContext as HumanResourcesViewModel ;
                        humanresourcesVM.OpenHumanResourceEditWindow();
                        break;
                    case 20:
                        AccountViewModel accountVM = new AccountViewModel();
                        accountVM.OpenAccountManagertWindow();
                        break;

                    case 30:

                        break;

                    case 40: 
                        ProviderViewModel providerVM = new ProviderViewModel();
                        providerVM.OpenProviderManagertWindow();
                        break;


                    case 60:

                        break;

                    case 70:


                        break;


                }

            }

        }
    }
 }
