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
    internal class FormCategoryViewModel : BaseViewModel
    {
        public ObservableCollection<FormCategory> ListForm { get; set; } = new ObservableCollection<FormCategory>();
        private int isEdit = 0;

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameForm;
        public string NameForm { get { return _nameForm; } set { _nameForm = value; OnPropertyChanged(nameof(NameForm)); } }


        private FormCategory _selectedForm;
        public FormCategory SelectedForm
        {
            get { return _selectedForm; }
            set { _selectedForm = value; OnPropertyChanged(nameof(SelectedForm)); }
        }


        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }

        public ICommand LoadCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public FormCategoryViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());

            FormCategory.EditCommand = new RelayCommand<object>((p) => true, (p) => OpenFormCategoryManagerWindow());

            FormCategory.DeleteCommand = new RelayCommand<object>((p) => true, (p) => Delete());

            SaveCommand = new RelayCommand<object>((p) => true, (p) => AddOrUpdateForm());
        }
        public void Load()
        {
            ListForm.Clear();
            var List = DataProvider.Ins.DB.FORMCATEGORies.ToList();
            int no = 1;
            foreach (var item in List)
            {
                var FormCategory = new FormCategory
                {
                    No = no,
                    ID = item.ID,
                    NameForm = item.NameForm
                };
                ListForm.Add(FormCategory);
                no++;
            }
            if (no >= 2) { SelectedForm = ListForm[0]; }
        }
        public void LoadDataAfterTextSearch()
        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListForm.Clear();
                var List = DataProvider.Ins.DB.FORMCATEGORies.ToList();
                int no = 1;
                foreach (var item in List)
                {
                    if (item.NameForm.Contains(TextSearch))
                    {
                        ListForm.Add(new FormCategory
                        {
                            No = no,
                            ID=item.ID,
                            NameForm = item.NameForm
                        });
                        no++;
                    }
                }
                if (no >= 2) { SelectedForm = ListForm[0]; }

            }
        }
        public void OpenFormCategoryManagerWindow()
        {
            isEdit = 1;
            FormCategoryManagerWindow formCategoryManagerWindow = new FormCategoryManagerWindow();
            formCategoryManagerWindow.txtbName.Text = SelectedForm.NameForm.ToString();
            formCategoryManagerWindow.ShowDialog();
        }
        public void Delete()
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this customer?", "", (MessageBoxButtons)MessageBoxButton.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DataProvider.Ins.DB.FORMCATEGORies.Remove(DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(h => h.ID == SelectedForm.ID).FirstOrDefault());
                DataProvider.Ins.DB.SaveChanges();
                LoadDataAfterTextSearch();
            }
        }
        public void AddOrUpdateForm()
        {

            if (NameForm == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }

            var List = DataProvider.Ins.DB.FORMCATEGORies.ToList();
            foreach (var item in List)
            {
                if (item.NameForm == NameForm )
                {
                    System.Windows.MessageBox.Show("Form already exists");
                    NameForm = "";
                    return;
                }
            }
            if (isEdit==1)
            {
                DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(h => h.ID == SelectedForm.ID).FirstOrDefault().NameForm = NameForm;
                DataProvider.Ins.DB.SaveChanges();
            }
            else
            {
                bool Flag = false;
                int Temp = 0;
                while (Flag == false)
                {
                    Temp++;
                    if (DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(h => h.ID == "Material" + (Temp).ToString()).FirstOrDefault() == null)
                    {
                        Flag = true;
                    }
                }
                DataProvider.Ins.DB.FORMCATEGORies.Add(new FORMCATEGORY { NameForm = NameForm, ID = "Material" + (Temp).ToString() });
                DataProvider.Ins.DB.SaveChanges();
            }
            isEdit=0;
            LoadDataAfterTextSearch();
            System.Windows.Application.Current.Windows[1].Close();



        }
    }
}
