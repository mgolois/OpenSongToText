using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace OpenSongToText
{
    [XmlRoot("song")]
    public class Song
    {
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("author")]
        public string Author { get; set; }
        [XmlElement("lyrics")]
        public string Lyrics { get; set; }

        public string GetCoreLyrics()
        {
            List<string> finalLyrics = new List<string>();
            StringBuilder final = new StringBuilder();
            using (var tr = new StringReader(Lyrics))
            {
                while (tr.ReadLine() is string line)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        final.AppendLine();
                    }
                    else
                    {
                        if (line[0] == ' ')
                        {
                            final.AppendLine(line);
                        }
                    }
                }
            }
            return final.ToString();
        }
    }
}
