using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDaQuy.ViewModels
{
    public class Customer: BaseViewModel
    {
            private int _no;
            private string _id;
            private string _fullname;
            private DateTime _dob;
            private string _dob_format;
            private string _email;
            private string _phone;
            private long _idpersonal;
            private int? _points;
            private string _color;
            public string Colorr
            {
                get { return _color; }
                set
                {
                    _color = value;
                    OnPropertyChanged(nameof(_color));
                }
            }
            public int No
            {
                get
                {
                    return _no;
                }
                set
                {
                    _no = value;
                    OnPropertyChanged(nameof(_no));
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
                    OnPropertyChanged(nameof(_id));
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
                    OnPropertyChanged(nameof(_fullname));
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
                    OnPropertyChanged(nameof(_dob));
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
                    OnPropertyChanged(nameof(_dob_format));
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
                    OnPropertyChanged(nameof(_email));
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
                    OnPropertyChanged(nameof(_phone));
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
                    OnPropertyChanged(nameof(_idpersonal));
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
                    OnPropertyChanged(nameof(_points));
                }
            }
        }
}
