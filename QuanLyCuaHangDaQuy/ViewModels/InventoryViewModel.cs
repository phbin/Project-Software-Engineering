using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class InventoryViewModel:BaseViewModel
    {

        public ObservableCollection<Inventory> ListInventory { get; set; } = new ObservableCollection<Inventory>();

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }

        private string _opening;
        public string Opening { get { return _opening; } set { _opening = value; OnPropertyChanged(nameof(Opening)); } }

        private string _qtypurchased;
        public string QtyPurchased { get { return _qtypurchased; } set { _qtypurchased = value; OnPropertyChanged(nameof(QtyPurchased)); } }

        private string _qtysold;
        public string QtySold { get { return _qtysold; } set { _qtysold = value; OnPropertyChanged(nameof(QtySold)); } }

        private int? _closing;
        public int? Closing { get { return _closing; } set { _closing = value; OnPropertyChanged(nameof(Closing)); } }

        private string _unit;
        public string Unit { get { return _unit; } set { _unit = value; OnPropertyChanged(nameof(Unit)); } }

        private string _getdate;
        public string GetDate { get { return _getdate; } set { _getdate = value; OnPropertyChanged(nameof(GetDate)); } }

        public ICommand LoadCommand { get; set; }
        public ICommand ExportInventory { get; set; }

        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public InventoryViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());
            ExportInventory = new RelayCommand<object>((p) => true, (p) => {
                InventoryBill admin_BillListImpoted = new InventoryBill();
                admin_BillListImpoted.ShowDialog();
            });
        }


        public void Load()
        {
            GetDate = DateTime.Now.ToString("MM/yyyy");
            //DateTime? selectedDate = datePicker.SelectedDate;
            //string format = selectedDate.Value.ToString("MM/yyyy");

            var originalItem = DataProvider.Ins.DB.ORIGINALITEMs.ToList();
            var importedItem = DataProvider.Ins.DB.IMPORTEDITEMS.ToList();
            var itembillform = DataProvider.Ins.DB.ITEMBILLFORMs.ToList();
            int? sum = 0;

            foreach (var item in importedItem)
            {
                if (item.DatePurchase.ToString("MM/yyyy") == GetDate)
                {
                    int no = 1;
                
                    var id = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.IDOrgItem == item.IDOrgItem);
                    foreach (var i in id)
                    {
                        if(i.DatePurchase.ToString("MM/yyyy") == GetDate) sum = sum + i.Quantity;
                    }
                      
                    var inv = new Inventory
                    {
                        No = no,
                        Name = item.ORIGINALITEM.NameItem,
                        Opening = item.ID,
                        QtyPurchased = sum,  // so luong mua vao getmonth() tinh tong
                        QtySold = item.ORIGINALITEM.SellQty,
                        Unit = item.ORIGINALITEM.MATERIALCATEGORY.UNIT.NameUnit,
                        Closing = sum- item.ORIGINALITEM.SellQty
                    };
                    ListInventory.Add(inv);
                    no++;
                    sum = 0;
                }
            }
        }

        private void LoadDataAfterTextSearch()
        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListInventory.Clear();
                var List = DataProvider.Ins.DB.ORIGINALITEMs.ToList();


                int no = 1;
                foreach (var item in List)
                {
                    if (item.NameItem.Contains(TextSearch))
                    {
                        //var Item = new OriginalItem
                        //{
                        //    No = no,
                        //    ID = item.ID,
                        //    IDForm = item.IDForm,
                        //    IDMaterial = item.IDMaterial,
                        //    NameForm = item.FORMCATEGORY.NameForm,
                        //    NameMaterial = item.MATERIALCATEGORY.NameMaterial,
                        //    NameItem = item.NameItem,
                        //    Descript = item.Descript,
                        //    Price = item.Price,
                        //    Quantity = item.Quantity,
                        //    SellQty = item.SellQty,
                        //    Picture = item.Picture
                        //};
                        //ListInventory.Add(Item);
                        //no++;
                    }
                }
            }
        }
    }
}

