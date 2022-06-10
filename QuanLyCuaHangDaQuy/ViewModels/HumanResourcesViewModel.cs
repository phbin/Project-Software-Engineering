using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Views.Admin;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class HumanResourcesViewModel : BaseViewModel
    {
        public ObservableCollection<Staff> ListStaff { get; set; } = new ObservableCollection<Staff>();
        private int isEdit = 0;

        private BitmapImage _bitmapImage;
        public BitmapImage BitmapImage
        {
            get { return _bitmapImage; }
            set { _bitmapImage = value; OnPropertyChanged(nameof(BitmapImage)); }
        }

        private byte[] _avatar;
        public byte[] Avatar
        {
            get { return _avatar; }
            set { _avatar = value; OnPropertyChanged(nameof(Avatar)); }
        }

        private string _fullname;
        public string FullName
        {
            get { return _fullname; }
            set { _fullname = value; OnPropertyChanged(nameof(FullName)); }
        }

        private string _sex;
        public string Sex
        {
            get { return _sex; }
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
                dialog.Title = "Choose a picture";
                dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(dialog.FileName);
                    bitmap.EndInit();
                    BitmapImage = bitmap;
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
            humanResourceInformationWindow.txtbPhoneNumber.Text = SelectedStaff.Phone.ToString();
            humanResourceInformationWindow.txtbDayOfBirth.Text = SelectedStaff.DoB.ToString();
            humanResourceInformationWindow.txtbPersonalID.Text = SelectedStaff.IDPersonal.ToString();
            humanResourceInformationWindow.txtbSex.Text = SelectedStaff.Sex.ToString();
            humanResourceInformationWindow.txtbAddress.Text = SelectedStaff.Addr.ToString();
            humanResourceInformationWindow.ProfileImage.ImageSource = ConvertImage.LoadImage(SelectedStaff.Avatar);
            humanResourceInformationWindow.ShowDialog();

        }
        public void Load()
        {
            ListStaff.Clear();
            var List = DataProvider.Ins.DB.INFOSTAFFs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                if (item.stt == 1)
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
                        Sex = item.Sex,
                        Avatar = item.Avatar
                    };
                    ListStaff.Add(Staff);
                    no++;
                }
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
                        if (item.stt == 1)
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
                                Sex = item.Sex,
                                Avatar = item.Avatar
                            });
                            no++;
                        }
                    }
                    if (no >= 2) { SelectedStaff = ListStaff[0]; }

                }
            }
        }

        public void OpenHumanResourceEditWindow()
        {
            HumanResourceEditWindow humanResourceEditWindow = new HumanResourceEditWindow();
            humanResourceEditWindow.TxtbName.Text = SelectedStaff.FullName.ToString();
            humanResourceEditWindow.TxtbEmail.Text = SelectedStaff.Email.ToString();
            humanResourceEditWindow.TxtbAddress.Text = SelectedStaff.Addr.ToString();
            humanResourceEditWindow.TxtbPhone.Text = SelectedStaff.Phone.ToString();
            humanResourceEditWindow.cbSex.Text = SelectedStaff.Sex.ToString();
            humanResourceEditWindow.dpDayOfBirth.Text = SelectedStaff.Dob_Format.ToString();
            humanResourceEditWindow.TxtbID.Text = SelectedStaff.IDPersonal.ToString();
            humanResourceEditWindow.textID.Text = SelectedStaff.ID.ToString();
            humanResourceEditWindow.ProfileImage.ImageSource = ConvertImage.LoadImage(SelectedStaff.Avatar);
            humanResourceEditWindow.btSave.Visibility = Visibility.Hidden;
            humanResourceEditWindow.btUpdate.Visibility = Visibility.Visible;
            humanResourceEditWindow.btSave.IsEnabled = false;
            humanResourceEditWindow.ShowDialog();
            LoadDataAfterTextSearch();
        }

        public void Delete()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this Staff?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bool canDelete = true;
                int count = DataProvider.Ins.DB.ITEMFORMs.ToList().Where(h => h.IDStaff == SelectedStaff.ID).Count();
                if (count >= 1)
                {
                    canDelete = false;
                }
                if (canDelete)
                {
                    int countACC = DataProvider.Ins.DB.ACCOUNTs.ToList().Where(h => h.ID == SelectedStaff.ID).Count();
                    while (countACC > 0)
                    {
                        DataProvider.Ins.DB.ACCOUNTs.Remove(DataProvider.Ins.DB.ACCOUNTs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault());
                        DataProvider.Ins.DB.SaveChanges();
                        countACC--;
                    }
                    DataProvider.Ins.DB.INFOSTAFFs.Remove(DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault());
                }
                else
                {
                    DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == SelectedStaff.ID).FirstOrDefault().stt = 0;
                }
            }
            DataProvider.Ins.DB.SaveChanges();
            LoadDataAfterTextSearch();
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
            if (FullName == null || Email == null || IDPersonal == null || DoB == null || Addr == null || Phone == null)
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
            if (Phone.Length < 10)
            {
                System.Windows.MessageBox.Show("Invalid Phone Number");
                Phone = "";
                return;
            }
            
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
                ID = "Staff" + (Temp).ToString(),
                FullName = FullName,
                DoB = DateTime.Parse(DoB, CultureInfo.InvariantCulture),
                Sex = Sex.ToString(),
                Addr = Addr,
                Phone = Phone,
                Email = Email,
                IDPersonal = long.Parse(IDPersonal),
                Avatar = Avatar,
                stt = 1
            });
            DataProvider.Ins.DB.SaveChanges();

            System.Windows.Application.Current.Windows[1].Close();
            LoadDataAfterTextSearch();

        }
    }
}
