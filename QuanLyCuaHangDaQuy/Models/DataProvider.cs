using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangDaQuy.Models
{
    public class DataProvider
    {
        private static DataProvider _ins;

        public static DataProvider Ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set { _ins = value; } }
        public CuaHangDaQuyEntities DB { get; set; }
        private DataProvider()
        {
            DB = new CuaHangDaQuyEntities();
        }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
           

                SqlCommand command = new SqlCommand(query);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter apdater = new SqlDataAdapter(command);

                apdater.Fill(data);

           
            return data;
        }
    }
}
