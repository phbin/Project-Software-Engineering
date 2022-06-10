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
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class AccountViewModel : BaseViewModel
    {
        public ObservableCollection<Account> ListAccount { get; set; } = new ObservableCollection<Account>();
        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(Username)); } }

        private string _fullname;
        public string Fullname { get { return _fullname; } set { _fullname = value; OnPropertyChanged(nameof(Fullname)); } }

        private string _pass;
        public string Pass { get { return _pass; } set { _pass = value; OnPropertyChanged(nameof(Pass)); } }

        private string _acctype;
        public string AccType { get { return _acctype; } set { _acctype = value; OnPropertyChanged(nameof(AccType)); } }

        public ICommand LoadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        private Account _selectedAccount;
        public Account SelectedAccount { get { return _selectedAccount; } set { _selectedAccount = value; OnPropertyChanged(nameof(SelectedAccount)); } }


        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public AccountViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());

            Account.EditCommand = new RelayCommand<object>((p) => true, (p) => OpenAccountManagerWindow());

            Account.DeleteCommand = new RelayCommand<object>((p) => true, (p) => Delete());

            UpdateCommand = new RelayCommand<object>((p) => true, (p) => UpdateAccount());
            CreateCommand = new RelayCommand<object>((p) => true, (p) => AddAccount());

        }
        public void Load()
        {
            ListAccount.Clear();
            var List = DataProvider.Ins.DB.ACCOUNTs.ToList();
            int no = 1;
            foreach (var item in List)
            {
               // var fullname = DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(x => x.ID == item.ID).FirstOrDefault().FullName;
                var Account = new Account
                {
                    Fullname = item.INFOSTAFF.FullName,
                    No = no,
                    ID = item.ID,
                    Username = item.UserName,
                    Pass = item.Pass,
                    AccType=item.AccType
                };
                ListAccount.Add(Account);
                no++;
            }
            if (no >= 2) { SelectedAccount = ListAccount[0]; }
        }

        private void UpdateAccount()
        {
            
            if (AccType.ToString() == null || Fullname.ToString()== null || Username == null || Pass == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
            var user = DataProvider.Ins.DB.ACCOUNTs.Select(x => x.UserName).ToList();
            var getID = DataProvider.Ins.DB.INFOSTAFFs.Where(x => x.FullName == Fullname).FirstOrDefault().ID;

            DataProvider.Ins.DB.ACCOUNTs.ToList().Where(h => h.ID == getID).FirstOrDefault().Pass = HashCode.MD5Hash(Pass);
            DataProvider.Ins.DB.ACCOUNTs.ToList().Where(h => h.ID == getID).FirstOrDefault().AccType = AccType;
            DataProvider.Ins.DB.SaveChanges();
            System.Windows.Application.Current.Windows[1].Close();
            LoadDataAfterTextSearch();
        }
        private void AddAccount()
        {

            if (Username == null || Pass == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
            var user = DataProvider.Ins.DB.ACCOUNTs.Select(x => x.UserName).ToList();

            var getID = DataProvider.Ins.DB.INFOSTAFFs.Where(x => x.FullName == Fullname).FirstOrDefault().ID;

            foreach (var i in user)
            {
                if (Username == i)
                {
                    System.Windows.MessageBox.Show("Username has been existed!");
                    Username = "";
                    return;
                }
            }
            //if(AccType==1) 
            DataProvider.Ins.DB.ACCOUNTs.Add(new ACCOUNT { AccType = AccType, UserName = Username, Pass = HashCode.MD5Hash(Pass), ID = getID });
            DataProvider.Ins.DB.SaveChanges();
            LoadDataAfterTextSearch();
        }
        private void Delete()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this account?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DataProvider.Ins.DB.ACCOUNTs.Remove(DataProvider.Ins.DB.ACCOUNTs.ToList().Where(h => h.ID == SelectedAccount.ID).FirstOrDefault());
                DataProvider.Ins.DB.SaveChanges();
                Load();
            }
        }

        private void LoadDataAfterTextSearch()
        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListAccount.Clear();
                var List = DataProvider.Ins.DB.ACCOUNTs.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    //var fullname = DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(x => x.ID == item.ID).FirstOrDefault().FullName;

                    if (item.UserName.Contains(TextSearch))
                    {
                        ListAccount.Add(new Account
                        {
                            No = no,
                            Fullname = item.INFOSTAFF.FullName,
                            ID = item.ID,
                            Username = item.UserName,
                            Pass = item.Pass,
                            AccType=item.AccType
                        });
                        no++;
                    }
                    if (no >= 2) { SelectedAccount = ListAccount[0]; }
                }
            }
        }
        private void OpenAccountManagerWindow()
        {
            AccountManagerWindow amw = new AccountManagerWindow();
            amw.textFullname.Text = SelectedAccount.Fullname.ToString();
            amw.textFullname.IsEnabled = false;
            amw.textUsername.Text = SelectedAccount.Username.ToString();
            amw.textUsername.IsEnabled = false;
            amw.textAccType.Text = SelectedAccount.AccType.ToString();
            amw.ShowDialog();
            amw.btnCreate.Visibility = Visibility.Hidden;
            amw.btnCreate.IsEnabled = false;
            amw.btSave.Visibility = Visibility.Visible;
        }
    }
}
