using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for ReportYear.xaml
    /// </summary>
    public class global
    {
        #region Public Variable
        public static string month = "";
        public static string year = "";
        public static string day = "";
        #endregion
    } 
    public partial class ReportYear : System.Windows.Window, INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public LiveCharts.SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public ReportYear()
        {
            InitializeComponent();
            DataContext = this;
            loadChartYear();
            loadListYear();
        }
        double S = 0, tam = 0;
        private void loadChartYear()
        {
            double S1 = 0, S2 = 0, S3 = 0, S4 = 0, S5 = 0, S6 = 0, S7 = 0, S8 = 0, S9 = 0, S10 = 0, S11 = 0, S12 = 0;
            string month = "";
            S = TotalYear(S);
            tb_Total.Text = string.Format("{0:#,##0}" + " VND", S);
            //tb_Lai.Text = string.Format("{0:#,##0}" + " VND", S - S / 1.05);
            S1 = TotalMonth(S1, month = "1");
            S2 = TotalMonth(S2, month = "2");
            S3 = TotalMonth(S3, month = "3");
            S4 = TotalMonth(S4, month = "4");
            S5 = TotalMonth(S5, month = "5");
            S6 = TotalMonth(S6, month = "6");
            S7 = TotalMonth(S7, month = "7");
            S8 = TotalMonth(S8, month = "8");
            S9 = TotalMonth(S9, month = "9");
            S10 = TotalMonth(S10, month = "10");
            S11 = TotalMonth(S11, month = "11");
            S12 = TotalMonth(S12, month = "12");
            SeriesCollection = new LiveCharts.SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> {  S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12 }
                }
            };
            Labels = new[] { "January", "February", "March", "April", "May", "June", "Juny", "August", "September", "October", "November", "December" };
        }
        private double TotalMonth(double S, string month)
        {
            var strConn = @"Data Source=TIENTHINH\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
            SqlConnection sqlConn = null;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            var sqlCommand = new SqlCommand("SELECT Total FROM ITEMS WHERE YEAR(DateSell)=2022 AND MONTH(DateSell)=" + month, sqlConn);
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
        void loadListYear()
        {
            var strConn = @"Data Source=TIENTHINH\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
            SqlConnection sqlConn = null;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            var sqlCommand = new SqlCommand("SELECT DISTINCT YEAR(DateSell) FROM ITEMS ORDER BY YEAR(DateSell) ASC", sqlConn);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                cb_Year.Items.Add(reader[0].ToString());
            }
            reader.Close();
            sqlConn.Close();
        }

        private void btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            if (cb_Month.Text == "" || cb_Year.Text == "")
            {
                MessageBox.Show("Please choose month and year!");
            }
            else
            {
                global.month = cb_Month.Text;
                global.year = cb_Year.Text;
                ReportMonth reportMonth = new ReportMonth();
                reportMonth.Show();
                this.Close();
            }
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            Range myRange1 = (Range)sheet1.Cells[3, 1];
            sheet1.Cells[3, 1].Font.Bold = true;
            sheet1.Columns[1].ColumnWidth = 30;
            myRange1.Value2 = "Month";

            Range myRange2 = (Range)sheet1.Cells[3, 2];
            sheet1.Cells[3, 2].Font.Bold = true;
            sheet1.Columns[2].ColumnWidth = 30;
            myRange2.Value2 = "Total (VND)";

            sheet1.Range[sheet1.Cells[1, 1], sheet1.Cells[1, 2]].Merge();
            Range TitleExcel = (Range)sheet1.Cells[1, 1];
            TitleExcel.Value2 = "Revenue Statement of 2022";
            sheet1.Cells[1, 1].Font.Bold = true;
            sheet1.Cells[1, 1].Font.Size = 18;
            sheet1.get_Range("A1", "B3").Cells.HorizontalAlignment =
                 Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            int r = 3;
            for (int i = 1; i <= 12; i++)
            {
                string x = "";
                Range myRange = (Range)sheet1.Cells[r + 1, 1];
                myRange.Value2 = i;
                myRange = (Range)sheet1.Cells[r + 1, 2];
                myRange.Value2 = TotalMonth(tam, x = i.ToString());
                r++;
            }
            Range myRange3 = (Range)sheet1.Cells[r + 1, 1];
            myRange3.Value2 = "                                                ------------";
            myRange3 = (Range)sheet1.Cells[r + 1, 2];
            myRange3.Value2 = "                                                ------------";
            r++;
            Range myRange4 = (Range)sheet1.Cells[r + 1, 1];
            myRange4.Value2 = "                                                       Total: ";
            myRange4 = (Range)sheet1.Cells[r + 1, 2];
            myRange4.Value2 = S;
        }
    }
}
