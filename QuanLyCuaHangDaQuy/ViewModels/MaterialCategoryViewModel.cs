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
    internal class MaterialCategoryViewModel:BaseViewModel
    {
        public ObservableCollection<MaterialCategory> ListMaterial { get; set; } = new ObservableCollection<MaterialCategory>();

        private int isEdit = 0;

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _nameMaterial;
        public string NameMaterial { get { return _nameMaterial; } set { _nameMaterial = value; OnPropertyChanged(nameof(NameMaterial)); } }

        private double _profit;
        public double Profit { get { return _profit; } set { _profit = value; OnPropertyChanged(nameof(Profit)); } }


        private MaterialCategory _selectedMaterial;
        public MaterialCategory SelectedMaterial
        {
            get { return _selectedMaterial; }
            set { _selectedMaterial = value; OnPropertyChanged(nameof(SelectedMaterial)); }
        }


        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }

        public ICommand LoadCommand { get; set; }
        
        public ICommand SaveCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public MaterialCategoryViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());

            MaterialCategory.EditCommand = new RelayCommand<object>((p) => true, (p) => OpenMaterialCategoryManagerWindow());

            MaterialCategory.DeleteCommand = new RelayCommand<object>((p) => true, (p) => Delete());

            SaveCommand = new RelayCommand<object>((p) => true, (p) => AddOrUpdateMaterial());
        }
        public void Load()
        {
            ListMaterial.Clear();
            var List = DataProvider.Ins.DB.MATERIALCATEGORies.ToList();
            int no = 1;
            foreach (var item in List)
            {
                var MaterialCategory = new MaterialCategory
                {
                    No = no,
                    ID = item.ID,
                    NameMaterial = item.NameMaterial,
                    Profit = item.Profit,
                };
                ListMaterial.Add(MaterialCategory);
                no++;
            }
            if (no >= 2) { SelectedMaterial = ListMaterial[0]; }
        }
        public void LoadDataAfterTextSearch()
        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListMaterial.Clear();
                var List = DataProvider.Ins.DB.MATERIALCATEGORies.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    if (item.NameMaterial.Contains(TextSearch))
                    {
                        ListMaterial.Add(new MaterialCategory
                        {
                            No = no,
                            ID = item.ID,
                            NameMaterial = item.NameMaterial,
                            Profit = item.Profit
                        }) ;
                        no++;
                    }
                }
                if (no >= 2) { SelectedMaterial = ListMaterial[0]; }

            }
        }
        public void OpenMaterialCategoryManagerWindow()
        {
            isEdit = 1;
            MaterialCategoryManagerWindow materialCategoryManagerWindow = new MaterialCategoryManagerWindow();
            materialCategoryManagerWindow.txtbName.Text = SelectedMaterial.NameMaterial.ToString();
            materialCategoryManagerWindow.txtbProfit.Text = SelectedMaterial.Profit.ToString();
            materialCategoryManagerWindow.ShowDialog();
            LoadDataAfterTextSearch();
        }
        public void Delete()
        {

        }
        public void AddOrUpdateMaterial()
        {

            if (NameMaterial == null  )
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }

            var List = DataProvider.Ins.DB.MATERIALCATEGORies.ToList();
            foreach (var item in List)
            {
                if (item.NameMaterial == NameMaterial )
                {
                    System.Windows.MessageBox.Show("Material already exists");
                    NameMaterial = "";
                    return;
                }
            }

            if(isEdit==1)
            {
                DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(h => h.ID == SelectedMaterial.ID).FirstOrDefault().NameMaterial = NameMaterial;
                DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(h => h.ID == SelectedMaterial.ID).FirstOrDefault().Profit = Profit;
                DataProvider.Ins.DB.SaveChanges();
            }    
            else
            {
                bool Flag = false;
                int Temp = 0;
                while (Flag == false)
                {
                    Temp++;
                    if (DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(h => h.ID == "Material" + (Temp).ToString()).FirstOrDefault() == null)
                    {
                        Flag = true;
                    }
                }
                DataProvider.Ins.DB.MATERIALCATEGORies.Add(new MATERIALCATEGORY { NameMaterial = NameMaterial, Profit = Profit, ID = "Material" + (Temp).ToString() });
                DataProvider.Ins.DB.SaveChanges();
            }
            isEdit = 0;
            LoadDataAfterTextSearch();
            System.Windows.Application.Current.Windows[1].Close();
        }

    }
}
