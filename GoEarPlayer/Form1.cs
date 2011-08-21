using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace GoEarPlayer
{
    public partial class Form1 : Form
    {

        private Artist _currentArtist;

        public Form1()
        {
            InitializeComponent();
            ChangeSong("Amaral");
        }

        private void ChangeSong()
        {
            new Thread(new ThreadStart(ChangeSong_Thread)).Start();
        }

        private void ChangeSong_Thread()
        {
            _currentArtist = GoEar.GetInstance().GetSimilarSong(_currentArtist.Name);
            mediaPlayer.URL = _currentArtist.UrlMp3;
            pictureBox1.Image = new Bitmap(new MemoryStream(new WebClient().DownloadData(_currentArtist.Image)));
            this.Invoke((MethodInvoker)delegate() { SetText(); });

        }

        private void SetText()
        {
                this.Text = _currentArtist.Name + " - " + _currentArtist.Title;
        }

        private void ChangeSong(string artist)
        {
            _currentArtist = new Artist() { Name = artist };
            ChangeSong();
        }

        private void mediaPlayer_StatusChange_1(object sender, EventArgs e)
        {
            if (mediaPlayer.status == "Finished")
                ChangeSong();                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeSong();
        }
    }
}
