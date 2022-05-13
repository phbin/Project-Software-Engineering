using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Staff_AddCustomerVM : BaseViewModel
    {
        public ICommand btnClose { get; set; }
        public Staff_AddCustomerVM()
        {

            btnClose = new RelayCommand<Object>(
                (p) => { return p==null?false:true; },
                (p) =>
                {
                    WindowCloseResult
                }
                );
         
        }
    }
}
