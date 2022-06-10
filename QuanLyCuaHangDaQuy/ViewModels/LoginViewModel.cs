using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Views.Admin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string _username;
        public string UserName { get => _username; set { _username = value; OnPropertyChanged(); } }
        private string _password;
        public string Password { get => _password; set { _password = value; OnPropertyChanged(); } }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<LoginWindow>((p) =>  true, (p) => {
                Login(p);
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => {
                Password = p.Password;
            });
        }
        //public static string MD5Hash(string input)
        //{
        //    StringBuilder hash = new StringBuilder();
        //    MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
        //    byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));
        //    for(int i=0; i<bytes.Length; i++)
        //    {
        //        hash.Append(bytes[i].ToString("x2"));
        //    }
        //    return hash.ToString();
        //}
        private void Login(LoginWindow p)
        {
            string passEncode = HashCode.MD5Hash(p.txtPassword.Password);
            if (p == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(p.txtUsername.Text))
            {
                MessageBox.Show("Please enter username!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                p.txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(p.txtPassword.Password))
            {
                MessageBox.Show("Please enter password!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                p.txtPassword.Focus();
                return;
            }
            var count = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.UserName == p.txtUsername.Text && x.Pass == passEncode).Count();
            var acc = DataProvider.Ins.DB.ACCOUNTs.Where(x => x.UserName == p.txtUsername.Text && x.Pass == passEncode).ToList();

            //MessageBox.Show("" + UserName + Password);
            if (count > 0)
            {
                foreach (var i in acc)
                {
                    if (i.AccType == "admin")
                    {
                        AdminWindow wd = new AdminWindow();
                        wd.Show();
                        p.Close();
                    }
                    else if (i.AccType=="staff")
                    {
                        MainStaffWindow wd = new MainStaffWindow();
                        wd.Show();
                        p.Close();
                    }
                }
            }
            else
            {
                 MessageBox.Show("Wrong username or password!", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
