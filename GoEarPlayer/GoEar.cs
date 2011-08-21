using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Policy;
using System.Net;

namespace GoEarPlayer
{
    class GoEar
    {

        private static GoEar INSTANCE = null;
        private string _apiKey;

        private GoEar() { _apiKey = System.IO.File.ReadAllLines("api_key.txt").First(); }

        public static GoEar GetInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new GoEar();
            return INSTANCE;
        }

        public Artist GetSimilarSong(string artist)
        {
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            string xml = wc.DownloadString("http://ws.audioscrobbler.com/2.0/?method=artist.getsimilar&artist=" + artist + "&api_key="+_apiKey);
            string[] chunks = (from chunk in xml.Split(new string[] { "<artist>", "</artist>" }, StringSplitOptions.RemoveEmptyEntries) where chunk != "\n" select chunk).ToArray();
            Artist similarArtist = ProcessArtist(chunks[new Random(DateTime.Now.Millisecond).Next(1, (chunks.Length - 2) / 2)]);
            GoEarSong song = DownloadGoEar(similarArtist.Name);            
            similarArtist.UrlMp3 = song.GetDownloadUrl();
            similarArtist.Title = song.Title;
            return similarArtist;
        }

        private Artist ProcessArtist(string line)
        {
            string name = line.Split(new string[] { "<name>", "</name>" }, StringSplitOptions.RemoveEmptyEntries)[1];
            string url = line.Split(new string[] { "<url>", "</url>" }, StringSplitOptions.RemoveEmptyEntries)[1];
            string image = line.Split(new string[] { "<image size=\"large\">", "</image>" }, StringSplitOptions.RemoveEmptyEntries)[3];
            return new Artist() { Image = image, Name = name, Url = url };
        }

        private GoEarSong DownloadGoEar(string name)
        {
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            string page = "";
            do
            {
                page = wc.DownloadString("http://www.goear.com/search.php?q=" + name + "&p=0");
            } while (page.Contains("Cargando..."));
            string chunk = page.Split(new string[] { "<iframe width=\"468\" height=\"60\" src=\"http://www.goear.com/search_ad.html\" marginheight=\"0\" marginwidth=\"0\" frameborder=\"0\" scrolling=\"no\"></iframe>" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { "<div style=\"font-family:Arial, Helvetica, sans-serif; font-size:15px; margin:20px;\">" }, StringSplitOptions.RemoveEmptyEntries)[0];
            string songChunk = chunk.Split(new string[] { "<div style=\"padding-left:1px;\">" }, StringSplitOptions.RemoveEmptyEntries)[1];
            return ProcessLine(songChunk);
        }

        private GoEarSong ProcessLine(string line)
        {
            GoEarSong song = new GoEarSong();
            string[] chunks = line.Split(new char[] { '"' });
            string[] data = chunks[1].Split(new string[] { " de " }, StringSplitOptions.RemoveEmptyEntries);
            /*song.SetTitle(data[0].Substring(9).Trim());
            StringBuilder artist = new StringBuilder();
            for (int i = 1; i < data.Length; i++)
                artist.Append(data[i]);
            song.Artist = artist.ToString().Trim(); */
            song.SetCode(chunks[3].Split(new char[] { '/' })[1].Trim());
            return song;
        }

    }
}
