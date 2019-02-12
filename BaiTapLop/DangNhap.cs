using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace BaiTapLop
{
    public partial class DangNhap : Form
    {
        public static string link = Directory.GetCurrentDirectory().ToString() + @"\dbnhac.db";
        List<string> ListTK = new List<string>();
        List<string> ListMK = new List<string>();
        SQLiteConnection qLiteConnection = new SQLiteConnection("Data Source = "+link);

        public int ttdn = 0;
        public DangNhap()
        {
            InitializeComponent();
            
        }
        public int MessageDN
        {
            get { return ttdn; }
            set { ttdn = value; }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (txttendangnnhap.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Nhập tên đăng nhập!");
                txttendangnnhap.Focus();
            }
            else if (txtmatkhau.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Nhập mật khẩu!");
                txtmatkhau.Focus();
            }
            else
            {
                qLiteConnection.Open();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter("Select * from TaiKhoan", qLiteConnection);

                DataTable dataTable = new DataTable();
                sQLiteDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    ListTK.Add(row["TaiKhoan"].ToString());
                    ListMK.Add(row["MatKhau"].ToString());
                }
                if(CheckTK() ==0)
                {
                    MessageBox.Show("Sai tài khoản, mời nhập lại!");
                    txttendangnnhap.Focus();
                }
                else if (CheckMK() == 0)
                {
                    MessageBox.Show("Sai mật khẩu, mời nhập lại!");
                    txtmatkhau.Focus();
                }
                else
                {
                    MessageBox.Show("Thành công!");
                    ttdn = 1;
                    this.Close();
                }
                
            }
            qLiteConnection.Close();
        }

        public int CheckTK()
        {
            foreach (string s in ListTK)
            {
                if(txttendangnnhap.Text.CompareTo(s)==0)
                    return 1;
            }
            return 0;
        }
        public int CheckMK()
        {
            foreach (string s in ListMK)
            {
                if (txtmatkhau.Text.CompareTo(s) == 0)
                    return 1;
            }
            return 0;
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            if(txttendangnnhap.Text.CompareTo("")==0)
            {
                MessageBox.Show("Nhập tên đăng nhập!");
                txttendangnnhap.Focus();
            }
            else if(txtmatkhau.Text.CompareTo("")==0)
            {
                MessageBox.Show("Nhập mật khẩu!");
                txtmatkhau.Focus();
            }
            else
            {

                qLiteConnection.Open();
                string tk = txttendangnnhap.Text;
                string mk = txtmatkhau.Text;
                string sql = "Insert into TaiKhoan(STT, TaiKhoan, MatKhau) values(@STT,@TaiKhoan,@MatKhau)";
                
                SQLiteCommand sQLiteCommand = new SQLiteCommand(sql, qLiteConnection);
                sQLiteCommand.Parameters.AddWithValue("@STT",null);
                sQLiteCommand.Parameters.AddWithValue("@TaiKhoan", tk);
                sQLiteCommand.Parameters.AddWithValue("@MatKhau", mk);
                sQLiteCommand.ExecuteNonQuery();
                label3.Text = "Đăng ký thành công";
                ttdn = 1;
                qLiteConnection.Close();
            }
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
