using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyCuaHangDaQuy.Views
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : UserControl
    {
        public ShopWindow()
        {
            InitializeComponent();
            List<string> ItemsForm  = DataProvider.Ins.DB.FORMCATEGORies.Select(x => x.NameForm).ToList();

            foreach (var items in ItemsForm)
            {
                trvCategory.Items.Add(items);
                //trvCategory.ItemContainerStyle.Setters = new SolidColorBrush(Color.FromRgb(171, 171, 171));
            }
            List<string> ItemsMaterial = DataProvider.Ins.DB.MATERIALCATEGORies.Select(x => x.NameMaterial).ToList();

            foreach (var items in ItemsMaterial)
            {
                trvMaterial.Items.Add(items);
                //trvCategory.ItemContainerStyle.Setters = new SolidColorBrush(Color.FromRgb(171, 171, 171));
            }
        }
    }
}
