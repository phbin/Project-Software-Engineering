using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class InventoryBillVM: BaseViewModel
    {
        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _today;
        public string Today { get { return _today; }  set { _today = value; OnPropertyChanged(nameof(Today)); }  }

        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }

        private string _opening;
        public string Opening { get { return _opening; } set { _opening = value; OnPropertyChanged(nameof(Opening)); } }

        private int? _qtypurchased;
        public int? QtyPurchased { get { return _qtypurchased; } set { _qtypurchased = value; OnPropertyChanged(nameof(QtyPurchased)); } }

        private int? _qtysold;
        public int? QtySold { get { return _qtysold; } set { _qtysold = value; OnPropertyChanged(nameof(QtySold)); } }

        private int? _closing;
        public int? Closing { get { return _closing; } set { _closing = value; OnPropertyChanged(nameof(Closing)); } }

        private string _unit;
        public string Unit { get { return _unit; } set { _unit = value; OnPropertyChanged(nameof(Unit)); } }

        public ObservableCollection<Inventory> ListInventory { get; set; } = new ObservableCollection<Inventory>();
        public ICommand LoadCommand { get; set; }
        public InventoryBillVM()
        {
            LoadCommand = new RelayCommand<object>(
             (p) => { return true; },
             (p) =>
             {
                
                 Today = DateTime.Now.ToString("MM/yyyy");
                 var originalItem = DataProvider.Ins.DB.ORIGINALITEMs.ToList();
                 var importedItem = DataProvider.Ins.DB.IMPORTEDITEMS.ToList();
                 var itembillform = DataProvider.Ins.DB.ITEMBILLFORMs.ToList();
                 int? sum = 0;

                 foreach (var item in importedItem)
                 {
                     if (item.DatePurchase.ToString("MM/yyyy") == Today)
                     {
                         int no = 1;

                         var id = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.IDOrgItem == item.IDOrgItem);
                         foreach (var i in id)
                         {
                             if (i.DatePurchase.ToString("MM/yyyy") == Today) sum = sum + i.Quantity;
                         }

                         var inv = new Inventory
                         {
                             No = no,
                             Name = item.ORIGINALITEM.NameItem,
                             Opening = item.ID,
                             QtyPurchased = sum,  // so luong mua vao getmonth() tinh tong
                             QtySold = item.ORIGINALITEM.SellQty,
                             Unit = item.ORIGINALITEM.MATERIALCATEGORY.UNIT.NameUnit,
                             Closing = sum - item.ORIGINALITEM.SellQty
                         };
                         ListInventory.Add(inv);
                         no++;
                         sum = 0;
                     }
                 }
             }
         );
        }
    }
}
