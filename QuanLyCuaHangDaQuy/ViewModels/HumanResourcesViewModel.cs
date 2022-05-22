using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.ViewModels;
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
using System.Windows.Data;
using System.Data;
using System.Collections.ObjectModel;
using QuanLyCuaHangDaQuy.Views.Admin;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class HumanResourcesViewModel : BaseViewModel
    {
        private ObservableCollection<INFOSTAFF> _ListStaff;
        public ObservableCollection<INFOSTAFF> ListStaff { get => _ListStaff; set { _ListStaff = value; OnPropertyChanged(); } }
       
        private static HumanResourcesViewModel instance;
     
        public static HumanResourcesViewModel Instance
        {
            get { if (instance == null) instance = new HumanResourcesViewModel(); return HumanResourcesViewModel.instance; }
            private set { HumanResourcesViewModel.instance = value; }
        }

        private string _Fullname { get; set; }
        public string Fullname { get => _Fullname; set { _Fullname = value; OnPropertyChanged(); }}

        private string _DoB { get; set; }
        public string DoB { get => _DoB; set { _DoB = value; OnPropertyChanged(); } }


        private string _Address { get; set; }
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _PhoneNumber { get; set; }
        public string PhoneNumber { get => _PhoneNumber; set { _PhoneNumber = value; OnPropertyChanged(); } }
        private string _Email { get; set; }
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _ID { get; set; }
        public string ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }

        //HRWindow

        //to adminwindow
        public ICommand LoadCommand { get; set; }


        //Add/EditStaff
        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        

        public HumanResourcesViewModel()
        {
            ListStaff = new ObservableCollection<INFOSTAFF>();//DataProvider.Ins.DB.INFOSTAFFs);
            LoadCommand = new RelayCommand<AdminWindow>((p) => true, (p) => LoadToView(p));
            EditCommand = new RelayCommand<HumanResourceEditWindow>((p) => true, (p) => OpenHumanResourceEditWindow(1));
            SaveCommand = new RelayCommand<HumanResourceEditWindow>((p) => true, (p) => AddOrUpdateStaff(p));
        }
        public void OpenHumanResourceEditWindow(int flag=0)
        {
            if (flag == 0)
            {
                HumanResourceEditWindow addHRWindow = new HumanResourceEditWindow
                {
                    TxtbName = null,
                    TxtbEmail = null,
                    TxtbID = null,
                    dpDayOfBirth = null,
                    TxtbAddress = null,
                    cbSex = null
                };
                addHRWindow.btSave.Content = "Create";
                addHRWindow.ShowDialog();
            }
            else if (flag == 1)
            {

            }
            

        }
        //public void load(AdminWindow)
        public void LoadToView(AdminWindow adminWindow)
        {
            adminWindow.stkHR.Children.Clear();
            
            for (int i=0; i < ListStaff.Count; i++)
            {
                HumanResourceControl control = new HumanResourceControl();
                control.txtbName.Text = ListStaff[i].FullName;
                control.txtbPhoneNumber.Text= ListStaff[i].Phone;
                control.txtbIDNumber.Text = ListStaff[i].ID;
                control.txtbNumber.Text =  (i+1).ToString();
                adminWindow.stkHR.Children.Add(control);
            }    
        }

        void AddOrUpdateStaff(HumanResourceEditWindow editWindow)
        {
             var Staff = new INFOSTAFF() { FullName = Fullname, DoB = System.DateTime.Now, Sex = "Male", Addr = Address, Phone = PhoneNumber, Email = Email, IDPersonal = int.Parse(ID) };

            //DataProvider.Ins.DB.INFOSTAFFs.Add(Staff);
            //DataProvider.Ins.DB.SaveChanges();

            ListStaff.Add(Staff);
            editWindow.Close();
        }



    }


}
