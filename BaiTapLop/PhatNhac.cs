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
using WMPLib;

namespace BaiTapLop
{
    public partial class PhatNhac : Form
    {
        int index;
        string UrlBH;
        string filename;  
        List<string> URL = new List<string>();
        List<string> Ten = new List<string>();
        public static string link = Directory.GetCurrentDirectory().ToString() + @"\dbnhac.db";
        SQLiteConnection qLiteConnection = new SQLiteConnection("Data Source ="+link);
        ImageList imglist = new ImageList();
        public static string l = Directory.GetCurrentDirectory().ToString()+"\\";
        
        public PhatNhac()
        {
            InitializeComponent();
        }
        string mvhienhanh;
        public List<string> Lyric { get; set; }
        public List<string> MVs { get; set; }
        public List<string> MessageURL
        {
            get { return URL; }
            set { URL = value; }
        }
        public List<string> MessageTen
        {
            get { return Ten; }
            set { Ten = value; }
        }
        public int MessageIndex
        {
            get { return index; }
            set { index = value; }
        }

 

   
        private void PhatNhac_Load(object sender, EventArgs e)
        {
          

            IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
            IWMPMedia media;
            UrlBH = MessageURL[MessageIndex];
            string Link = @"nhac\";
            Link += ("" + MessageURL[MessageIndex] + ".mp3");

            foreach (string item in MessageURL)
            {
                media = axWindowsMediaPlayer1.newMedia(link);
                playlist.appendItem(media);
            }
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            foreach(string s in MessageTen)
            {
                listView1.Items.Add(s);
            }
            axWindowsMediaPlayer1.URL = Link;
            lblloibaihat.Text = Lyric[MessageIndex].ToString();
            
            axWindowsMediaPlayer1.Ctlcontrols.play();
          
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.stop();
            string Link = @"nhac\";
            if (listView1.SelectedItems.Count > 0)
            {
                Link +=  MessageURL[listView1.SelectedIndices[0]] + ".mp3";
                axWindowsMediaPlayer1.URL = Link;
                UrlBH = MessageURL[listView1.SelectedIndices[0]];
                lblloibaihat.Text = Lyric[listView1.SelectedIndices[0]].ToString();
                mvhienhanh = MVs[listView1.SelectedIndices[0]].ToString();
                if (MVs[listView1.SelectedIndices[0]].ToString()!="")
                {
                    btnmv.Enabled = true;
                    filename = MVs[listView1.SelectedIndices[0]].ToString();
                }
            }
            else return;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            qLiteConnection.Open();
            SQLiteCommand qLiteCommand = new SQLiteCommand("Update Nhac set Like = 1 where URI = '"+UrlBH+"'", qLiteConnection);
            qLiteCommand.ExecuteNonQuery();
            qLiteConnection.Close();
            label1.Text = "Đã thích!";
        }

        private void btnmv_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.Ctlcontrols.stop();
            //phatvideo video = new phatvideo();
            //video.url = mvhienhanh;
            if (filename != null)
            {
                string Link = @"mv\";
                Link += filename + ".mp4";
                axWindowsMediaPlayer1.URL = Link;
            }

        }
    }
}
