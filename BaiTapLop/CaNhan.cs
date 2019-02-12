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
    public partial class CaNhan : Form
    {
        public static string link = Directory.GetCurrentDirectory().ToString() + @"\dbnhac.db";
        SQLiteConnection qLiteConnection = new SQLiteConnection("Data Source = " +link);
        List<int> sttn = new List<int>();
        SQLiteDataAdapter sQLiteDataAdapter;
        DataTable dataTable;
        ListNhac list= new ListNhac();
        ImageList imageList1= new ImageList();
        ListViewItem listviewitem;

        public CaNhan()
        {
            InitializeComponent();
        }

        private void CaNhan_Load(object sender, EventArgs e)
        {
            int cn = 0;
            qLiteConnection.Open();
            sQLiteDataAdapter = new SQLiteDataAdapter("Select Nhac from TaiKhoan", qLiteConnection);
            dataTable = new DataTable();
            sQLiteDataAdapter.Fill(dataTable);
            string[] ncn = dataTable.Rows[0]["Nhac"].ToString().Split(',');
            if (dataTable.Rows[0]["Nhac"].ToString().CompareTo("") == 0)
                MessageBox.Show("Khong co nhac ca nhan");
            else
                foreach (string item in ncn)
                {
                    sttn.Add(int.Parse(item));
                }

            foreach (int item in sttn)
            {
                sQLiteDataAdapter = new SQLiteDataAdapter("Select * from Nhac where STT="+item, qLiteConnection);
                dataTable = new DataTable();
                sQLiteDataAdapter.Fill(dataTable);

                MemoryStream ms = new MemoryStream((byte[])dataTable.Rows[0]["img"]);

                 imageList1.Images.Add("CN" + cn.ToString(), new Bitmap(ms));
                listView1.LargeImageList = imageList1;
                listviewitem = listView1.Items.Add(dataTable.Rows[0]["Name"].ToString());
                listviewitem.ImageKey = "CN" + cn;

                list.UrlBH.Add(dataTable.Rows[0]["URI"].ToString());
                list.TenBH.Add(dataTable.Rows[0]["Name"].ToString());
                list.MVBH.Add(dataTable.Rows[0]["MV"].ToString());
                list.lyricBH.Add(dataTable.Rows[0]["Lyric"].ToString());
                cn++;
            }
            qLiteConnection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhatNhac phatNhac = new PhatNhac();
            if (listView1.SelectedItems.Count > 0)
            {
                phatNhac.MessageIndex = listView1.SelectedIndices[0];
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
