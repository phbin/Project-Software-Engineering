using QuanLyCuaHangDaQuy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    internal class ExitButtonViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }

        public ExitButtonViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; },
                                                                        (p) =>
                                                                        {
                                                                            FrameworkElement window = GetWindowParent(p);
                                                                            var w = window as Window;
                                                                            if (w != null)
                                                                            {
                                                                                w.Close();
                                                                            }

                                                                        });
        }
        FrameworkElement GetWindowParent(UserControl p)
        {
            return Window.GetWindow(p);
        }

    }

}