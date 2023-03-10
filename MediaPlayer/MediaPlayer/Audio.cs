using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public class Audio : Media
    {

        /// <summary>
        /// Title property.
        /// </summary>
        public override string title { get; set; }

        /// <summary>
        /// File location property.
        /// </summary>
        public override string fileLocation { get; set; }

        public string album { get; set; }

        public string[] artists { get; set; }

        public string[] genres { get; set; }

        public string duration { get; set; }

        public Image coverArt { get; set; }

        public string getArtists()
        {
            StringBuilder sb = new StringBuilder();
            if (artists.Length == 1)
            {
                sb.Append(artists[0]);
            } else if (artists != null || artists.Length != 0)
            {
                for (int i = 0; i < artists.Length-1; i++)
                {
                    if (i == artists.Length - 1)
                    {
                        sb.Append(artists[i]);
                    } else {
                        sb.Append(artists[i] + ", ");
                    }
                }
            }
            return sb.ToString();
        }
    }
}
