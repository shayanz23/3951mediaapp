using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class PlaylistMdiChild : Form
    {

        // Declare variables and collections
        private Dictionary<string, Song> titleToAudioLookup;
        private Song selectedAudio;
        private List<Song> Queue = new List<Song>();

        public Playlist SongPlaylist { get; set; }

        /// <summary>
        /// Constructor for the MusicLibraryForm class
        /// </summary>
        public PlaylistMdiChild(Playlist playlist)
        {
            InitializeComponent();
            SongPlaylist = playlist;
            nameLabel.Text = playlist.Name;
            titleToAudioLookup = SongPlaylist.Songs.ToDictionary(audio => audio.Title);
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
            if (SongPlaylist.Songs == null)
            {
                return;
            }
            bool hasNonNullAlbumArt = SongPlaylist.Songs.Any(song => SongManager.getCoverArt(song.FileLocation) != null);
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
            int imagesListCount = SongPlaylist.Songs.Count;

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Image = null;
                while (SongManager.getCoverArt(SongPlaylist.Songs[index % imagesListCount].FileLocation) == null)
                {
                    index++;
                }

                pictureBoxes[i].Image = SongManager.getCoverArt(SongPlaylist.Songs[index % imagesListCount].FileLocation);
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
            for (int i = 0; i < SongPlaylist.Songs.Count; i++)
            {
                if (SongPlaylist.Songs[i] == selectedAudio)
                {
                    add = true;
                }
                if (add)
                {
                    Queue.Add(SongPlaylist.Songs[i]);
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
            if (SongPlaylist.Songs == null)
            {
                return;
            }
            for (int i = 0; i < SongPlaylist.Songs.Count; i++)
            {

                string a = SongPlaylist.Songs[i].Title;
                string b = "";

                if (SongPlaylist.Songs[i].GetArtists().Length > 0) {
                        b += SongPlaylist.Songs[i].GetArtists();
                } else {
                    b = "Unknown";
                }

                string c = SongPlaylist.Songs[i].Duration;

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
            if (SongPlaylist.Songs != null && SongPlaylist.Songs.Count != 0)
            {
                List<Song> songCandidates = new List<Song>(SongPlaylist.Songs);
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
            if (SongPlaylist.Songs != null && SongPlaylist.Songs.Count != 0)
            {
                Queue = new List<Song>(SongPlaylist.Songs);
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

        /// <summary>
        /// Opens the AddSongsDialog, 
        /// Checks if the songsNext selected are already in the playlist, and ads them if not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addSongs_Click(object sender, EventArgs e)
        {
            using (AddSongsDialog newPlaylistDialog = new AddSongsDialog())
            {
                if (newPlaylistDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (Song song1 in newPlaylistDialog.Songs)
                    {
                        if (!SongPlaylist.Songs.Any(song => song.Title == song1.Title))
                        {
                            SongPlaylist.Songs.Add(song1);
                        }
                    }

                    titleToAudioLookup = SongPlaylist.Songs
                        .GroupBy(audio => audio.Title)
                        .ToDictionary(group => group.Key, group => group.First());
                    fillList();
                    fillPictures();
                }
            }
        }

        /// <summary>
        /// Removes songsNext selected if they are selected in the RemoveSongsDialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void remSongsBtn_Click(object sender, EventArgs e)
        {
            using (RemoveSongsDialog removePlaylistDialog = new RemoveSongsDialog(SongPlaylist.Songs))
            {
                if (removePlaylistDialog.ShowDialog() == DialogResult.OK)
                {
                    // Use RemoveAll with a predicate to remove songsNext from SongPlaylist.Songs that are present in removePlaylistDialog.SongsToRm
                    SongPlaylist.Songs.RemoveAll(song => removePlaylistDialog.SongsToRm.Contains(song));

                    titleToAudioLookup = null;
                    titleToAudioLookup = SongPlaylist.Songs
                        .GroupBy(audio => audio.Title)
                        .ToDictionary(group => group.Key, group => group.First());
                    fillList();
                    fillPictures();
                }
            }
        }

    }
}