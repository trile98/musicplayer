namespace BaiTapLop
{
    partial class PhatNhac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhatNhac));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnmv = new System.Windows.Forms.Button();
            this.lblloibaihat = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(12, 12);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(579, 442);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listView1.Location = new System.Drawing.Point(605, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(375, 772);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(555, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 33);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 726);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(992, 23);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnmv
            // 
            this.btnmv.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnmv.BackgroundImage")));
            this.btnmv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnmv.Enabled = false;
            this.btnmv.Location = new System.Drawing.Point(513, 421);
            this.btnmv.Name = "btnmv";
            this.btnmv.Size = new System.Drawing.Size(36, 33);
            this.btnmv.TabIndex = 5;
            this.btnmv.UseVisualStyleBackColor = true;
            this.btnmv.Click += new System.EventHandler(this.btnmv_Click);
            // 
            // lblloibaihat
            // 
            this.lblloibaihat.Location = new System.Drawing.Point(12, 460);
            this.lblloibaihat.Multiline = true;
            this.lblloibaihat.Name = "lblloibaihat";
            this.lblloibaihat.ReadOnly = true;
            this.lblloibaihat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblloibaihat.Size = new System.Drawing.Size(579, 263);
            this.lblloibaihat.TabIndex = 6;
            // 
            // PhatNhac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(992, 749);
            this.Controls.Add(this.lblloibaihat);
            this.Controls.Add(this.btnmv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Name = "PhatNhac";
            this.Text = "PhatNhac";
            this.Load += new System.EventHandler(this.PhatNhac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnmv;
        private System.Windows.Forms.TextBox lblloibaihat;
    }
}