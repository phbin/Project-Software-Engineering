using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_ServiceListVM : BaseViewModel
    {
        public ICommand CreateReceipt { get; set; }
        public Staff_ServiceListVM()
        {
            CreateReceipt = new RelayCommand<Object>(
              (p) => { return true; },
              (p) =>
              {
                  Staff_AddReceipt staff_AddReceipt = new Staff_AddReceipt();
                  staff_AddReceipt.ShowDialog();
              }
              );
        }
    }
}
