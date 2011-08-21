namespace GoEarPlayer.View
{
    partial class PlayerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWindow));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.btNextSong = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArtistName = new System.Windows.Forms.TextBox();
            this.btChangeArtist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 96);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(124, 12);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(328, 96);
            this.mediaPlayer.TabIndex = 2;
            this.mediaPlayer.StatusChange += new System.EventHandler(this.mediaPlayer_StatusChange_1);
            // 
            // btNextSong
            // 
            this.btNextSong.Location = new System.Drawing.Point(337, 117);
            this.btNextSong.Name = "btNextSong";
            this.btNextSong.Size = new System.Drawing.Size(116, 23);
            this.btNextSong.TabIndex = 3;
            this.btNextSong.Text = "Next!";
            this.btNextSong.UseVisualStyleBackColor = true;
            this.btNextSong.Click += new System.EventHandler(this.btNextSong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Artists like: ";
            // 
            // txtArtistName
            // 
            this.txtArtistName.Location = new System.Drawing.Point(78, 119);
            this.txtArtistName.Name = "txtArtistName";
            this.txtArtistName.Size = new System.Drawing.Size(133, 20);
            this.txtArtistName.TabIndex = 5;
            this.txtArtistName.Text = "Guns&Roses";
            this.txtArtistName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btChangeArtist
            // 
            this.btChangeArtist.Location = new System.Drawing.Point(217, 117);
            this.btChangeArtist.Name = "btChangeArtist";
            this.btChangeArtist.Size = new System.Drawing.Size(116, 23);
            this.btChangeArtist.TabIndex = 6;
            this.btChangeArtist.Text = "Change!";
            this.btChangeArtist.UseVisualStyleBackColor = true;
            this.btChangeArtist.Click += new System.EventHandler(this.btChangeArtist_Click);
            // 
            // PlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 154);
            this.Controls.Add(this.btChangeArtist);
            this.Controls.Add(this.txtArtistName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btNextSong);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayerWindow";
            this.Text = "GoEar Player";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.Button btNextSong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArtistName;
        private System.Windows.Forms.Button btChangeArtist;
    }
}

