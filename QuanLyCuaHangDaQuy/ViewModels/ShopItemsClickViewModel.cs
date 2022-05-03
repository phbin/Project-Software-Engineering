using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class ShopItemsClickViewModel:BaseViewModel
    {
        public ICommand ItemClickCommand { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public ShopItemsClickViewModel()
        {
            ItemClickCommand = new RelayCommand<ShopItemsClick>((p) => true, (p) => {
                CurrentView = this;
            });
        }
    }
}
