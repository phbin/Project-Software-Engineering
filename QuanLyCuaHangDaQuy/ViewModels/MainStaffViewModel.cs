using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class MainStaffViewModel:BaseViewModel
    {
        ShopItemsClickViewModel ShopItemClickVM { get; set; }
        public ICommand ShopViewCommand { get; set; }
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
        public MainStaffViewModel()
        {
            ShopItemClickVM = new ShopItemsClickViewModel();

            ShopViewCommand = new RelayCommand<ShopWindow>((p) => true, (p) => {
                CurrentView = this;
            });

            ItemClickCommand = new RelayCommand<ShopItemsClick>((p) => true, (p) =>
            {
                CurrentView = ShopItemClickVM;
            });
        }
    }
}
