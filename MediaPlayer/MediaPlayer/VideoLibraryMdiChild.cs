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
    public partial class VideoLibraryForm : Form
    {
        public VideoLibraryForm()
        {
            InitializeComponent();
            fillList();
            listBox1.Width = (Width);
        }

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

        void fillList()
        {
            for (int i = 0; i < MediaScanner.Videos.Count; i++)
            {
                StringBuilder titleBuilder = new StringBuilder();
                StringBuilder artistBuilder = new StringBuilder();
                StringBuilder durationBuilder = new StringBuilder();
                if (MediaScanner.Videos[i] != null)
                {
                    titleBuilder.Append(MediaScanner.Videos[i].title);
                    titleBuilder.Append(MediaScanner.Videos[i].director);
                    if (MediaScanner.Videos[i].genres == null)
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
                    listBox1.Items.Add(titleBuilder.ToString() + artistBuilder.ToString() + durationBuilder.ToString());
                }
            }
        }
    }
}
