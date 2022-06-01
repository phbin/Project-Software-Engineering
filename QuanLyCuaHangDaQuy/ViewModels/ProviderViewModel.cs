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

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class ProviderViewModel : BaseViewModel
    {
        public ObservableCollection<Provider> ListProvider { get; set; } = new ObservableCollection<Provider>();
        private int isEdit = 0;
        public ICommand LoadCommand { get; set; }

    //Add/Edit Provider
        public ICommand SaveCommand { get; set; }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameProd;
        public string NameProd { get { return _nameProd; } set { _nameProd = value; OnPropertyChanged(nameof(NameProd)); } }

        private string _addr;
        public string Addr { get { return _addr; } set { _addr = value; OnPropertyChanged(nameof(Addr)); } }

        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(nameof(Phone)); } }

        private Provider _selectedProvider;
        public Provider SelectedProvider { get { return _selectedProvider; } set { _selectedProvider = value; OnPropertyChanged(nameof(SelectedProvider)); } }

        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public ProviderViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());

            Provider.EditCommand = new RelayCommand<object>((p) => true, (p) => OpenProviderManagerWindow());

            Provider.DeleteCommand = new RelayCommand<object>((p) => true, (p) => Delete());

            SaveCommand = new RelayCommand<object>((p) => true, (p) => AddOrUpdateProvider());
        }
        public void Load()
        {
            ListProvider.Clear();
            var List = DataProvider.Ins.DB.INFOPROVIDERs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                if( item.stt==1)
                {
                    var Provider = new Provider
                    {
                        No = no,
                        ID = item.ID,
                        NameProd = item.NameProd,
                        Addr = item.Addr,
                        Phone = item.Phone
                    };
                    ListProvider.Add(Provider);
                    no++;
                }    
            }
            if (no >= 2) { SelectedProvider = ListProvider[0]; }
        }
        public void LoadDataAfterTextSearch()

        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListProvider.Clear();
                var List = DataProvider.Ins.DB.INFOPROVIDERs.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    if (item.NameProd.Contains(TextSearch))
                    {
                        if(item.stt==1)
                        {
                            ListProvider.Add(new Provider
                            {
                                No = no,
                                ID = item.ID,
                                NameProd = item.NameProd,
                                Addr = item.Addr,
                                Phone = item.Phone
                            });
                            no++;
                        }    
                    }
                    if (no >= 2) { SelectedProvider = ListProvider[0]; }

                }
            }
        }
        public void OpenProviderManagerWindow()
        {
            isEdit = 1;
            ProviderManagerWindow providerManagerWindow = new ProviderManagerWindow();
            providerManagerWindow.txtbName.Text = SelectedProvider.NameProd.ToString();
            providerManagerWindow.txtbAddress.Text = SelectedProvider.Addr.ToString();
            providerManagerWindow.txtbPhone.Text = SelectedProvider.Phone.ToString();
            providerManagerWindow.ShowDialog();
        }
        public void Delete()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this Provider?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bool canDelete = true;
                int count = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.IDProd == SelectedProvider.ID).Count();
                int count1 = DataProvider.Ins.DB.ITEMBILLFORMs.ToList().Where(h => h.IDProd == SelectedProvider.ID).Count();
                if (count1 >=1 && count >= 1)
                    canDelete = false;
                if (canDelete)
                {
                    DataProvider.Ins.DB.INFOPROVIDERs.Remove(DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == SelectedProvider.ID).FirstOrDefault());
                }
                else
                {
                    DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == SelectedProvider.ID).FirstOrDefault().stt = 0;
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadDataAfterTextSearch();
            }
        }
        public void AddOrUpdateProvider()
        {

            if (NameProd == null || Addr == null || Phone == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
            if (Phone.Length < 10)
            {
                System.Windows.MessageBox.Show("Invalid Phone Number");
                Phone = "";
                return;
            }
            var List = DataProvider.Ins.DB.INFOPROVIDERs.ToList();
            foreach (var item in List)
            {
                if (item.NameProd == NameProd && item.ID == ID)
                {
                    System.Windows.MessageBox.Show("Provider already exists");
                    Phone = "";
                    return;
                }
            }
            if (isEdit == 1) 
            {
                DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == SelectedProvider.ID).FirstOrDefault().NameProd = NameProd;
                DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == SelectedProvider.ID).FirstOrDefault().Addr = Addr;
                DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == SelectedProvider.ID).FirstOrDefault().Phone = Phone;
                DataProvider.Ins.DB.SaveChanges();
            } 
            else
            {
                bool Flag = false;
                int Temp = 0;
                while (Flag == false)
                {
                    Temp++;
                    if (DataProvider.Ins.DB.INFOPROVIDERs.ToList().Where(h => h.ID == "Provider" + (Temp).ToString()).FirstOrDefault() == null)
                    {
                        Flag = true;
                    }
                }
                DataProvider.Ins.DB.INFOPROVIDERs.Add(new INFOPROVIDER { Phone = Phone, NameProd = NameProd, Addr = Addr, ID = "Provider" + (Temp).ToString() , stt=1});
                DataProvider.Ins.DB.SaveChanges();
            }
            isEdit = 0;
            System.Windows.Application.Current.Windows[1].Close();
            LoadDataAfterTextSearch();
        }

    }
}

