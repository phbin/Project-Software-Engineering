using QuanLyCuaHangDaQuy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace QuanLyCuaHangDaQuy
{
    public class ConvertImage
    {
        private static ConvertImage instance;

        public static ConvertImage Instance
        {
            get { if (instance == null) instance = new ConvertImage(); return ConvertImage.instance; }
            private set { ConvertImage.instance = value; }
        }
        private ConvertImage()
        {

        }
        // image -> byte, insert image into database
        public void imageToByteArray(string path, string id)
        {
            string query = "update Movie set Poster = (select * from openrowset(bulk N'" + path + "', single_blob) as img) where ID = '" + id + "'";
            DataProvider.Ins.ExecuteQuery(query);
        }
        // byte[] -> image, get image from database
        public static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
