﻿using QuanLyCuaHangDaQuy.Views;
using QuanLyCuaHangDaQuy.Models;
using QuanLyCuaHangDaQuy.ViewModels;
using QuanLyCuaHangDaQuy.Resources.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using System.Data;
using System.Collections.ObjectModel;


namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class ProviderViewModel : BaseViewModel
    {
        public ProviderViewModel()
        {
        }
        public void OpenProviderManagertWindow(int flag = 0)
        {
            if (flag == 0)
            {
                ProviderManagerWindow providermanagerWindow = new ProviderManagerWindow();
                {

                };
                providermanagerWindow.ShowDialog();
            }
            else if (flag == 1)
            {

            }

        }
    }

}