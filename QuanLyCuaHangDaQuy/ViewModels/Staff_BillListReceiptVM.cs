using QuanLyCuaHangDaQuy.Model;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class BillListReceipt :BaseViewModel
    {
        private int _no;
        public int No
        {
            get { return _no; }
            set { _no = value; OnPropertyChanged(nameof(No)); }
        }
        private string _id;
        public string ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }
        private string _date;
        public string Date
        {
            get { return _date; }
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }
        private string _customer;
        public string Customer
        {
            get { return _customer; }
            set { _customer = value; OnPropertyChanged(nameof(Customer)); }
        }
        private string _total;
        public string Total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(nameof(Total)); }
        }
        private string _prepay;
        public string Prepay
        {
            get { return _prepay; }
            set { _prepay = value; OnPropertyChanged(nameof(Prepay)); }
        }
        private string _remain;
        public string Remain
        {
            get { return _remain; }
            set { _remain = value; OnPropertyChanged(nameof(Remain)); }
        }
        private string _stt;
        public string Stt
        {
            get { return _stt; }
            set { _stt = value; OnPropertyChanged(nameof(Stt)); }
        }
    }
    public class Staff_BillListReceiptVM : BaseViewModel
    {
        public ObservableCollection<BillListReceipt> ListBillReceipt { get; set; } = new ObservableCollection<BillListReceipt>();
        public ICommand LoadCommand { get; set; }
        public Staff_BillListReceiptVM()
        {
            LoadCommand = new RelayCommand<object>(
              (p) => { return true; },
              (p) =>
              {
                  var List = DataProvider.Ins.DB.CUSSERVICEs.ToList();
                  int no = 1;
                  foreach (var item in List)
                  {
                      var ListT = DataProvider.Ins.DB.SERVICELISTs.ToList().Where(h=>h.IDCusService==item.ID);
                      double prepayT =0, remainT = 0, toitalT =0;
                      foreach(var itemT in ListT)
                      {
                          prepayT = ((double)(prepayT + itemT.Prepay));
                          remainT = ((double)(remainT + itemT.Remain));
                          toitalT = ((double)(toitalT + itemT.Total));
                      }    
                      var DatTen = new BillListReceipt
                      {
                          No = no,
                          Customer = DataProvider.Ins.DB.INFOCUSTOMERs.ToList().Where(h => h.ID == item.IDCustomer).FirstOrDefault().FullName,
                          Date = item.DateBooking.ToShortDateString(),
                          ID = item.ID,
                          Stt=item.Stt,
                          Prepay=prepayT.ToString(),
                          Total=toitalT.ToString(),
                          Remain=remainT.ToString()
                      };
                      ListBillReceipt.Add(DatTen);
                      no++;
                  }
              }
          );
        }
    }
}
