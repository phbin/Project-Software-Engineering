using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using QuanLyCuaHangDaQuy.Views.Staff;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    class CartViewModel : BaseViewModel
    {
        public ICommand LoadCartCommand { get; set; }
        public ICommand ExportCommand { get; set; }

        private SelectedItem _selecteditem{ get; set; }

        public SelectedItem Selected
        {
            get { return _selecteditem; }
            set { _selecteditem = value; OnPropertyChanged(nameof(Selected)); }
        }
        private List<CART> cartList = new List<CART>();
        public ObservableCollection<SelectedItem> list { get; set; } = new ObservableCollection<SelectedItem>();
        string idmaterial = "";
        string idform = "";
        public CartViewModel()
        {
            ExportCommand = new RelayCommand<object>(
               (p) => { return true; },
               (p) =>
               {
                   CheckOutBill admin_BillListImpoted = new CheckOutBill();
                   //bool Flag = false;
                   //int Temp = 0;
                   //while (Flag == false)
                   //{
                   //    Temp++;
                   //    if (DataProvider.Ins.DB.IMPORTEDITEMS.ToList().Where(h => h.ID == "IB" + (Temp).ToString()).FirstOrDefault() == null)
                   //    {
                   //        Flag = true;

                   //    }
                   //}
                   //DataProvider.Ins.DB.ITEMFORMs.Add(new ITEMFORM { ID = "IB" + (Temp).ToString(), f });

                   admin_BillListImpoted.ShowDialog();
               });
                   LoadCartCommand = new RelayCommand<CartUC>((p) => true, (p) =>
            {
                //p.txtCount.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Quantity).ToString() + " item(s)";
                //p.txtTotalAll.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Total).ToString() + " VND";
                //p.txtTax.Text = ((float)DataProvider.Ins.DB.CARTS.Sum(x => x.Total) * 0.1).ToString() + " VND";
                //p.txtAfterTax.Text = ((float)DataProvider.Ins.DB.CARTS.Sum(x => x.Total) - (float)DataProvider.Ins.DB.CARTS.Sum(x => x.Total) * 0.1).ToString()+" VND";
                GetItem();
                if (list.Count > 0)
                {
                    p.listViewCart.ItemsSource = list;
                    p.txtCount.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Quantity).ToString() + " item(s)";
                    p.txtTotalAll.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Total).ToString() + "VND";
                    p.txtAfterTax.Text = (DataProvider.Ins.DB.CARTS.Sum(x => x.Total) + 1000).ToString() + "VND";
                }
                else
                {
                    p.NullCart.Visibility = Visibility.Visible;
                    p.listViewCart.ItemsSource = null;
                    p.txtCount.Text = "0 item(s)";
                    p.txtTotalAll.Text = "0VND";
                    p.txtAfterTax.Text = "0VND";
                }
            });

            SelectedItem.DeleteCommand = new RelayCommand<CartUC>((p) => true, (p) =>
            {
                CART cart = DataProvider.Ins.DB.CARTS.ToList().Where(x => x.IDOrgItem == Selected.IDItem).FirstOrDefault();
                DataProvider.Ins.DB.CARTS.Remove(cart);
                DataProvider.Ins.DB.SaveChanges();
                GetItem();
                if (list.Count > 0)
                {
                    p.listViewCart.ItemsSource = list;
                    p.txtCount.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Quantity).ToString() + " item(s)";
                    p.txtTotalAll.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Total).ToString() + "VND";
                    p.txtAfterTax.Text = (DataProvider.Ins.DB.CARTS.Sum(x => x.Total) + 1000).ToString() + "VND";
                }
                else
                {
                    p.NullCart.Visibility = Visibility.Visible;
                    p.listViewCart.ItemsSource = null;
                    p.txtCount.Text = "0 item(s)";
                    p.txtTotalAll.Text = "0VND";
                    p.txtAfterTax.Text = "0VND";
                }

            });
            SelectedItem.MinusCommand = new RelayCommand<CartUC>((p) => true, (p) =>
             {
                 if (Selected.Quantity == 1)
                 {
                     CART cart = DataProvider.Ins.DB.CARTS.ToList().Where(x => x.IDOrgItem == Selected.IDItem).FirstOrDefault();
                     DataProvider.Ins.DB.CARTS.Remove(cart);
                     DataProvider.Ins.DB.SaveChanges();
                 }
                 else
                 {
                     Selected.Quantity = Selected.Quantity - 1;
                     CART cart = (from m in DataProvider.Ins.DB.CARTS
                                  where m.IDOrgItem == Selected.IDItem
                                  select m).Single();
                     cart.Quantity = Selected.Quantity;
                     var price = DataProvider.Ins.DB.ORIGINALITEMs.Where(x => x.ID == Selected.IDItem).FirstOrDefault().Price;
                     var total = Selected.Quantity * price;
                     //DataProvider.Ins.DB.CARTS.ToList().Where(h => h.ID == Selected.IDItem).FirstOrDefault().Total = total;
                     cart.Total = total;
                     DataProvider.Ins.DB.SaveChanges();
                 }
                 GetItem();
                 if (list.Count > 0)
                 {
                     p.listViewCart.ItemsSource = list;
                     p.txtCount.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Quantity).ToString() + " item(s)";
                     p.txtTotalAll.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Total).ToString() + "VND";
                     p.txtAfterTax.Text = (DataProvider.Ins.DB.CARTS.Sum(x => x.Total) + 1000).ToString() + "VND";

                 }
                 else
                 {
                     p.NullCart.Visibility = Visibility.Visible;
                     p.listViewCart.ItemsSource = null;
                     p.txtCount.Text = "0 item(s)";
                     p.txtTotalAll.Text = "0VND";
                     p.txtAfterTax.Text = "0VND";

                 }
             });

            SelectedItem.PlusCommand = new RelayCommand<CartUC>((p) => true, (p) =>
            {
                //System.Windows.MessageBox.Show("" + Selected.NameItem);
                Selected.Quantity = Selected.Quantity + 1;
                CART cart = (from m in DataProvider.Ins.DB.CARTS
                             where m.IDOrgItem == Selected.IDItem
                             select m).Single();
                cart.Quantity = Selected.Quantity;

                var price = DataProvider.Ins.DB.ORIGINALITEMs.Where(x => x.ID ==Selected.IDItem).FirstOrDefault().Price;
                var total= Selected.Quantity * price;
                //DataProvider.Ins.DB.CARTS.ToList().Where(h => h.ID == Selected.IDItem).FirstOrDefault().Total = total;
                cart.Total = total;



                DataProvider.Ins.DB.SaveChanges();
                GetItem();
                if (list.Count > 0)
                {
                    p.listViewCart.ItemsSource = list;
                    p.txtCount.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Quantity).ToString() + " item(s)";
                    p.txtTotalAll.Text = DataProvider.Ins.DB.CARTS.Sum(x => x.Total).ToString() + "VND";
                    p.txtAfterTax.Text = (DataProvider.Ins.DB.CARTS.Sum(x => x.Total) + 1000).ToString() + "VND";
                }
                else
                {
                    p.NullCart.Visibility = Visibility.Visible;
                    p.listViewCart.ItemsSource = null;
                    p.txtCount.Text = "0 item(s)";
                    p.txtTotalAll.Text = "0VND";
                    p.txtAfterTax.Text = "0VND";
                }
            });
        }
      
        private void GetItem()
        {
            list.Clear();
            cartList = DataProvider.Ins.DB.CARTS.ToList();
            list = new ObservableCollection<SelectedItem>();
            if (cartList!=null)
            {
                //int no = 1;
                foreach (var item in cartList)
                {
                    idmaterial = DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(x => x.ID == item.IDOrgItem).FirstOrDefault().IDMaterial;
                    idform = DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(x => x.ID == item.IDOrgItem).FirstOrDefault().IDForm;
                    list.Add(new SelectedItem()
                    {
                        IDItem = item.IDOrgItem,
                        Total = item.Total,
                        NameItem = DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(x => x.ID == item.IDOrgItem).FirstOrDefault().NameItem,
                        Quantity = (int)item.Quantity,
                        NameMaterial = DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(x => x.ID == idmaterial).FirstOrDefault().NameMaterial,
                        NameForm = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(x => x.ID == idform).FirstOrDefault().NameForm,
                        Picture = ConvertImage.LoadImage(DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(x => x.ID == item.IDOrgItem).FirstOrDefault().Picture)
                    });
                    //no++;
                }
                //if (no >= 2) { Selected = list[0]; }
            }
        }
    }
}

