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
    public class Add_AddServiceVM :BaseViewModel
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
        public ICommand AddCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public Add_AddServiceVM()
        {
            LoadedCommand = new RelayCommand<object>(
          (p) => { return true; },
          (p) =>
          {
              bool Flag = false;
              int Temp = 0;
              while (Flag == false)
              {
                  Temp++;
                  if (DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == "SV" + (Temp).ToString()).FirstOrDefault() == null)
                  {
                      Flag = true;
                  }
              }
              ID="SV"+Temp.ToString();
          }
      );
            AddCommand = new RelayCommand<object>(
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
               DataProvider.Ins.DB.SERVICECATEGORies.Add(new SERVICECATEGORY {
                   ID=ID,
                   NameService=Name,
               Price=Double.Parse(Price),
               Stt=1});
               DataProvider.Ins.DB.SaveChanges();
               (p as Window).Close();
           }
       );
        }
    }
}
