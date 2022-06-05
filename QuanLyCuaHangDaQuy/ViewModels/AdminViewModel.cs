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

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
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

        public ICommand AddCommand { get; set; }

        private int menubar_flag = 0;

        private int Navigate_id;

        private string uid;
        public string Uid { get => uid; set => uid = value; }
        public AdminViewModel()
        { 
            SwitchMenuButton = new RelayCommand<AdminWindow>((p) => true, (p) => ScrollMenu(p));
            NavigateCommand = new RelayCommand<AdminWindow>((p) => true, (p) => Navigate(p));
            GetUidCommand = new RelayCommand<Button>((p) => true, (p) => Uid = p.Uid);
            MouseLeaveCommand = new RelayCommand<Button>(p => true, p => MouseLeave(p));
            AddCommand = new RelayCommand<AdminWindow>((p) => true, (p) => ChooseWindow(p));


            void ScrollMenu(AdminWindow window)
            {
                if (menubar_flag == 0)
                {
                    window.grdMenuButton.Width = 330;
                    window.MenuSrV.ScrollToHorizontalOffset(554);
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
            {
                int index = int.Parse(Uid);
                window.grHR.Visibility = Visibility.Collapsed;
                window.grProvider.Visibility = Visibility.Collapsed;
                window.grMaterial.Visibility = Visibility.Collapsed;
                window.grMaterial.Visibility=Visibility.Collapsed;
                window.grForm.Visibility = Visibility.Collapsed;

                window.btSearch.IsEnabled = false;
                window.btAdd.IsEnabled = false;
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
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 10;

                        window.SearchBar.DataContext = window.grHR.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 20:
                        window.btAccount.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true; Navigate_id = 20;
                        window.btSearch.IsEnabled = true;
                        break;
                    case 30:
                        window.btCustomer.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true; Navigate_id = 30;
                        window.btSearch.IsEnabled = true;
                        break;
                    case 40:
                        window.grProvider.Visibility = Visibility.Visible;
                        window.btProvider.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true; 
                        Navigate_id = 40;
                        window.SearchBar.DataContext = window.grProvider.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;
                    case 50:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility=Visibility.Visible;
                        window.btCatelogy.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        Navigate_id = 50;
                        window.btSearch.IsEnabled = false;
                        break;

                    case 60:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility = Visibility.Visible;
                        window.grMaterial.Visibility = Visibility.Visible;
                        window.btMaterial.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btMaterial.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 60;
                        window.SearchBar.DataContext = window.grMaterial.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;


                    case 70:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility = Visibility.Visible;
                        window.grForm.Visibility = Visibility.Visible;
                        window.btForm.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);                        
                        window.btForm.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 70;
                        window.SearchBar.DataContext = window.grForm.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                }

            }


            void ChooseWindow(AdminWindow window)
            {
                switch (Navigate_id)
                {
                    case 10:
                        HumanResourceEditWindow addHRWindow = new HumanResourceEditWindow();
                        addHRWindow.TxtbName.Text = null;
                        addHRWindow.TxtbEmail.Text = null;
                        addHRWindow.TxtbAddress.Text = null;
                        addHRWindow.TxtbPhone.Text = null;
                        addHRWindow.TxtbID.Text = null;
                        addHRWindow.cbSex.Text = null;
                        addHRWindow.dpDayOfBirth.Text = null;
                        addHRWindow.btSave.Content = "Create";
                        addHRWindow.ShowDialog();
                        break;
                    case 20:

                    case 30:

                        break;

                    case 40: 
                        ProviderManagerWindow providerManagerWindow = new ProviderManagerWindow();
                        providerManagerWindow.txtbName.Text = null;
                        providerManagerWindow.txtbPhone.Text = null;
                        providerManagerWindow.txtbAddress.Text = null;
                        providerManagerWindow.btSave.Content = "Create";
                        providerManagerWindow.ShowDialog();
                        break;


                    case 60:
                        MaterialCategoryManagerWindow materialCategoryManagerWindow= new MaterialCategoryManagerWindow();
                        materialCategoryManagerWindow.txtbName.Text = null;
                        materialCategoryManagerWindow.txtbProfit.Text = null;
                        materialCategoryManagerWindow.btSave.Content = "Create";
                        materialCategoryManagerWindow.ShowDialog();
                        break;

                    case 70:
                        FormCategoryManagerWindow formCategoryManagerWindow= new FormCategoryManagerWindow();
                        formCategoryManagerWindow.txtbName.Text = null;
                        formCategoryManagerWindow.btSave.Content = "Create";
                        formCategoryManagerWindow.ShowDialog();
                        break;


                }

            }

        }
    }
 }
