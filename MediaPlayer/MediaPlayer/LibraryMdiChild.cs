using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TagLib.Riff;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MediaPlayer
{
    public partial class LibraryMdiChild : Form
    {

        // Declare variables and collections
        private Dictionary<string, Song> titleToAudioLookup;
        Song selectedAudio;
        List<Song> songs = new List<Song>();
        List<Song> Queue = new List<Song>();

        /// <summary>
        /// Constructor for the MusicLibraryForm class
        /// </summary>
        public LibraryMdiChild()
        {
            InitializeComponent();
            getSongs();
            titleToAudioLookup = songs.ToDictionary(audio => audio.Title);
            fillList();
            fillPictures();
            songData.Size = new Size(760, 325);

        }

        /// <summary>
        /// Fills the form with pictures
        /// By Shayan Zahedanaraki
        /// </summary>
        public void fillPictures()
        {

            bool hasNonNullAlbumArt = songs.Any(song => SongManager.getCoverArt(song.FileLocation) != null);
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
            int imagesListCount = songs.Count;

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Image = null;
                while (SongManager.getCoverArt(songs[index % imagesListCount].FileLocation) == null)
                {
                    index++;
                }

                pictureBoxes[i].Image = SongManager.getCoverArt(songs[index % imagesListCount].FileLocation);
                index++;
            }
        }

        /// <summary>
        /// Fills the queue with the songsNext
        /// By Shayan Zahedanaraki
        /// </summary>
        void fillQueue()
        {
            Queue.Clear();
            bool add = false;
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i] == selectedAudio)
                {
                    add = true;
                }
                if (add)
                {
                    Queue.Add(songs[i]);
                }
            }
        }

        /// <summary>
        /// Fills the ListView with the songsNext
        /// By James
        /// </summary>
        void fillList()
        {
            for (int i = 0; i < songs.Count; i++)
            {
                string a = songs[i].Title;
                string b = "";

                if (songs[i].GetArtists().Length > 0) {
                        b += songs[i].GetArtists();
                } else {
                    b = "Unknown";
                }

                string c = songs[i].Duration;

                this.songData.Rows.Add(i+1, a, b, c);
                
            }
            songData.ClearSelection();
        }

        /// <summary>
        /// Retrieves the songsNext from MediaScanner
        /// By Shayan Zahedanaraki
        /// </summary>
        private void getSongs()
        {
            for (int i = 0; i < SongManager.Songs.Count; i++)
            {
                songs.Add(SongManager.Songs[i]);
            }
        }

        /// <summary>
        /// Handles the click event for the shuffle button
        /// By Shayan Zahedanaraki
        /// </summary>
        private void shuffleButton_Click(object sender, EventArgs e)
        {
            if (songs != null && songs.Count != 0)
            {
                List<Song> songCandidates = new List<Song>(songs);
                JaroWinklerDistance.WeightedShuffle(songCandidates);
                Queue = new List<Song>(songCandidates);
                MainForm parent = (MainForm)MdiParent;
                parent.FillQueue(Queue);
            }

        }

        /// <summary>
        /// Handles the click event for the play button
        /// By Shayan Zahedanaraki
        /// </summary>
        private void playButton_Click(object sender, EventArgs e)
        {
            if (songs != null && songs.Count != 0)
            {
                Queue = new List<Song>(songs);
                MainForm parent = (MainForm)this.MdiParent;
                parent.FillQueue(Queue);
            }
        }

        private void SongData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            songData.ClearSelection();
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
                fillQueue();
                parent.FillQueue(Queue);
            }

        }
    }
}