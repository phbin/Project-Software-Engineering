using QuanLyCuaHangDaQuy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class BillListService : BaseViewModel
    {
        private int _no;
        public int No
        {
            get { return _no; }
            set { _no = value; OnPropertyChanged(nameof(No)); }
        }
        private string _service;
        public string Service
        {
            get { return _service; }
            set { _service = value; OnPropertyChanged(nameof(Service)); }
        }
        private string _unitprice;
        public string UnitPrice
        {
            get { return _unitprice; }
            set { _unitprice = value; OnPropertyChanged(nameof(UnitPrice)); }
        }
        private string _pricediscounted;
        public string PriceDiscounted
        {
            get { return _pricediscounted; }
            set { _pricediscounted = value; OnPropertyChanged(nameof(PriceDiscounted)); }
        }
        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }
        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged(nameof(Amount)); }
        }
        private string _remain;
        public string Remain
        {
            get { return _remain; }
            set { _remain = value; OnPropertyChanged(nameof(Remain)); }
        }
        private string _prepay;
        public string Prepay
        {
            get { return _prepay; }
            set { _prepay = value; OnPropertyChanged(nameof(Prepay)); }
        }
        private string _returnDate;
        public string ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; OnPropertyChanged(nameof(ReturnDate)); }
        }
        private string _stt;
        public string Stt
        {
            get { return _stt; }
            set { _stt = value; OnPropertyChanged(nameof(Stt)); }
        }
    }
    public class Staff_BillListServiceVM : BaseViewModel
    {
        public ObservableCollection<BillListService> ListBillService { get; set; } = new ObservableCollection<BillListService>();
        public ICommand LoadCommand { get; set; }
        public Staff_BillListServiceVM()
        {
            LoadCommand = new RelayCommand<object>(
              (p) => { return true; },
              (p) =>
              {
                  var List = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h=>h.IDCusService== Staff_ListReceiptVM.IdReceipt);
                  int no = 1;

                  foreach (var item in List)
                  {
                      var UnitPriceT = DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == item.IDService).FirstOrDefault().Price;
                      var DatTen = new BillListService
                      {
                        No=no,
                        Stt=item.Stt,
                        Service= DataProvider.Ins.DB.SERVICECATEGORies.ToList().Where(h => h.ID == item.IDService).FirstOrDefault().NameService,
                        UnitPrice= (UnitPriceT != 0) ? (string.Format("{0:0,0đ}", UnitPriceT)) : ("0đ") ,
                        Quantity=item.Quantity.ToString(),
                        ReturnDate=item.DateReturn.ToShortDateString(),
                        Prepay = (item.Prepay != 0) ? (string.Format("{0:0,0đ}", item.Prepay)) : ("0đ"),
                        PriceDiscounted = (item.PriceDiscounted != 0) ? (string.Format("{0:0,0đ}", item.PriceDiscounted)) : ("0đ"),
                        Remain = (item.Remain != 0) ? (string.Format("{0:0,0đ}", item.Remain)) : ("0đ"),
                        Amount=(item.Total != 0) ? (string.Format("{0:0,0đ}", item.Total)) : ("0đ"),
                      };
                      ListBillService.Add(DatTen);
                      no++;
                  }
              }
          );
        }
    }
}
