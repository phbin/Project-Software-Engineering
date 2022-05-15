using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace QuanLyCuaHangDaQuy.Views
{
    /// <summary>
    /// Interaction logic for ReportDay.xaml
    /// </summary>
    public partial class ReportDay : System.Windows.Window
    {
        public ReportDay()
        {
            InitializeComponent();
            DataContext = this;
            loadDTThang();
            tb_Title.Text = " REVENUE STATEMENT OF " + global.day + "/" + global.month + "/" + global.year;
        }
        double Sy = 0, Sd=0, Sm = 0;
        private void loadDTThang()
        {
            Sm = TotalMonth(Sm);
            Sy = TotalYear(Sy);
            Sd = TotalDay(Sd);
            tb_TotalYear.Text = string.Format("{0:#,##0}" + " VND", Sy);
            tb_TotalMonth.Text = string.Format("{0:#,##0}" + " VND", Sm);
            tb_TotalDay.Text = string.Format("{0:#,##0}" + " VND", Sd);
        }

        private double TotalDay(double S)
        {
            var strConn = @"Data Source=TIENTHINH\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
            SqlConnection sqlConn = null;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            var sqlCommand = new SqlCommand("SELECT Total FROM ITEMS WHERE YEAR(DateSell)='" + global.year + "' AND MONTH(DateSell)='" + global.month + "' AND DAY(DateSell)='" + global.day + "'", sqlConn);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                S += double.Parse(reader[0].ToString());
            }
            reader.Close();
            sqlConn.Close();
            return S;
        }

        private void btn_BackYear_Click(object sender, RoutedEventArgs e)
        {
            ReportYear reportYear = new ReportYear();
            reportYear.Show();
            this.Show();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            ReportMonth reportMonth = new ReportMonth();
            reportMonth.Show();
            this.Show();
        }

        double TotalMonth(double S)
        {
            var strConn = @"Data Source=TIENTHINH\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
            SqlConnection sqlConn = null;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            var sqlCommand = new SqlCommand("SELECT Total FROM ITEMS WHERE YEAR(DateSell)='" + global.year + "' AND MONTH(DateSell)='" + global.month + "'", sqlConn);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                S += double.Parse(reader[0].ToString());
            }
            reader.Close();
            sqlConn.Close();
            return S;
        }
        double TotalYear(double S)
        {
            var strConn = @"Data Source=TIENTHINH\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
            SqlConnection sqlConn = null;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            var sqlCommand = new SqlCommand("SELECT Total FROM ITEMS WHERE YEAR(DateSell)=2022", sqlConn);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                S += double.Parse(reader[0].ToString());
            }
            reader.Close();
            sqlConn.Close();
            return S;
        }
    }
}
