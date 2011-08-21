using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;

namespace GoEarPlayer
{
    class GoEarSong
    {
        //public GoEarSong Title { get { return this; } }

        public string Title { get; set; }
        public string Artist { get; set; }
        /*
        private string _artist;
        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = DecodeHTML(value);
            }
        }

        private string DecodeHTML(string line)
        {
            return line.Replace("&ntilde;", "ñ").Replace("&aacute;", "á").Replace("&eacute;", "é").Replace("&iacute;", "í").Replace("&oacute;", "ó").Replace("&uacute;", "ú").Replace("&iquest;", "¿").Replace("&amp;", "&").Replace("&ccedil;", "ç").Replace("&ordf;", "º");
        }

        private string _title;

        public string GetTitle()
        {
            return _title;
        }

        public void SetTitle(string title)
        {
            _title = DecodeHTML(title);
        }*/

        private string _code;

        public string GetCode()
        {
            return _code;
        }

        public void SetCode(string code)
        {
            _code = code;
        }

        public string GetDownloadUrl()
        {
            if (!String.IsNullOrEmpty(_downloadUrl))
                return _downloadUrl;
            return SetDownloadUrl();
        }

        private string SetDownloadUrl()
        {
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;

            var xmlAddress = "http://www.goear.com/tracker758.php?f=" + _code;
            var node = (from x in XDocument.Load(xmlAddress).Root.Descendants()
                        where x.Name == "song"
                        select new { URL = x.Attribute("path").Value, Title = x.Attribute("title").Value, Artist = x.Attribute("artist").Value })
                        .Single();
            Title = node.Title;
            Artist = node.Artist;
            return _downloadUrl = node.URL;
        }

        private string _downloadUrl;

        public void SetDownloadUrl(string url)
        {
            _downloadUrl = url;
        }

        public override string ToString()
        {
            return Artist + " - " + Title;
        }
    }
}
