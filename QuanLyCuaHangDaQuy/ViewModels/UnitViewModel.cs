using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Views.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class UnitViewModel:BaseViewModel 
    {
        public ObservableCollection<Unit> ListUnit { get; set; } = new ObservableCollection<Unit>();
        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameunit;
        public string NameUnit { get { return _nameunit; } set { _nameunit = value; OnPropertyChanged(nameof(NameUnit)); } }


        public ICommand LoadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        private Unit _selectedUnit;
        public Unit SelectedUnit { get { return _selectedUnit; } set { _selectedUnit = value; OnPropertyChanged(nameof(SelectedUnit)); } }


        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public UnitViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());

            Unit.EditCommand = new RelayCommand<object>((p) => true, (p) => OpenAccountManagerWindow());

            UpdateCommand = new RelayCommand<object>((p) => true, (p) => UpdateUnit());
            CreateCommand = new RelayCommand<object>((p) => true, (p) => AddUnit());

        }
        public void Load()
        {
            ListUnit.Clear();
            var List = DataProvider.Ins.DB.UNITs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                //var fullname = DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(x => x.ID == item.ID).FirstOrDefault().FullName;
                var unit = new Unit
                {
                    No = no,
                    ID = item.ID,
                    NameUnit = item.NameUnit
                };
                ListUnit.Add(unit);
                no++;
            }
            if (no >= 2) { SelectedUnit = ListUnit[0]; }
        }

        private void UpdateUnit()
        {
            //if (NameUnit.ToString() == null)
            //{
            //    System.Windows.MessageBox.Show("Please fill in all the information");
            //    return;
            //}
            ////var user = DataProvider.Ins.DB.ACCOUNTs.Select(x => x.UserName).ToList();
            //System.Windows.MessageBox.Show("" + ID);
            //DataProvider.Ins.DB.UNITs.ToList().Where(h => h.ID == ID).FirstOrDefault().NameUnit = NameUnit;
            ////DataProvider.Ins.DB.SaveChanges();
            //System.Windows.Application.Current.Windows[1].Close();
            LoadDataAfterTextSearch();
        }
        private void AddUnit()
        {
            if (NameUnit.ToString() == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
            bool Flag = false;
            int Temp = 0;
            while (Flag == false)
            {
                Temp++;
                if (DataProvider.Ins.DB.UNITs.ToList().Where(h => h.ID == "U" + (Temp).ToString()).FirstOrDefault() == null)
                {
                    Flag = true;
                }
            }
            DataProvider.Ins.DB.UNITs.Add(new UNIT { NameUnit = NameUnit, ID = "U" + (Temp).ToString() });
            DataProvider.Ins.DB.SaveChanges();
       
            LoadDataAfterTextSearch();
        }

        private void LoadDataAfterTextSearch()
        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListUnit.Clear();
                var List = DataProvider.Ins.DB.UNITs.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    var fullname = DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(x => x.ID == item.ID).FirstOrDefault().FullName;

                    if (item.NameUnit.Contains(TextSearch))
                    {
                        ListUnit.Add(new Unit
                        {
                            No = no,
                            NameUnit = item.NameUnit,
                            ID = item.ID
                        });
                        no++;
                    }
                    if (no >= 2) { SelectedUnit = ListUnit[0]; }
                }
            }
        }
        private void OpenAccountManagerWindow()
        {
            UnitManageWindow amw = new UnitManageWindow();
            amw.textNameUnit.Text = SelectedUnit.NameUnit.ToString();
            amw.textID.Text = SelectedUnit.ID.ToString();
            amw.ShowDialog();
            amw.btnCreate.Visibility = Visibility.Hidden;
            amw.btnCreate.IsEnabled = false;
            amw.btSave.Visibility = Visibility.Visible;
        }
    }
}
