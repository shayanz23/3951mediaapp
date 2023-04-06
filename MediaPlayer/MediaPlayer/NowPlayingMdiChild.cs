using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class NowPlayingMdiChild : Form
    {

        // Declare variables and collections
        private Dictionary<string, Song> titleToAudioLookup;
        MainForm parent;
        Song selectedAudio;
        List<Song> songsNext = new List<Song>();
        List<Song> Queue = new List<Song>();

        /// <summary>
        /// Constructor for the MusicLibraryForm class
        /// </summary>
        public NowPlayingMdiChild()
        {
            InitializeComponent();
            songData.Size = new Size(426, 325);
            //audioVisualization1 = new CSAudioVisualization.AudioVisualization();
            audioVisualization1.Size = new Size(325, 325);
            audioVisualization1.BarCount = 120;
            audioVisualization1.BackColor = Color.Transparent;
            audioVisualization1.ColorBase = Color.Blue;
            audioVisualization1.ColorMax = Color.MistyRose;
            audioVisualization1.VoidRadius = 50;
            audioVisualization1.BarIntensity = 1;
            audioVisualization1.BeatIntensity = 2;
            audioVisualization1.Start();
        }

        /// <summary>
        /// Fills the form with pictures
        /// By Shayan Zahedanaraki
        /// </summary>
        public void fillPictures()
        {

            bool hasNonNullAlbumArt = songsNext.Any(song => SongManager.getCoverArt(song.FileLocation) != null);
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
            int imagesListCount = songsNext.Count;

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Image = null;
                while (SongManager.getCoverArt(songsNext[index % imagesListCount].FileLocation) == null)
                {
                    index++;
                }

                pictureBoxes[i].Image = SongManager.getCoverArt(songsNext[index % imagesListCount].FileLocation);
                index++;
            }
        }

        /// <summary>
        /// Sets the number of the song playing to the one selected.
        /// By Shayan Zahedanaraki
        /// </summary>
        void pickNum()
        {
            for (int i = 0; i < parent.Queue.Count(); i++)
            {
                if (parent.Queue[i].Title == selectedAudio.Title)
                {
                    parent.NewSong(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Fills the ListView with the songsNext
        /// By James
        /// </summary>
        void fillList()
        {
            songData.Rows.Clear();
            for (int i = 0; i < songsNext.Count; i++)
            {
                string a = songsNext[i].Title;
                string b = "";

                if (songsNext[i].GetArtists().Length > 0) {
                        b += songsNext[i].GetArtists();
                } else {
                    b = "Unknown";
                }

                string c = songsNext[i].Duration;

                this.songData.Rows.Add(i+1, a, b, c);
                
            }
            songData.ClearSelection();
        }

        /// <summary>
        /// Retrieves the songsNext from MediaScanner
        /// By Shayan Zahedanaraki
        /// </summary>
        public void getSongs()
        {
            parent = (MainForm)this.MdiParent;
            songsNext = parent.nextSongs();
            fillList();
            fillPictures();
            titleToAudioLookup = songsNext.ToDictionary(audio => audio.Title);
        }

        /// <summary>
        /// Handles the event when the DataGridView selection is changed.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SongData_CellClick(object sender, DataGridViewCellEventArgs e) {

            if (e.RowIndex == -1)
            {
                return;
            }
            string selectedItem = songData[1, e.RowIndex].Value.ToString();
            selectedAudio = null;

            titleToAudioLookup.TryGetValue(selectedItem, out selectedAudio);

            if (selectedAudio != null) {
                MainForm parent = (MainForm)this.MdiParent;
                pickNum();
                getSongs();
            }

        }

        private void NowPlayingMdiChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (audioVisualization1 != null)
            {
                audioVisualization1.Stop();
                audioVisualization1.Dispose();
                audioVisualization1 = null;
            }
        }
    }
}