using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Office.Interop.Excel;
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

namespace QuanLyCuaHangDaQuy.Views.Admin
{
    /// <summary>
    /// Interaction logic for ReportAdmin.xaml
    /// </summary>
    public class global
    {
        #region Public Variable
        public static string month = "" + DateTime.Now.Month.ToString();
        public static string year = "" + DateTime.Now.Year.ToString();
        #endregion
    }
    public partial class ReportAdmin : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LiveCharts.SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public ReportAdmin()
        {
            InitializeComponent();
            DataContext = this;
            loadListYear();
            loadChartMonth();
        }
        double Sy = 0, Sm = 0, tam = 0;
        void loadListYear()
        {
            var strConn = @"Data Source=.\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
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
        private void loadChartMonth()
        {
            double S1 = 0, S2 = 0, S3 = 0, S4 = 0, S5 = 0, S6 = 0, S7 = 0, S8 = 0, S9 = 0, S10 = 0, S11 = 0, S12 = 0, S13 = 0, S14 = 0, S15 = 0, S16 = 0, S17 = 0, S18 = 0, S19 = 0, S20 = 0, S21 = 0, S22 = 0, S23 = 0, S24 = 0, S25 = 0, S26 = 0, S27 = 0, S28 = 0, S29 = 0, S30 = 0, S31 = 0;
            string day = "";
            Sm = TotalMonth(Sm);
            tb_Total.Text = string.Format("{0:#,##0}" + " VND", Sm);
            S1 = TotalDay(S1, day = "1");
            S2 = TotalDay(S2, day = "2");
            S3 = TotalDay(S3, day = "3");
            S4 = TotalDay(S4, day = "4");
            S5 = TotalDay(S5, day = "5");
            S6 = TotalDay(S6, day = "6");
            S7 = TotalDay(S7, day = "7");
            S8 = TotalDay(S8, day = "8");
            S9 = TotalDay(S9, day = "9");
            S10 = TotalDay(S10, day = "10");
            S11 = TotalDay(S11, day = "11");
            S12 = TotalDay(S12, day = "12");
            S13 = TotalDay(S13, day = "13");
            S14 = TotalDay(S14, day = "14");
            S15 = TotalDay(S15, day = "15");
            S16 = TotalDay(S16, day = "16");
            S17 = TotalDay(S17, day = "17");
            S18 = TotalDay(S18, day = "18");
            S19 = TotalDay(S19, day = "19");
            S20 = TotalDay(S20, day = "20");
            S21 = TotalDay(S21, day = "21");
            S22 = TotalDay(S22, day = "22");
            S23 = TotalDay(S23, day = "23");
            S24 = TotalDay(S24, day = "24");
            S25 = TotalDay(S25, day = "25");
            S26 = TotalDay(S26, day = "26");
            S27 = TotalDay(S27, day = "27");
            S28 = TotalDay(S28, day = "28");
            S29 = TotalDay(S29, day = "29");
            S30 = TotalDay(S30, day = "30");
            S31 = TotalDay(S31, day = "31");
            SeriesCollection = new LiveCharts.SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> {  S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12,S13,S14,S15,S16,S17,S18,S19,S20,S21,S22,S23,S24,S25,S26,S27,S28,S29,S30,S31 }
                }
            };
            Labels = new[] { "Day 1", "Day 2", "Day 3", "Day 4", "Day 5", "Day 6", "Day 7", "Day 8", "Day 9", "Day 10", "Day 11", "Day 12", "Day 13", "Day 14", "Day 15", "Day 16", "Day 17", "Day 18", "Day 19", "Day 20", "Day 21", "Day 22", "Day 23", "Day 24", "Day 25", "Day 26", "Day 27", "Day 28", "Day 29", "Day 30", "Day 31" };
        }
        private double TotalDay(double S, string ngay)
        {
            var strConn = @"Data Source=.\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
            SqlConnection sqlConn = null;
            sqlConn = new SqlConnection(strConn);
            sqlConn.Open();
            var sqlCommand = new SqlCommand("SELECT Total FROM ITEMS WHERE YEAR(DateSell)='" + global.year + "' AND MONTH(DateSell)='" + global.month + "' AND DAY(DateSell)='" + ngay + "'", sqlConn);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                S += double.Parse(reader[0].ToString());
            }
            reader.Close();
            sqlConn.Close();
            return S;
        }
        double TotalMonth(double S)
        {
            var strConn = @"Data Source=.\SQLEXPRESS;Initial Catalog=CuaHangDaQuy;Integrated Security=True";
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
                //ReportAdmin reportyear = new ReportAdmin();
                loadListYear();
                loadChartMonth();
                //this.Close();
            }
        }
        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            Range myRange1 = (Range)sheet1.Cells[3, 1];
            sheet1.Cells[3, 1].Font.Bold = true;
            sheet1.Columns[1].ColumnWidth = 40;
            myRange1.Value2 = "Day";

            Range myRange2 = (Range)sheet1.Cells[3, 2];
            sheet1.Cells[3, 2].Font.Bold = true;
            sheet1.Columns[2].ColumnWidth = 40;
            myRange2.Value2 = "Revenue (VND)";

            sheet1.Range[sheet1.Cells[1, 1], sheet1.Cells[1, 2]].Merge();
            Range TitleExcel = (Range)sheet1.Cells[1, 1];
            TitleExcel.Value2 = "Revenue Statement of " + global.month + ", " + global.year;
            sheet1.Cells[1, 1].Font.Bold = true;
            sheet1.Cells[1, 1].Font.Size = 18;
            sheet1.get_Range("A1", "B3").Cells.HorizontalAlignment =
                 Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            int r = 3;
            for (int i = 1; i <= 31; i++)
            {
                string x = "";
                Range myRange = (Range)sheet1.Cells[r + 1, 1];
                myRange.Value2 = i;
                myRange = (Range)sheet1.Cells[r + 1, 2];
                myRange.Value2 = TotalDay(tam, x = i.ToString());
                r++;
            }
            Range myRange3 = (Range)sheet1.Cells[r + 1, 1];
            myRange3.Value2 = "                                                                    ------------";
            myRange3 = (Range)sheet1.Cells[r + 1, 2];
            myRange3.Value2 = "                                                                    ------------";
            r++;
            Range myRange4 = (Range)sheet1.Cells[r + 1, 1];
            myRange4.Value2 = "                                                                    Total: ";
            myRange4 = (Range)sheet1.Cells[r + 1, 2];
            myRange4.Value2 = Sm;
        }
    }
}
