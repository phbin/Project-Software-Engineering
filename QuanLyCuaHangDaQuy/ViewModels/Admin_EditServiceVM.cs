using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Admin_EditServiceVM : BaseViewModel
    {
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }
        public ICommand EditCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public Admin_EditServiceVM()
        {
            LoadedCommand = new RelayCommand<object>(
          (p) => { return true; },
          (p) =>
          {
              ID = Admin_ListServiceVM.IDService;
              Name = DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == ID).FirstOrDefault().NameService;
              Price = DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == ID).FirstOrDefault().Price.ToString();
          }
      );
            EditCommand = new RelayCommand<object>(
           (p) => { return true; },
           (p) =>
           {
               if (Price == "" || Name == "")
               {
                   MessageBox.Show("Please fill in all the information");
                   return;
               }
               if (Price.Length >= 20)
               {
                   MessageBox.Show("Price too long");
                   Price = "";
                   return;
               }
               if (Name.Length >= 20)
               {
                   MessageBox.Show("Name too long");
                   Price = "";
                   return;
               }
               DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == ID).FirstOrDefault().NameService = Name;
               DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == ID).FirstOrDefault().Price = Double.Parse(Price);
               DataProvider.Ins.DB.SaveChanges();
               (p as Window).Close();
           }
       );
        }
    }

}
