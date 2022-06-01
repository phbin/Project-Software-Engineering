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
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Data;
using System.Data;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class HumanResourcesViewModel : BaseViewModel
    {
        public ObservableCollection<Staff> ListStaff { get; set; } = new ObservableCollection<Staff>();

        private int isEdit = 0;
        private string imgLocation = "";
        private string _fullname;
        public string FullName 
        { 
            get { return _fullname; }
            set { _fullname = value; OnPropertyChanged(nameof(FullName)); }
        }

        private string _sex;
        public string Sex 
        {   get { return _sex; }
            set { _sex = value; OnPropertyChanged(nameof(Sex)); }
        }

        private string _iD;
        public string ID
        {
            get { return _iD; }
            set { _iD = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _addr;

        public string Addr
        {
            get { return _addr; }
            set { _addr = value; OnPropertyChanged(nameof(Addr)); }
        }

        private string _dob;
        public string DoB { get { return _dob; } set { _dob = value; OnPropertyChanged(nameof(DoB)); } }

        private string _iDPersonal;

        public string IDPersonal
        {
            get { return _iDPersonal; }
            set { _iDPersonal = value; OnPropertyChanged(nameof(IDPersonal)); }
        }

        private Staff _selectedStaff;
        public Staff SelectedStaff
        {
            get { return _selectedStaff; }
            set { _selectedStaff = value; OnPropertyChanged(nameof(SelectedStaff)); }
        }

        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }

        //HRWindow
        public ICommand OpenInformationWindowCommand { get; set; }

        //to adminwindow
        public ICommand LoadCommand { get; set; }

        public ICommand BrowseImageCommand { get; set; }
        //Add/EditStaff
        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }


        public HumanResourcesViewModel()
        {

            OpenInformationWindowCommand = new RelayCommand<object>((p) => true, (p) => OpenHumanResourceInformationWindow());

            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());

            BrowseImageCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "png file(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|(*.*)";
                dialog.ShowDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imgLocation=dialog.FileName.ToString();
                    
                }    
            });

            Staff.EditCommand = new RelayCommand<object>((p) => true, (p) => OpenHumanResourceEditWindow());

            Staff.DeleteCommand = new RelayCommand<object>((p) => true, (p) => Delete());

            SaveCommand = new RelayCommand<object>((p) => true, (p) => AddOrUpdateStaff());
        }
        public void OpenHumanResourceInformationWindow()
        {
            HumanResourceInformationWindow humanResourceInformationWindow = new HumanResourceInformationWindow();
            humanResourceInformationWindow.txtbName.Text = SelectedStaff.FullName.ToString();
            humanResourceInformationWindow.txtbEmail.Text = SelectedStaff.Email.ToString();
            humanResourceInformationWindow.txtbPhoneNumber.Text=SelectedStaff.Phone.ToString();
            humanResourceInformationWindow.txtbDayOfBirth.Text = SelectedStaff.DoB.ToString();
            humanResourceInformationWindow.txtbPersonalID.Text=SelectedStaff.IDPersonal.ToString();
            humanResourceInformationWindow.txtbSex.Text=SelectedStaff.Sex.ToString();
            humanResourceInformationWindow.txtbAddress.Text=SelectedStaff.Addr.ToString();
            humanResourceInformationWindow.ShowDialog();
        }    
        public void Load()
        {
            ListStaff.Clear();
            var List = DataProvider.Ins.DB.INFOSTAFFs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                var Staff = new Staff
                {
                    No = no,
                    DoB = item.DoB,
                    Dob_Format = item.DoB.ToShortDateString(),
                    FullName = item.FullName,
                    ID = item.ID,
                    IDPersonal = item.IDPersonal,
                    Phone = item.Phone,
                    Email = item.Email,
                    Addr = item.Addr,
                    Sex = item.Sex
                };
                ListStaff.Add(Staff);
                no++;
            }
            if (no >= 2) { SelectedStaff = ListStaff[0]; }
        }
        public void LoadDataAfterTextSearch()

        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListStaff.Clear();
                var List = DataProvider.Ins.DB.INFOSTAFFs.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    if (item.FullName.Contains(TextSearch))
                    {
                        ListStaff.Add(new Staff
                        {
                            No = no,
                            DoB = item.DoB,
                            Dob_Format = item.DoB.ToShortDateString(),
                            FullName = item.FullName,
                            ID = item.ID,
                            IDPersonal = item.IDPersonal,
                            Phone = item.Phone,
                            Email = item.Email,
                            Addr = item.Addr,
                            Sex = item.Sex
                        });
                        no++;
                    }
                    if (no >= 2) { SelectedStaff = ListStaff[0]; }

                }
            }
        }

        public void OpenHumanResourceEditWindow()
        {
            HumanResourceEditWindow humanResourceEditWindow = new HumanResourceEditWindow();
            isEdit = 1;
            humanResourceEditWindow.TxtbName.Text = SelectedStaff.FullName.ToString();
            humanResourceEditWindow.TxtbEmail.Text = SelectedStaff.Email.ToString();
            humanResourceEditWindow.TxtbAddress.Text = SelectedStaff.Addr.ToString();
            humanResourceEditWindow.TxtbPhone.Text = SelectedStaff.Phone.ToString();
            humanResourceEditWindow.cbSex.Text = SelectedStaff.Sex.ToString();
            humanResourceEditWindow.dpDayOfBirth.Text = SelectedStaff.Dob_Format.ToString();
            humanResourceEditWindow.TxtbID.Text = SelectedStaff.IDPersonal.ToString();
            humanResourceEditWindow.ShowDialog();
            LoadDataAfterTextSearch();
        }

        public void Delete()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this customer?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
            //if (result == System.Windows.Forms.DialogResult.Yes)
            //{
            //    int IDtemp = DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.IDCustomer == SelectedStaff.ID).Count();
            //    while (IDtemp >= 1)
            //    {
            //        string IDItemform = DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.IDCustomer == SelectedStaff.ID).FirstOrDefault().ID;
            //        int IDtemp1 = DataProvider.Ins.DB.ITEMS.ToList().Where(h => h.IDItemForm == IDItemform).Count();
            //        while (IDtemp1 >= 1)
            //        {
            //            DataProvider.Ins.DB.ITEMS.Remove(DataProvider.Ins.DB.ITEMS.Where(h => h.IDItemForm == IDItemform).FirstOrDefault());
            //            IDtemp1--;
            //        }
            //        DataProvider.Ins.DB.ITEMFORMs.Remove(DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.IDCustomer == SelectedStaff.ID).FirstOrDefault());
            //        IDtemp--;

            //    }
            //    IDtemp = DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.IDCustomer == SelectedStaff.ID).Count();
            //    while (IDtemp >= 1)
            //    {
            //        string IDService = DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.IDCustomer == SelectedStaff.ID).FirstOrDefault().ID;
            //        int IDtemp1 = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h => h.IDService == IDService).Count();
            //        while (IDtemp1 >= 1)
            //        {
            //            DataProvider.Ins.DB.SERVICELISTs.Remove(DataProvider.Ins.DB.SERVICELISTs.Where(h => h.IDService == IDService).FirstOrDefault());
            //            IDtemp1--;
            //        }
            //        DataProvider.Ins.DB.CUSSERVICEs.Remove(DataProvider.Ins.DB.CUSSERVICEs.ToList().Where(h => h.IDCustomer == SelectedStaff.ID).FirstOrDefault());
            //        IDtemp--;

            //    }
            //    DataProvider.Ins.DB.INFOCUSTOMERs.Remove(DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault());
            //    DataProvider.Ins.DB.SaveChanges();
            //    LoadDataAfterTextSearch();
            //}
        }
        bool IsValidEmail(string eMail)
        {
            bool Result = false;

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(eMail);

                Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
            }
            catch
            {
                Result = false;
            };

            return Result;
        }
        void AddOrUpdateStaff()
        {
            if(FullName == null || Email== null|| IDPersonal == null || DoB == null || Addr == null || Phone == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
            if (IsValidEmail(Email) == false)
            {
                System.Windows.MessageBox.Show("Invalid Email");
                return;
            }
            if (IDPersonal.Length >= 20)
            {
                System.Windows.MessageBox.Show("ID Personal too long");
                ID = "";
                return;
            }
            if (Phone.Length <10)
            {
                System.Windows.MessageBox.Show("Invalid Phone Number");
                Phone = "";
                return;
            }
            
            if (isEdit == 1)
            {
                if (SelectedStaff.IDPersonal != long.Parse(IDPersonal))
                {
                    var List = DataProvider.Ins.DB.INFOSTAFFs.ToList();
                    foreach (var item in List)
                    {
                        if (item.IDPersonal == long.Parse(IDPersonal) && item.ID != SelectedStaff.ID)
                        {
                            System.Windows.MessageBox.Show("ID Personal already exists");
                            IDPersonal = "";
                            return;
                        }
                    }
                }    
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault().Phone = Phone;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault().Email = Email;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault().Addr = Addr;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault().FullName = FullName;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault().IDPersonal = long.Parse(IDPersonal);
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault().DoB = DateTime.Parse(DoB, CultureInfo.InvariantCulture);
                DataProvider.Ins.DB.SaveChanges();
            }
            else
            {
                var List = DataProvider.Ins.DB.INFOSTAFFs.ToList();
                foreach (var item in List)
                {
                    if (item.IDPersonal == long.Parse(IDPersonal) && item.ID != SelectedStaff.ID)
                    {
                        System.Windows.MessageBox.Show("ID Personal already exists");
                        IDPersonal = "";
                        return;
                    }
                }
                bool Flag = false;
                int Temp = 0;
                while (Flag == false)
                {
                    Temp++;
                    if (DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == "Staff" + (Temp).ToString()).FirstOrDefault() == null)
                    {
                        Flag = true;
                    }
                }
                DataProvider.Ins.DB.INFOSTAFFs.Add(new INFOSTAFF 
                { 
                    DoB = DateTime.Parse(DoB, CultureInfo.InvariantCulture),
                    Phone = Phone, 
                    IDPersonal = long.Parse(IDPersonal), 
                    FullName = FullName, 
                    Addr = Addr, 
                    Email = Email, 
                    Sex= Sex,
                    ID = "Staff" + (Temp).ToString(), 
                    stt = 1 
                });
                DataProvider.Ins.DB.SaveChanges();

            }
            isEdit = 0;
            System.Windows.Application.Current.Windows[1].Close();
            LoadDataAfterTextSearch();
        }





    }


}
