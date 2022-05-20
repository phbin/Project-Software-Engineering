using QuanLyCuaHangDaQuy.Model;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_AddCustomerVM : BaseViewModel
    {
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }
        private string _points ;
        public string Points
        {
            get { return _points; }
            set { _points = value; OnPropertyChanged(nameof(Points)); }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }
        private string _birthDay;

        public string Birthday
        {
            get { return _birthDay; }
            set { _birthDay = value; OnPropertyChanged(nameof(Birthday)); }
        }
        private string _iDPersonal;

        public string IDPersonal
        {
            get { return _iDPersonal; }
            set { _iDPersonal = value; OnPropertyChanged(nameof(IDPersonal)); }
        }
        //Email
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
        public ICommand AddCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public Staff_AddCustomerVM()
        {
            LoadedCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                 Points = "0";
             }
         );
            AddCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   if (FullName == "" || Email == "" || Phone == "" || Birthday == "" || Points == "" || IDPersonal == "")
                   {
                       MessageBox.Show("Please fill in all the information");
                       return;
                   }
                   if (IsValidEmail(Email) == false)
                   {
                       MessageBox.Show("Email invalidate");
                       return;
                   }
                   int Result;
                   if (int.TryParse(IDPersonal, out Result) == false)
                   {
                       MessageBox.Show("ID Personal only accepts numbers");
                       IDPersonal = "";
                       return;
                   }
                   if (int.TryParse(Phone, out Result) == false)
                   {
                       MessageBox.Show("Phone only accepts numbers");
                       Phone = "";
                       return;
                   }
                   if (int.TryParse(Points, out Result) == false)
                   {
                       MessageBox.Show("Points only accepts numbers");
                       Points = "0";
                       return;
                   }
                       var List = DataProvider.Ins.DB.INFOCUSTOMERs.ToList();
                       foreach (var item in List)
                       {
                           if (item.IDPersonal == long.Parse(IDPersonal))
                           {
                               MessageBox.Show("ID Personal already exists");
                               IDPersonal = "";
                               return;
                           }
                       }
                       int i=DataProvider.Ins.DB.INFOCUSTOMERs.Count();
                       DataProvider.Ins.DB.INFOCUSTOMERs.Add(new INFOCUSTOMER { DoB = DateTime.Parse(Birthday, CultureInfo.InvariantCulture), Phone = Phone, IDPersonal = long.Parse(IDPersonal), FullName = FullName, Email = Email, Points = int.Parse(Points), ID = "Customer"+(i+1).ToString()});
                       DataProvider.Ins.DB.SaveChanges();
                       (p as Window).Close();
               }
           );
        }
    }
}
