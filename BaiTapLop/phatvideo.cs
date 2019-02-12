using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLop
{
    public partial class phatvideo : Form
    {
        public string url { get; set; }
        public phatvideo()
        {
            InitializeComponent();
            youtube.Movie = url.Trim();
        }

        void xulychuoi(string s)
        {
            if (s.Contains("watch?"))
                s = s.Replace("watch?", "");
            if (s.Contains("v="))
                s = s.Replace("v=", "v/");
        }
    }
}
