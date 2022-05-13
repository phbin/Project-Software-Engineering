using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDaQuy.Models
{
    class Account
    {
        private int ID;
        private string UserName;
        private string Pass;
        private int Acctype = 0; 

        public int IdAccount { get => ID; set => ID = value; }
        
        public string Username { get => UserName; set => UserName = value; }   
        public string Password { get => Pass; set => Pass = value; }

        public int AccType { get => Acctype; set => Acctype = value; }
        public Account(int ID, string UserName, string Pass, int Acctype)
        {
            this.ID = ID;
            this.UserName = UserName;
            this.Pass = Pass;
            this.Acctype = Acctype;
        }
    }

}
