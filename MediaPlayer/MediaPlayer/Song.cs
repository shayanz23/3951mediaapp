using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public class Song
    {

        /// <summary>
        /// Title property.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// File location property.
        /// </summary>
        public string FileLocation { get; set; }

        /// <summary>
        /// Album property.
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Artists array property.
        /// </summary>
        public string[] Artists { get; set; }

        /// <summary>
        /// Genres array property
        /// </summary>
        public string[] Genres { get; set; }

        /// <summary>
        /// Duration property.
        /// </summary>
        public string Duration { get; set; }

        public Song()
        {
            Title = null;
            FileLocation = null;
            Album = null;
            Artists = null;
            Genres = null;
            Duration = null;
            //albumArt = null;
        }

        /// <summary>
        /// Returns the Artists array in a properly formated string.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <returns>properly formated string of Artists</returns>
        public string GetArtists()
        {
            StringBuilder sb = new StringBuilder();
            if (Artists == null)
            {
                return "Unknown";
            }
            if (Artists.Length == 1)
            {
                sb.Append(Artists[0]);
            } else if (Artists != null || Artists.Length != 0)
            {
                for (int i = 0; i < Artists.Length-1; i++)
                {
                    if (i == Artists.Length - 1)
                    {
                        sb.Append(Artists[i]);
                    } else {
                        sb.Append(Artists[i] + ", ");
                    }
                }
            }
            return sb.ToString();
        }
    }
}
