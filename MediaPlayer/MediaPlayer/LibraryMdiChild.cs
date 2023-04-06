using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class LibraryMdiChild : Form
    {

        // Declare variables and collections
        private Dictionary<string, Song> titleToAudioLookup;
        private Song selectedAudio;
        private List<Song> Queue = new List<Song>();

        /// <summary>
        /// Constructor for the MusicLibraryForm class
        /// </summary>
        public LibraryMdiChild()
        {
            InitializeComponent();
            titleToAudioLookup = SongManager.Songs.ToDictionary(audio => audio.Title);
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

            bool hasNonNullAlbumArt = SongManager.Songs.Any(song => SongManager.getCoverArt(song.FileLocation) != null);
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
            int imagesListCount = SongManager.Songs.Count;

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Image = null;
                while (SongManager.getCoverArt(SongManager.Songs[index % imagesListCount].FileLocation) == null)
                {
                    index++;
                }

                pictureBoxes[i].Image = SongManager.getCoverArt(SongManager.Songs[index % imagesListCount].FileLocation);
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
            for (int i = 0; i < SongManager.Songs.Count; i++)
            {
                if (SongManager.Songs[i] == selectedAudio)
                {
                    add = true;
                }
                if (add)
                {
                    Queue.Add(SongManager.Songs[i]);
                }
            }
        }

        /// <summary>
        /// Fills the ListView with the songsNext
        /// By James
        /// </summary>
        void fillList()
        {
            for (int i = 0; i < SongManager.Songs.Count; i++)
            {
                string a = SongManager.Songs[i].Title;
                string b = "";

                if (SongManager.Songs[i].GetArtists().Length > 0) {
                        b += SongManager.Songs[i].GetArtists();
                } else {
                    b = "Unknown";
                }

                string c = SongManager.Songs[i].Duration;

                this.songData.Rows.Add(i+1, a, b, c);
                
            }
            songData.ClearSelection();
        }

        /// <summary>
        /// Handles the click event for the shuffle button
        /// By Shayan Zahedanaraki
        /// </summary>
        private void shuffleButton_Click(object sender, EventArgs e)
        {
            if (SongManager.Songs != null && SongManager.Songs.Count != 0)
            {
                List<Song> songCandidates = new List<Song>(SongManager.Songs);
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
            if (SongManager.Songs != null && SongManager.Songs.Count != 0)
            {
                Queue = new List<Song>(SongManager.Songs);
                MainForm parent = (MainForm)this.MdiParent;
                parent.FillQueue(Queue);
            }
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