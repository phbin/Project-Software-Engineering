using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
  
    public class Admin_AddReceiptVM : BaseViewModel
    {
        public class Provider
        {
            private string _id;
            private string _name;
            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _nameprovider;
        public string NameProvider
        {
            get { return _nameprovider; }
            set { _nameprovider = value; OnPropertyChanged(nameof(NameProvider)); }
        }
        private string _no;
        public string No
        {
            get { return _no; }
            set { _no = value; OnPropertyChanged(nameof(No)); }
        }
        public ObservableCollection<Provider> ListProvider { get; set; } = new ObservableCollection<Provider>();
        public Provider SelectedProvider { get; set; }
        public ICommand LoadCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public Admin_AddReceiptVM()
        {
            LoadCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                bool Flag = false;
                int Temp = 0;
                while (Flag == false)
                {
                    Temp++;
                    if (DataProvider.Ins.DB.ITEMBILLFORMs.ToList().Where(h => h.ID == "B" + (Temp).ToString()).FirstOrDefault() == null)
                    {
                        Flag = true;
                    }
                }

                ID = "B" + (Temp).ToString();
                var List = DataProvider.Ins.DB.INFOPROVIDERs.ToList();
                foreach (var item in List)
                {
                    ListProvider.Add(new Provider { 
                        Id = item.ID,
                        Name=item.NameProd,
                    });
                }
            }
        );
            AddCommand = new RelayCommand<object>(
            (p) => { return true; },
            (p) =>
            {
                if (SelectedProvider == null || Date=="")
                {
                    MessageBox.Show("Please fill in all the information");
                    return;
                }
                DataProvider.Ins.DB.ITEMBILLFORMs.Add(new ITEMBILLFORM
                {
                    ID = ID,
                    IDProd = SelectedProvider.Id,
                    DateBooking = DateTime.Parse(Date, CultureInfo.InvariantCulture)
                }); ;
                DataProvider.Ins.DB.SaveChanges();
                (p as Window).Close();
            }
        );
        }
    }
}
