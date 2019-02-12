using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLop
{
    public partial class report : Form
    {
        public static string link = Directory.GetCurrentDirectory().ToString() + @"\dbnhac.db";
        SQLiteConnection qLiteConnection = new SQLiteConnection("Data Source=" + link);
        SQLiteDataAdapter qLiteDataAdapter;
        DataTable dataTable;
        public report()
        {
            InitializeComponent();
            qLiteConnection.Open();
            qLiteDataAdapter = new SQLiteDataAdapter("Select * from Nhac join TaiKhoan", qLiteConnection);
            dataTable = new DataTable();
            qLiteDataAdapter.Fill(dataTable);

            reportNhac1.SetDataSource (dataTable);
            crystalReportViewer1.ReportSource = reportNhac1;
        }
    }
}
