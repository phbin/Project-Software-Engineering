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
    public class Customer: BaseViewModel
    {
            public static ICommand DeleteCommand { get; set; }
            public static ICommand EditCommand { get; set; }
            private int _no;
            private string _id;
            private string _fullname;
            private DateTime _dob;
            private string _dob_format;
            private string _email;
            private string _phone;
            private long _idpersonal;
            private int? _points;
            public int No
            {
                get
                {
                    return _no;
                }
                set
                {
                    _no = value;
                    OnPropertyChanged(nameof(No));
                }
            }
            public string ID
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
            public string FullName
            {
                get
                {
                    return _fullname;
                }
                set
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
            public DateTime DoB
            {
                get
                {
                    return _dob;
                }
                set
                {
                    _dob = value;
                    OnPropertyChanged(nameof(DoB));
                }
            }
            public string DoB_Format
            {
                get
                {
                    return _dob_format;
                }
                set
                {
                    _dob_format = value;
                    OnPropertyChanged(nameof(DoB_Format));
                }
            }
            public string Email
            {
                get
                {
                    return _email;
                }
                set
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
            public string Phone
            {
                get
                {
                    return _phone;
                }
                set
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
            public long IDPersonal
            {
                get
                {
                    return _idpersonal;
                }
                set
                {
                    _idpersonal = value;
                    OnPropertyChanged(nameof(IDPersonal));
                }
            }
            public int? Points
            {
                get
                {
                    return _points;
                }
                set
                {
                    _points = value;
                    OnPropertyChanged(nameof(Points));
                }
            }
        }
}
