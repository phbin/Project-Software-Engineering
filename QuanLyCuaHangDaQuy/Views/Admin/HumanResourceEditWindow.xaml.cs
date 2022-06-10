using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyCuaHangDaQuy.Views.Admin
{
    /// <summary>
    /// Interaction logic for HumanResourceEditWindow.xaml
    /// </summary>
    public partial class HumanResourceEditWindow : Window
    {
        public HumanResourceEditWindow()
        {
            InitializeComponent();
        }
        private void UpdateOriginalItem()
        {
            var List = DataProvider.Ins.DB.INFOSTAFFs.ToList();
            foreach (var item in List)
            {
                if (item.IDPersonal == long.Parse(TxtbID.Text) && item.ID != TxtbID.Text)
                {
                    System.Windows.MessageBox.Show("ID Personal already exists");
                    TxtbID.Text = "";
                    return;
                }
            }
            if (BitmapImage == null)
            {
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Phone = TxtbPhone.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Email = TxtbEmail.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Addr = TxtbAddress.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().FullName = TxtbName.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().IDPersonal = long.Parse(TxtbID.Text);
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().DoB = DateTime.Parse(dpDayOfBirth.Text, CultureInfo.InvariantCulture);
                //DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Avatar = ConvertImage.ConvertBitmapImageToBytes();
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Sex = cbSex.Text.ToString();
                DataProvider.Ins.DB.SaveChanges();
            }
            else{

                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Phone = TxtbPhone.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Email = TxtbEmail.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Addr = TxtbAddress.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().FullName = TxtbName.Text;
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().IDPersonal = long.Parse(TxtbID.Text);
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().DoB = DateTime.Parse(dpDayOfBirth.Text, CultureInfo.InvariantCulture);
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Avatar = ConvertImage.ConvertBitmapImageToBytes(BitmapImage);
                DataProvider.Ins.DB.INFOSTAFFs.ToList().Where(h => h.ID == textID.Text).FirstOrDefault().Sex = cbSex.Text.ToString();
                DataProvider.Ins.DB.SaveChanges();
            }
        }
        BitmapImage BitmapImage = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose a picture";
            dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(dialog.FileName);
                bitmap.EndInit();
                BitmapImage = bitmap;
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateOriginalItem();
        }
    }
}
