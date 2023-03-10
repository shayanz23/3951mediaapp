using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class MusicLibraryForm : Form
    {
        public MusicLibraryForm()
        {
            InitializeComponent();
            fillList();
            SongList.Width = Width;
        }

        /// <summary>
        /// Adds spaces or removes charecters from the end to make string a length 50. 
        /// (does not take into account that different characters are different lengths).
        /// </summary>
        /// <param name="stringBuilder"></param>
        void format(ref StringBuilder stringBuilder)
        {
            if (stringBuilder.Length >= 50)
            {
                int lengthTaken = stringBuilder.Length - 50;
                for (int j = lengthTaken; j > 0; j--)
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, stringBuilder.Length - 1);
                }
            }
            if (stringBuilder.Length < 50)
            {
                int lengthAdded = 50 - stringBuilder.Length;
                for (int j = 0; j < lengthAdded - 1; j++)
                {
                    stringBuilder.Append(' ');
                }
            }

        }

        /// <summary>
        /// Fills the song list with the list of songs found by the MediaScanner.
        /// </summary>
        void fillList()
        {
            for (int i = 0; i < MediaScanner.Audios.Count; i++)
            {
                StringBuilder titleBuilder = new StringBuilder();
                StringBuilder artistBuilder = new StringBuilder();
                StringBuilder durationBuilder = new StringBuilder();
                if (MediaScanner.Audios[i] != null)
                {
                    titleBuilder.Append(MediaScanner.Audios[i].title);
                    if (MediaScanner.Audios[i].artists == null)
                    {
                        artistBuilder.Append("Unknown");
                    }
                    else
                    {
                        artistBuilder.Append(MediaScanner.Audios[i].getArtists());
                    }
                    if (MediaScanner.Audios[i].duration == null)
                    {
                        durationBuilder.Append("Unknown");
                    }
                    else
                    {
                        durationBuilder.Append(MediaScanner.Audios[i].duration.ToString());
                    }

                    format(ref titleBuilder);
                    format(ref artistBuilder);
                    SongList.Items.Add(titleBuilder.ToString() + artistBuilder.ToString() + durationBuilder.ToString());
                }
            }
        }
    }
}
