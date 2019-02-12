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
    public partial class Form1 : Form
    {
        
        public int Loai;
        List<string> timkiem = new List<string>();
        DangNhap dangNhap;
        public static string link = Directory.GetCurrentDirectory().ToString()+ @"\dbnhac.db";
        ListNhac listKP = new ListNhac();
        ListNhac listNT = new ListNhac();
        ListNhac listKL = new ListNhac();
        SQLiteDataAdapter qLiteDataAdapter;
        DataTable dataTable;

        SQLiteConnection qLiteConnection = new SQLiteConnection("Data Source="+link);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int nt = 0,kp=0,kl=0,vi=0;
            dangNhap = new DangNhap();
            
            btndangxuat.Enabled = false;
            btndangnhap.Enabled = true;
            nhạcCáNhânToolStripMenuItem.Enabled = false;

            qLiteConnection.Open();
            qLiteDataAdapter = new SQLiteDataAdapter("Select * from Nhac where Rank > 0", qLiteConnection);
            dataTable = new DataTable();
            qLiteDataAdapter.Fill(dataTable);
            
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Topic"].ToString() == "Nhạc Trẻ")
                {

                    MemoryStream ms = new MemoryStream((byte[]) row["img"]);
                    //dat key cho tung hinh
                    imageList1.Images.Add("NT"+nt.ToString(), new Bitmap(ms));
                    listviewBXH.LargeImageList = imageList1;

                    var listviewitem = listviewBXH.Items.Add(row["Name"].ToString(), 0);
                    //set key cho tung dong
                    listviewitem.ImageKey = "NT" + nt.ToString();

                    listNT. UrlBH.Add(row["URI"].ToString());
                    listNT.TenBH.Add(row["Name"].ToString());
                    listNT.MVBH.Add(row["MV"].ToString());
                    listNT.lyricBH.Add(row["Lyric"].ToString());
                    nt++;

                }
                else if (row["Topic"].ToString() == "K-POP")
                {
                    MemoryStream ms = new MemoryStream((byte[])row["img"]);

                    imageList1.Images.Add("KP" + kp.ToString(), new Bitmap(ms));
                    listviewBXH3.LargeImageList = imageList1;

                    var listviewitem = listviewBXH3.Items.Add(row["Name"].ToString(), 0);

                    listviewitem.ImageKey = "KP" + kp.ToString();

                    listKP.UrlBH.Add(row["URI"].ToString());
                    listKP.TenBH.Add(row["Name"].ToString());
                    listKP.MVBH.Add(row["MV"].ToString());
                    listKP.lyricBH.Add(row["Lyric"].ToString());
                    kp++;
                }
                else if (row["Topic"].ToString() == "Nhạc Không Lời")
                {
                    MemoryStream ms = new MemoryStream((byte[])row["img"]);

                    imageList1.Images.Add("KL" + kl.ToString(), new Bitmap(ms));
                    listviewBXH2.LargeImageList = imageList1;

                    var listviewitem = listviewBXH2.Items.Add(row["Name"].ToString(), 0);

                    listviewitem.ImageKey = "KL" + kl.ToString();

                    listKL.UrlBH.Add(row["URI"].ToString());
                    listKL.TenBH.Add(row["Name"].ToString());
                    listKL.MVBH.Add(row["MV"].ToString());
                    listKL.lyricBH.Add(row["Lyric"].ToString());
                    kl++;
                }

            }

            qLiteDataAdapter = new SQLiteDataAdapter("Select Name,img,mv,Singer,Lyric from Nhac where MV is not null", qLiteConnection);
            dataTable = new DataTable();
            qLiteDataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                MemoryStream ms = new MemoryStream((byte[])row["img"]);

                imageList1.Images.Add("VI" + vi.ToString(), new Bitmap(ms));
                listViewVideo.LargeImageList = imageList1;

                var listviewitem = listViewVideo.Items.Add(row["Name"].ToString(), 0);

                listviewitem.ImageKey = "VI" + vi.ToString();

                

                listViewVideo.Items[vi].Text = String.Format("{0} - {1}", row["Name"].ToString(), row["Singer"].ToString());
                
                vi++;
            }

            qLiteConnection.Close();
        
        }

        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dangNhap.MessageDN == 1)
            {
                nhạcCáNhânToolStripMenuItem.Enabled = true;
                btndangxuat.Enabled = true;
                btndangnhap.Enabled = false;
            }
            dangNhap = new DangNhap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            SQLiteDataAdapter qLiteDataAdapter = new SQLiteDataAdapter("Select Name from Nhac", qLiteConnection);
            DataTable dataTable = new DataTable();
            qLiteDataAdapter.Fill(dataTable);
            //listView1.View = View.Tile;
            foreach (DataRow r in dataTable.Rows)
            {
                if(r["Name"].ToString().ToLower().Contains(textBox1.Text))
                {
                    timkiem.Add(r["Name"].ToString());
                }
            }
            danhSach.Messegetimkiem = timkiem;
            danhSach.MessageLoai = 0;
            danhSach.Show();
        }

        private void dangnhap_Click(object sender, EventArgs e)
        {
            dangNhap.FormClosed += new FormClosedEventHandler(child_FormClosed);

            dangNhap.Show();
        }

        private void listviewBXH_SelectedIndexChanged(object sender, EventArgs e)
        {

            PhatNhac phatNhac = new PhatNhac();
            if (listviewBXH.SelectedItems.Count > 0)
            {
                phatNhac.MessageIndex = listviewBXH.SelectedIndices[0];
            }
            else return;
            phatNhac.MVs = listNT.MVBH;
            phatNhac.Lyric = listNT.lyricBH;
            phatNhac.MessageURL = listNT.UrlBH;
            phatNhac.MessageTen = listNT.TenBH;
            phatNhac.Show();
            phatNhac.TopMost = true; 
         
            
        }
        private void listviewBXH3_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhatNhac phatNhac = new PhatNhac();
            if (listviewBXH3.SelectedItems.Count > 0)
            {
                phatNhac.MessageIndex = listviewBXH3.SelectedIndices[0];
            }
            else return;
            phatNhac.MVs = listKP.MVBH;
            phatNhac.Lyric = listKP.lyricBH;
            phatNhac.MessageURL = listKP.UrlBH;
            phatNhac.MessageTen = listKP.TenBH;

            phatNhac.Show();
            phatNhac.TopMost = true;
        }
        private void listviewBXH2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhatNhac phatNhac = new PhatNhac();
            if (listviewBXH2.SelectedItems.Count > 0)
            {
                phatNhac.MessageIndex = listviewBXH2.SelectedItems[0].Index;
            }
            else return;
            phatNhac.MVs =listKL. MVBH;
            phatNhac.Lyric = listKL.lyricBH;
            phatNhac.MessageURL = listKL.UrlBH;
            phatNhac.MessageTen = listKL.TenBH;
            phatNhac.Show();
            phatNhac.TopMost = true;
        }

        private void nhạcCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CaNhan caNhan = new CaNhan();
            caNhan.Show();
        }

        private void thưGiãnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            danhSach.MessageLoai = 33;
            danhSach.Show();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công!");
            Form1_Load(sender, e);
            //btndangnhap.Enabled = true;
            //nhạcCáNhânToolStripMenuItem.Enabled = false;
        }


        private void việtNamToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            danhSach.MessageLoai = 51;
            danhSach.Show();
        }

        private void âuMỹToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            danhSach.MessageLoai = 52;
            danhSach.Show();
        }

        private void hànQuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            danhSach.MessageLoai = 53;
            danhSach.Show();
        }

        private void nhậtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            danhSach.MessageLoai = 54;
            danhSach.Show();
        }

        private void tìnhYêuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            danhSach.MessageLoai = 31;
            danhSach.Show();
        }

        private void kPOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSach danhSach = new DanhSach();
            danhSach.MessageLoai = 32;
            danhSach.Show();
        }

        private void listViewVideo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnrpt_Click(object sender, EventArgs e)
        {
            report rpt = new report();
            rpt.Show();
        }
    }
}
