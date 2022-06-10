using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.Views.Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class ItemViewModel:BaseViewModel
    {
        public ObservableCollection<OriginalItem> ListItem { get; set; } = new ObservableCollection<OriginalItem>();

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameitem;
        public string NameItem { get { return _nameitem; } set { _nameitem = value; OnPropertyChanged(nameof(NameItem)); } }

        private string _idform;
        public string IDForm { get { return _idform; } set { _idform = value; OnPropertyChanged(nameof(IDForm)); } }

        private string _idmaterial;
        public string IDMaterial { get { return _idmaterial; } set { _idmaterial = value; OnPropertyChanged(nameof(IDMaterial)); } }

        private string _nameform;
        public string NameForm { get { return _nameform; } set { _nameform = value; OnPropertyChanged(nameof(NameForm)); } }

        private string _namematerial;
        public string NameMaterial { get { return _namematerial; } set { _namematerial = value; OnPropertyChanged(nameof(NameMaterial)); } }

        private int? _quantity;
        public int? Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(nameof(Quantity)); } }

        private int? _sellqty;
        public int? SellQty { get { return _sellqty; } set { _sellqty = value; OnPropertyChanged(nameof(SellQty)); } }

        private double? _price;
        public double? Price { get { return _price; } set { _price = value; OnPropertyChanged(nameof(Price)); } }

        private string _descript;
        public string Descript { get { return _descript; } set { _descript = value; OnPropertyChanged(nameof(Descript)); } }

        private byte[] _picture;
        public byte[] Picture { get { return _picture; } set { _picture = value; OnPropertyChanged(nameof(Picture)); } }

        private BitmapImage _bitmapImage;
        public BitmapImage BitmapImage
        {
            get { return _bitmapImage; }
            set { _bitmapImage = value; OnPropertyChanged(nameof(BitmapImage)); }
        }

        public ICommand LoadCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand BrowseImageCommand { get; set; }

        private OriginalItem _selectedItem;
        public OriginalItem SelectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); } }


        private string _textSearch;
        public string TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(nameof(TextSearch)); }
        }
        public ItemViewModel()
        {
            LoadCommand = new RelayCommand<object>((p) => true, (p) => LoadDataAfterTextSearch());
            BrowseImageCommand = new RelayCommand<object>((p) => true, (p) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Choose a picture";
                dialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(dialog.FileName);
                    bitmap.EndInit();
                    BitmapImage = bitmap;
                }
            });
            OriginalItem.EditCommand = new RelayCommand<object>((p) => true, (p) => OpenAccountManagerWindow());

            UpdateCommand = new RelayCommand<object>((p) => true, (p) => UpdateOriginalItem());
            CreateCommand = new RelayCommand<object>((p) => true, (p) => AddOriginalItem());
        }
        public void Load()
        {
            ListItem.Clear();
            var List = DataProvider.Ins.DB.ORIGINALITEMs.ToList();
            int no = 1;
            foreach (var item in List)
            {
                var nameMaterial = DataProvider.Ins.DB.MATERIALCATEGORies.ToList().Where(x => x.ID == item.IDMaterial).FirstOrDefault().NameMaterial;
                var nameForm = DataProvider.Ins.DB.FORMCATEGORies.ToList().Where(x => x.ID == item.IDForm).FirstOrDefault().NameForm;
                var Item = new OriginalItem
                {
                    No = no,
                    ID = item.ID,
                    IDForm=item.IDForm,
                    IDMaterial=item.IDMaterial,
                    NameItem=item.NameItem,
                    Descript=item.Descript,
                    Price=item.Price,
                    Quantity=item.Quantity,
                    SellQty=item.SellQty,
                    Picture=item.Picture,
                    NameForm = item.FORMCATEGORY.NameForm,
                    NameMaterial = item.MATERIALCATEGORY.NameMaterial
                };
                ListItem.Add(Item);
                no++;
            }
            if (no >= 2) { SelectedItem = ListItem[0]; }
        }

        private void UpdateOriginalItem()
        {
                LoadDataAfterTextSearch();            
        }
        private void AddOriginalItem()
        {
            if (NameItem == null)
            {
                System.Windows.MessageBox.Show("Please fill in all the information");
                return;
            }
           
            bool Flag = false;
            int Temp = 0;
            while (Flag == false)
            {
                Temp++;
                if (DataProvider.Ins.DB.ORIGINALITEMs.ToList().Where(h => h.ID == "OI" + (Temp).ToString()).FirstOrDefault() == null)
                {
                    Flag = true;
                 
                }
            }
            var idMaterial = DataProvider.Ins.DB.MATERIALCATEGORies.Where(x => x.NameMaterial == NameMaterial).FirstOrDefault().ID;
            var idForm = DataProvider.Ins.DB.FORMCATEGORies.Where(x => x.NameForm == NameForm).FirstOrDefault().ID;
            DataProvider.Ins.DB.ORIGINALITEMs.Add(new ORIGINALITEM { ID = "OI" + (Temp).ToString(), NameItem=NameItem, IDMaterial=idMaterial, IDForm=idForm, Descript=Descript, Price=0, Quantity=0, SellQty=0, Picture=ConvertImage.ConvertBitmapImageToBytes(BitmapImage)});
            
            DataProvider.Ins.DB.SaveChanges();

            LoadDataAfterTextSearch();
        }

        private void LoadDataAfterTextSearch()
        {
            if (TextSearch == "" || TextSearch == null)
            {
                Load();
            }
            else
            {
                ListItem.Clear();
                var List = DataProvider.Ins.DB.ORIGINALITEMs.ToList();


                int no = 1;
                foreach (var item in List)
                {
                    if (item.NameItem.Contains(TextSearch))
                    {
                        var Item = new OriginalItem
                        {
                            No = no,
                            ID = item.ID,
                            IDForm = item.IDForm,
                            IDMaterial = item.IDMaterial,
                            NameForm = item.FORMCATEGORY.NameForm,
                            NameMaterial = item.MATERIALCATEGORY.NameMaterial,
                            NameItem = item.NameItem,
                            Descript = item.Descript,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            SellQty = item.SellQty,
                            Picture = item.Picture
                        };
                        ListItem.Add(Item);
                        no++;
                    }
                }
                if (no >= 2) { SelectedItem = ListItem[0]; }
            }
        }
        private void OpenAccountManagerWindow()
        {
            ItemManageWindow amw = new ItemManageWindow();
            amw.textID.Text = SelectedItem.ID;
            amw.textName.Text = SelectedItem.NameItem;
            amw.textPrice.Text = SelectedItem.Price.ToString();
            amw.textQuantity.Text = SelectedItem.Quantity.ToString();
            amw.textSellQty.Text = SelectedItem.SellQty.ToString();
            amw.cbNameForm.Text = SelectedItem.NameForm;
            amw.cbNameMaterial.Text = SelectedItem.NameMaterial;
            amw.textDescript.Text = SelectedItem.Descript;
            amw.imgPicture.ImageSource = ConvertImage.LoadImage(SelectedItem.Picture);
            //amw.textFullname.Text = SelectedItem.Fullname.ToString();
            //amw.textFullname.IsEnabled = false;
            //amw.textUsername.Text = SelectedItem.Username.ToString();
            //amw.textUsername.IsEnabled = false;
            //amw.textAccType.Text = SelectedItem.AccType.ToString();
            amw.ShowDialog();
            amw.btnCreate.Visibility = Visibility.Hidden;
            amw.btnCreate.IsEnabled = false;
            amw.btSave.Visibility = Visibility.Visible;
        }
    }
}
