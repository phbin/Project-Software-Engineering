using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class ShopItemsClickViewModel:BaseViewModel
    {
        private object _description;
        public object Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private object _id;
        public object ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        private object _name;
        public object Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private object _picture;
        public object Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                OnPropertyChanged(nameof(Picture));
            }
        }
        private object _price;
        public object Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        private object _quantity;
        public object Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        CartViewModel CartUCVM { get; set; }

        public ICommand LoadCommand { get; set; }
        public ICommand MinusClickCommand { get; set; }
        public ICommand PlusClickCommand { get; set; }
        public ICommand AddCommand { get; set; }
   
        public ShopItemsClickViewModel(string id)
        {
            ShopItemsClick wd = new ShopItemsClick();
            var item = DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(x => x.ID==id). FirstOrDefault();
            LoadCommand = new RelayCommand<ShopItemsClick>((p) => true, (p) =>
            {
                Description = item.Descript;
                Price = item.Price;
                Name = item.NameItem;
                Quantity = 1;
                Picture = ConvertImage.LoadImage(item.Picture);
                ID = id;
            });
            MinusClickCommand = new RelayCommand<ShopItemsClick>((p) => true, (p) =>
            {
                if ((int)Quantity != 1)
                {
                    Quantity = (int)Quantity - 1;
                }
            });
            PlusClickCommand = new RelayCommand<ShopItemsClick>((p) => true, (p) =>
            {
                Quantity = (int)Quantity + 1;
            });
            AddCommand = new RelayCommand<CartUC>((p) => true, (p) =>
            {
                CART cart = new CART()
                {
                    ID = CreateID(),
                    IDItem= (string)ID,
                    Quantity =(int)Quantity
            };
                var list = DataProvider.Ins.DB.CARTS.Where(x => x.IDItem == cart.IDItem).Count();
                if (list != 0)
                {
                    int qty = (int)DataProvider.Ins.DB.CARTS.ToList().Where(a => a.IDItem == cart.IDItem).FirstOrDefault().Quantity;
                    CART x = (from m in DataProvider.Ins.DB.CARTS
                              where m.IDItem == cart.IDItem
                              select m).Single();
                    x.Quantity = qty + cart.Quantity;
                    DataProvider.Ins.DB.USP_Carts(x.IDItem.ToString());
                    DataProvider.Ins.DB.SaveChanges();
                }
                else
                {
                    DataProvider.Ins.DB.CARTS.Add(cart);
                    DataProvider.Ins.DB.USP_Carts(cart.IDItem.ToString());
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Success!", "Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            });
        }
        string CreateID()
        {
            string idc = "";

            bool Flag = false;
            int Temp = 0;
            while (Flag == false)
            {
                Temp++;
                if (DataProvider.Ins.DB.CARTS.ToList().Where(h => h.ID == "C" + (Temp).ToString()).FirstOrDefault() == null)
                {
                    Flag = true;
                }
            }
            idc = "C" + Temp;
            return idc;
        }
    }
}
