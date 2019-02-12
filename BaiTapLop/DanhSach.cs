using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace BaiTapLop
{
    public partial class DanhSach : Form
    {
        public static string link = Directory.GetCurrentDirectory().ToString() + @"\dbnhac.db";
        SQLiteConnection qLiteConnection = new SQLiteConnection("Data Source = "+link);
        public int Loai=0;
        public string Chuoi = "";
        SQLiteDataAdapter sQLiteDataAdapter;
        DataTable dataTable = new DataTable();
        public List<string> timkiem;
        ListNhac list = new ListNhac();
        public DanhSach()
        {
            InitializeComponent();
        }

        public int MessageLoai
        {
            get { return Loai; }
            set { Loai = value; }
        }

        public List<string> Messegetimkiem
        {
            get { return timkiem; }
            set { timkiem = value; }
        }

        private void DanhSach_Load(object sender, EventArgs e)
        {
            if (MessageLoai == 0)
            {
                listView1.Clear();
                foreach (string s in Messegetimkiem)
                {
                    listView1.Items.Add(s);
                }
            }
            else
            {
                qLiteConnection.Open();
                string collum = "";
                switch (MessageLoai)
                {
                    case 31:Chuoi = "Nhạc Trẻ"; collum = "Topic"; break;
                    case 32: Chuoi = "K-POP"; collum = "Topic"; break;
                    case 33: Chuoi = "Nhạc Không Lời"; collum = "Topic"; break;
                    case 51: Chuoi = "Việt Nam"; collum = "Nation"; break;
                    case 52: Chuoi = "Âu - Mỹ"; collum = "Nation"; break;
                    case 53: Chuoi = "Hàn Quốc"; collum = "Nation"; break;
                    case 54: Chuoi = "Nhiều"; collum = "Nation"; break;
                }
                sQLiteDataAdapter = new SQLiteDataAdapter("select * from Nhac where "+collum+" = '" + Chuoi + "'", qLiteConnection);
                Show(sQLiteDataAdapter);
                qLiteConnection.Close();
            }
        }

        public void Show(SQLiteDataAdapter sQLiteDataAdapter)
        {
            sQLiteDataAdapter.Fill(dataTable);
            listView1.View = View.List;
            foreach (DataRow row in dataTable.Rows)
            {
                listView1.Items.Add(row["Name"].ToString());
                list.lyricBH.Add(row["Lyric"].ToString());
                list.MVBH.Add(row["MV"].ToString());
                list.UrlBH.Add(row["URI"].ToString());
                list.TenBH.Add(row["Name"].ToString());

            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhatNhac phatNhac = new PhatNhac();
            if (listView1.SelectedItems.Count > 0)
            {
                phatNhac.MessageIndex = listView1.SelectedItems[0].Index;
            }
            else return;
            phatNhac.MVs = list.MVBH;
            phatNhac.Lyric = list.lyricBH;
            phatNhac.MessageURL = list.UrlBH;
            phatNhac.MessageTen = list.TenBH;
            phatNhac.Show();
            phatNhac.TopMost = true;
        }
    }
}
