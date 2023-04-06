using System;
using System.Collections;
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
    public partial class MdiChildForm : Form
    {
        public MdiChildForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Retrieves the songsNext from MediaScanner
        /// By Shayan Zahedanaraki
        /// </summary>
        public List<Song> getSongs()
        {
            List<Song> songs = new List<Song>();
            for (int i = 0; i < SongManager.Songs.Count; i++)
            {
                songs.Add(SongManager.Songs[i]);
            }
            return songs;
        }

        /// <summary>
        /// Fills the form with pictures
        /// By Shayan Zahedanaraki
        /// </summary>
        public void fillPictures(List<Song> inputSongs)
        {
            if (inputSongs == null)
            {
                return;
            }
            bool hasNonNullAlbumArt = inputSongs.Any(song => SongManager.getCoverArt(song.FileLocation) != null);
            if (!hasNonNullAlbumArt)
            {
                return;
            }
            List<PictureBox> pictureBoxes = new List<PictureBox>
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4
            };
            int index = 0;
            int imagesListCount = inputSongs.Count;

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Image = null;
                while (SongManager.getCoverArt(inputSongs[index % imagesListCount].FileLocation) == null)
                {
                    index++;
                }

                pictureBoxes[i].Image = SongManager.getCoverArt(inputSongs[index % imagesListCount].FileLocation);
                index++;
            }
        }

    }
}
