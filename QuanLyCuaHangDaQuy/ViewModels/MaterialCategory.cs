using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class MaterialCategory:BaseViewModel
    {
        public static ICommand DeleteCommand { get; set; }
        public static ICommand EditCommand { get; set; }

        private int _no;
        public int No { get { return _no; } set { _no = value; OnPropertyChanged(nameof(No)); } }

        private string _iD;
        public string ID { get { return _iD; } set { _iD = value; OnPropertyChanged(nameof(ID)); } }

        private string _nameMaterial;
        public string NameMaterial { get { return _nameMaterial; } set { _nameMaterial = value; OnPropertyChanged(nameof(NameMaterial)); } }

        private double? _profit;
        public double? Profit { get { return _profit; } set { _profit = value; OnPropertyChanged(nameof(Profit)); } }



    }
}
