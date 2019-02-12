namespace BaiTapLop
{
    partial class phatvideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(phatvideo));
            this.youtube = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.youtube)).BeginInit();
            this.SuspendLayout();
            // 
            // youtube
            // 
            this.youtube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.youtube.Enabled = true;
            this.youtube.Location = new System.Drawing.Point(0, 0);
            this.youtube.Name = "youtube";
            this.youtube.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("youtube.OcxState")));
            this.youtube.Size = new System.Drawing.Size(800, 450);
            this.youtube.TabIndex = 0;
            // 
            // phatvideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.youtube);
            this.Name = "phatvideo";
            this.Text = "phatvideo";
            ((System.ComponentModel.ISupportInitialize)(this.youtube)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash youtube;
    }
}