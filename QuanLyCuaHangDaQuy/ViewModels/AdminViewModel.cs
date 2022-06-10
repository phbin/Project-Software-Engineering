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
using System.Windows.Media.Imaging;
using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Views.Admin;
using QuanLyCuaHangDaQuy.Views.Admin.Admin_ImportedItems;
using QuanLyCuaHangDaQuy.Views.Admin.Admin_Service;
using QuanLyCuaHangDaQuy.Views.Staff.Staff_Customer;

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
                    window.grdMenuButton.Width = 570;
                    window.MenuSrV.ScrollToHorizontalOffset(640);
                    window.IconSwitchBt.Kind = PackIconKind.ChevronLeft;
                    menubar_flag = 1;
                }
                else if (menubar_flag == 1)
                {

                    //MessageBox.Show(window.MenuSrV.HorizontalOffset.ToString());
                    window.grdMenuButton.Width = 632;
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

                window.grAccount.Visibility = Visibility.Collapsed;
                
                window.grProvider.Visibility = Visibility.Collapsed;
                window.grMaterial.Visibility = Visibility.Collapsed;
                window.Customer.Visibility = Visibility.Collapsed;
                window.grForm.Visibility = Visibility.Collapsed;
                window.grUnit.Visibility = Visibility.Collapsed;
                window.grItem.Visibility = Visibility.Collapsed;
                window.grImportedItem.Visibility = Visibility.Collapsed;
                window.grService.Visibility = Visibility.Collapsed;
                window.Report.Visibility = Visibility.Collapsed;
                window.grInventory.Visibility = Visibility.Collapsed;
                //window.grImportedItem.Visibility = Visibility.Collapsed;

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
                window.btUnit.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btUnit.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                window.btOriginalItem.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                window.btOriginalItem.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btService.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btReport.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btImportedItem.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);
                window.btInventory.Background = (Brush)new BrushConverter().ConvertFrom(backgr_disable);

                window.btSwitchTableCatelogy.Visibility = Visibility.Collapsed;
                window.btAdd.Margin = new Thickness(0, 0, 0, 0);
                window.Toolbar.Visibility = Visibility.Visible;
                window.Report.Margin = new Thickness(0, 0, 0, 0);

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
                        window.grAccount.Visibility = Visibility.Visible;
                        window.btAccount.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true; 
                        Navigate_id = 20;
                        window.SearchBar.DataContext = window.grAccount.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 30:
                        window.btCustomer.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.Customer.Visibility = Visibility.Visible;
                        window.Toolbar.Visibility = Visibility.Collapsed;
                        window.Customer.Margin = new Thickness(-17, 0, -17, -17);
                        window.Customer.Width = 1060;
                        break;

                    case 40:
                        window.grUnit.Visibility = Visibility.Visible;
                        window.btUnit.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 40;
                        window.SearchBar.DataContext = window.grUnit.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 50:
                        window.grItem.Visibility = Visibility.Visible;
                        window.btOriginalItem.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 50;
                        window.SearchBar.DataContext = window.grItem.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;


                    case 60:
                        window.grImportedItem.Visibility = Visibility.Visible;
                        window.btImportedItem.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 60;
                        window.SearchBar.DataContext = window.grImportedItem.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 70:
                        window.grProvider.Visibility = Visibility.Visible;
                        window.btProvider.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 70;
                        window.SearchBar.DataContext = window.grProvider.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 80:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility = Visibility.Visible;
                        window.btCatelogy.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        Navigate_id = 80;
                        window.btSearch.IsEnabled = false;
                        break;

                    case 90:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility = Visibility.Visible;
                        window.grMaterial.Visibility = Visibility.Visible;
                        window.btCatelogy.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btMaterial.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btMaterial.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 90;
                        window.SearchBar.DataContext = window.grMaterial.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;


                    case 100:
                        window.btAdd.Margin = new Thickness(180, 0, 0, 0);
                        window.btSwitchTableCatelogy.Visibility = Visibility.Visible;
                        window.grForm.Visibility = Visibility.Visible;
                        window.btCatelogy.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btForm.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btForm.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 100;
                        window.SearchBar.DataContext = window.grForm.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 110:
                        //grInvetory
                        window.grInventory.Visibility= Visibility.Visible;
                        window.btInventory.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.grInventory.Margin = new Thickness(0, -65, 0, 0);
                        window.btAdd.IsEnabled = true;
                        window.Toolbar.Visibility= Visibility.Hidden;
                        Navigate_id = 110;
                        window.SearchBar.DataContext = window.grInventory.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 120:
                        window.grService.Visibility = Visibility.Visible;
                        window.btService.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btAdd.IsEnabled = true;
                        Navigate_id = 120;
                        window.SearchBar.DataContext = window.grService.DataContext;
                        window.btSearch.IsEnabled = true;
                        break;

                    case 130:
                        window.Report.Visibility = Visibility.Visible;
                        window.btReport.Background = (Brush)new BrushConverter().ConvertFrom(backgr_enable);
                        window.btReport.Foreground = (Brush)new BrushConverter().ConvertFrom(foregr_enable);

                        window.Toolbar.Visibility = Visibility.Collapsed;
                        window.Report.Margin = new Thickness(-17, -78, -17, -17);
                        break;

                }

            }


            void ChooseWindow(AdminWindow window)
            {
                switch (Navigate_id)
                {
                    case 10:
                        Views.Admin.HumanResourceEditWindow addHRWindow = new Views.Admin.HumanResourceEditWindow();
                        //addHRWindow.ProfileImage.ImageSource = new BitmapImage(new Uri(@"../../Resources/Images/b.jpg", UriKind.RelativeOrAbsolute));
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
                        AccountManagerWindow addAccountWindow = new AccountManagerWindow();
                        //addHRWindow.ProfileImage.ImageSource = new BitmapImage(new Uri(@"../../Resources/Images/b.jpg", UriKind.RelativeOrAbsolute));
                        addAccountWindow.textFullname.Text = null;
                        addAccountWindow.textPassword.Text = null;
                        addAccountWindow.textAccType.Text = "0";
                        addAccountWindow.textUsername.Text = null;
                        addAccountWindow.btnCreate.Visibility = Visibility.Visible;
                        addAccountWindow.btSave.Visibility = Visibility.Hidden;
                        addAccountWindow.btSave.IsEnabled = false;
                        addAccountWindow.ShowDialog();
                        break;
                  
                    case 30:
                        Staff_AddCustomer staff_AddCustomer = new Staff_AddCustomer();
                        staff_AddCustomer.ShowDialog();
                        break;

                    case 40:
                        UnitManageWindow addUnit = new UnitManageWindow();
                        addUnit.textNameUnit.Text = null;
                        addUnit.textID.Text = null;
                        addUnit.btnCreate.Visibility = Visibility.Visible;
                        addUnit.btSave.Visibility = Visibility.Hidden;
                        addUnit.btSave.IsEnabled = false;

                        addUnit.ShowDialog();
                        break;


                    case 50:
                        ItemManageWindow addItem = new ItemManageWindow();
                        addItem.textName.Text = null;
                        addItem.textID.Text = "ID";
                        addItem.textDescript.Text = null;
                        addItem.textPrice.Text = null;
                        addItem.textQuantity.Text = null;
                        addItem.textSellQty.Text = null;
                        addItem.cbNameForm.Text = null;
                        addItem.cbNameMaterial.Text = null;
                        addItem.imgPicture.ImageSource = null;

                        addItem.btnCreate.Visibility = Visibility.Visible;
                        addItem.btSave.Visibility = Visibility.Hidden;
                        addItem.btSave.IsEnabled = false;

                        addItem.ShowDialog();
                        break;

                    case 60:
                        Admin_AddReceipt admin_AddReceipt = new Admin_AddReceipt();
                        admin_AddReceipt.ShowDialog();
                        break;

                    case 70:
                        ProviderManagerWindow providerManagerWindow = new ProviderManagerWindow();
                        providerManagerWindow.txtbName.Text = null;
                        providerManagerWindow.txtbPhone.Text = null;
                        providerManagerWindow.txtbAddress.Text = null;
                        providerManagerWindow.btSave.Content = "Create";
                        providerManagerWindow.ShowDialog();
                        break;

                    case 90:
                        MaterialCategoryManagerWindow materialCategoryManagerWindow = new MaterialCategoryManagerWindow();
                        materialCategoryManagerWindow.btSave.Content = "Create";
                        materialCategoryManagerWindow.ShowDialog();
                        break;

                    case 100:
                        FormCategoryManagerWindow formCategoryManagerWindow = new FormCategoryManagerWindow();
                        formCategoryManagerWindow.txtbName.Text = null;
                        formCategoryManagerWindow.btSave.Content = "Create";
                        formCategoryManagerWindow.ShowDialog();
                        break;

                    case 110:
                       
                        //TextSearch = "";
                        //ListReceipt.Clear();
                        //LoadData();
                        break;

                    
                    case 120:
                        Admin_AddService addService = new Admin_AddService();
                        addService.ShowDialog();
                        //TextSearch = "";
                        //ListReceipt.Clear();
                        //LoadData();
                        break;


                }

            }

        }
    }
}
