using QuanLyCuaHangDaQuy.Resources.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class SelectedProductCartVM
    {
        public ICommand MinusClickCommand { get; set; }
  
        public SelectedProductCartVM(string id)
        {
           
            MinusClickCommand = new RelayCommand<SelectedProductCartUC>((p) => true, (p) =>
            {
                MessageBox.Show(id);
            });
            MessageBox.Show(id);

        }
        //public void PlusClickCommand(string id)
        //{
        //    MessageBox.Show(id);
        //}
    }
}
