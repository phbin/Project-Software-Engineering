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
                   if (IDPersonal.Length >= 20)
                   {
                       MessageBox.Show("ID Personal too long");
                       IDPersonal = "";
                       return;
                   }
                   if (Phone.Length >= 20)
                   {
                       MessageBox.Show("Phone too long");
                       Phone = "";
                       return;
                   }
                   if (Points.Length >= 11)
                   {
                       MessageBox.Show("Points too long");
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
                   bool Flag = false;
                   int Temp = 0;
                   while (Flag == false)
                   {
                       Temp++;
                       if (DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == "Customer" + (Temp).ToString()).FirstOrDefault() == null)
                       {
                           Flag = true;
                       }
                   }
                   DataProvider.Ins.DB.INFOCUSTOMERs.Add(new INFOCUSTOMER { DoB = DateTime.Parse(Birthday, CultureInfo.InvariantCulture), Phone = Phone, IDPersonal = long.Parse(IDPersonal), FullName = FullName, Email = Email, Points = int.Parse(Points), ID = "Customer"+(Temp).ToString()});
                       DataProvider.Ins.DB.SaveChanges();
                       (p as Window).Close();
               }
           );
        }
    }
}
