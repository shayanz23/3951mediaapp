using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MediaPlayer
{
    /// <summary>
    /// By Shayan Zahedanaraki, Daniel 
    /// Used code [1]: https://stackoverflow.com/questions/38926777/how-to-play-a-list-of-songsNext-using-naudio-and-c
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Child form that is not yet instantiated
        /// </summary>
        private Form childForm;
        private int startPosY = 0;
        private int song_index; // index of the song
        private MediaFoundationReader audioFileReader;
        private WaveOutEvent waveOut;
        private bool forceStopped;
        private bool isPaused;
        private Timer progressBarTimer;
        private ContextMenuStrip contextMenu;
        private TreeNode currentRightClickedNode;
        private bool firstTimePlaying;

        //Queue getter and setter.
        public List<Song> Queue { get; set; }

        public MainForm()
        {
            InitializeComponent();
            setButtonImages();
            songLabelStart();
            VolumeInit();
            ProgressBarInit();
            InitializeContextMenu();
            Queue = new List<Song>();
            PlaylistManager.Read();
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;
            this.FormClosing += OnFormClosing;
            //sets the size of form1.
            Size = new Size(1000, 630);
            contentTree.Size = new Size(200, 500);
            albumArtBox.Size = new Size(70, 70);

            song_index = 0;
            isPaused = false;
            playPauseButton1.playing = false;
            waveOut = null;
            timePlayedLabel.BackColor = Color.White;
            timeRemainingLabel.BackColor = Color.White;

            ExpandNodes();
            OpenLibrary();
            loadPlaylists();
        }

        private void InitializeContextMenu()
        {
            contextMenu = new ContextMenuStrip();

            ToolStripMenuItem deletePlaylistItem = new ToolStripMenuItem("Delete playlist");
            deletePlaylistItem.Click += DeletePlaylistItem_Click;
            contextMenu.Items.Add(deletePlaylistItem);
            contentTree.MouseUp += ContentTree_MouseUp;
        }

        /// <summary>
        /// Mouse up event listener for the content tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentTree_MouseUp(object sender, MouseEventArgs e)
        {
            TreeNode node = contentTree.GetNodeAt(e.X, e.Y);
            if (node == null)
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                OpenContextMenu(node, e);
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (node.Name == "NewSongPlaylist")
                {
                    OpenNewPlaylistDialog();
                }
                else if (node.Name == "SongLibrary")
                {
                    OpenLibrary();
                }
                else if (node.Name == "NowPlayingNode")
                {
                    NowPlayingOpen();
                }
                OpenNodePlaylist(node);
            }
        }

        /// <summary>
        /// Opens the context menu for a Treenode selected.
        /// </summary>
        /// <param name="node"></param>
        public void OpenContextMenu(TreeNode node, MouseEventArgs e)
        {
            currentRightClickedNode = node;
            if (node != null && node.Text != "Queue" && node.Text.Trim() != ""
                && node.Text != "Library" && node.Text != "New Playlist...")
            {
                contentTree.SelectedNode = node;
                contextMenu.Show(contentTree, e.Location);
            }
        }

        /// <summary>
        /// Opens the new playlist dialog.
        /// Shayan Zahedanraki
        /// </summary>
        public void OpenNewPlaylistDialog()
        {
            using (NewPlaylistDialog newPlaylistDialog = new NewPlaylistDialog())
            {
                if (newPlaylistDialog.ShowDialog() == DialogResult.OK)
                {
                    Playlist playlist = new Playlist(newPlaylistDialog.newPlaylistName);
                    PlaylistManager.AddPlaylist(playlist);
                    AddPlaylistToTree(playlist);
                }
            }
        }

        /// <summary>
        /// Open playlist for the currently selected node.
        /// Shayan Zahedanaraki
        /// </summary>
        /// <param name="node"></param>
        public void OpenNodePlaylist(TreeNode node)
        {
            for (int i = 0; i < PlaylistManager.Playlists.Count; i++)
            {
                if (node.Text == PlaylistManager.Playlists[i].Name)
                {
                    PlaylistOpen(PlaylistManager.Playlists[i]);
                }
            }
        }

        /// <summary>
        /// Opens the Now Playing mdi.
        /// </summary>
        public void NowPlayingOpen()
        {
            //if childform already exists, get rid of it, and create new MusicLibraryForm instead.
            if (childForm != null)
            {
                childForm.Close();
                childForm.Dispose();
                childForm = null;
            }
            childForm = new NowPlayingMdiChild();
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point(contentTree.Size.Width, startPosY);
            childForm.Size = new Size((int)(this.Size.Width / 1.285), contentTree.Size.Height);
            ((NowPlayingMdiChild)childForm).getSongs();
            childForm.Show();
        }

        /// <summary>
        /// Gets the songsNext after the one currently playing.
        /// </summary>
        /// <returns></returns>
        public List<Song> nextSongs()
        {
            List<Song> nextSongs = new List<Song>();
            if (Queue == null)
            {
                return nextSongs;
            }
            for (int i = song_index + 1; i < Queue.Count(); i++)
            {
                nextSongs.Add(Queue[i]);
            }
            return nextSongs;
        }

        /// <summary>
        /// event listener for the clicking on the delete button in the context menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletePlaylistItem_Click(object sender, EventArgs e)
        {
            PlaylistManager.RemovePlaylist(currentRightClickedNode.Text);
            if (childForm is PlaylistMdiChild)
            {
                if (((PlaylistMdiChild)childForm).SongPlaylist.Name == currentRightClickedNode.Text)
                {
                    OpenLibrary();
                }
            }
            contentTree.Nodes.Remove(currentRightClickedNode);
        }


        /// <summary>
        /// saves playlists to json file on closing. 
        /// </summary>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            PlaylistManager.Save();
            childForm.Close();
            childForm.Dispose();
            childForm = null;
        }

        /// <summary>
        /// sets progressbar properties.
        /// </summary>
        private void ProgressBarInit()
        {
            progressBarTimer = new Timer();
            progressBarTimer.Interval = 100; // Update the progress bar every 100ms
            progressBarTimer.Tick += ProgressBarTimer_Tick;
            songProgressBar.MouseDown += SongProgressBar_MouseDown;
        }

        /// <summary>
        /// sets volume properties.
        /// </summary>
        private void VolumeInit()
        {
            volumeTrackbar.Value = 50;
            volumeTrackbar.Scroll += VolumeTrackbar_Scroll;
        }

        /// <summary>
        /// sets song label properties.
        /// </summary>
        private void songLabelStart()
        {
            songLabel.AutoSize = false;
            songLabel.Width = 160;
            songLabel.Height = 20;
        }

        /// <summary>
        /// expands the nodes in content tree.
        /// </summary>
        private void ExpandNodes()
        {
            // Expands the three main nodes of the treeview that shows the contents.
            for (int i = 0; i < contentTree.Nodes.Count; i++)
            {
                if (contentTree.Nodes[i].Name == "SongLibrary")
                {
                    contentTree.Nodes[i].Expand();
                }
            }
        }

        /// <summary>
        /// Event listener for the scroll even of the VolumeTrackbar, 
        /// sets the volume and displays it on a label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeTrackbar_Scroll(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                float volume = volumeTrackbar.Value / 100f;
                waveOut.Volume = volume;
                volumeLabel.Text = volumeTrackbar.Value + "%";
            }
        }

        /// <summary>
        /// Gets the current time played from the audioFileReader.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <returns></returns>
        private TimeSpan GetTimePlayed()
        {
            if (audioFileReader != null)
            {
                return audioFileReader.CurrentTime;
            }
            return TimeSpan.Zero;
        }

        /// <summary>
        /// Gets the Time Remaining from the audioFileReader.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <returns></returns>
        private TimeSpan GetTimeRemaining()
        {
            if (audioFileReader != null)
            {
                return audioFileReader.TotalTime - audioFileReader.CurrentTime;
            }
            return TimeSpan.Zero;
        }

        /// <summary>
        /// Gets the mouse position on the progress bar and sets audioFileReader 
        /// and the songProgressBar position to the mouse's X position.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SongProgressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (audioFileReader != null && waveOut != null)
            {
                double ratio = (double)e.X / (double)songProgressBar.Width;
                int newPosition = (int)(ratio * audioFileReader.TotalTime.TotalMilliseconds);
                audioFileReader.Position = (long)(newPosition / audioFileReader.TotalTime.TotalMilliseconds * audioFileReader.Length);

                // Update the progress bar value after setting the position
                songProgressBar.Value = newPosition;
            }
        }

        /// <summary>
        /// Sets the button Images for the forward, play/pause and rewind buttons.
        /// By Shayan Zahedanaraki
        /// </summary>
        private void setButtonImages()
        {
            string playingImageLocation = Environment.CurrentDirectory + "/pause.png";
            string pausedImageLocation = Environment.CurrentDirectory + "/play.png";
            string forwardImageLocation = Environment.CurrentDirectory + "/forward.png";
            string rewindImageLocation = Environment.CurrentDirectory + "/rewind.png";
            forwardButton.BackgroundImage = Image.FromFile(forwardImageLocation);
            rewindButton.BackgroundImage = Image.FromFile(rewindImageLocation);
            playPauseButton1.PlayingBackgroundImage = Image.FromFile(playingImageLocation);
            playPauseButton1.PausedBackgroundImage = Image.FromFile(pausedImageLocation);
        }

        /// <summary>
        /// This is an event handeler for the ProgressBarTimer tick change that
        /// sets the progressBar's value to the current time.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBarTimer_Tick(object sender, EventArgs e)
        {
            if (audioFileReader != null && waveOut != null)
            {
                try
                {
                    songProgressBar.Value = (int)audioFileReader.CurrentTime.TotalMilliseconds;
                    timePlayedLabel.Text = GetTimePlayed().ToString(@"mm\:ss");
                    timeRemainingLabel.Text = GetTimeRemaining().ToString(@"mm\:ss");
                }
                catch { }
            }
        }



        /// <summary>
        /// Plays the songsNext newly selected, unless the PlaybackState.Paused,
        /// then it just starts playing the currently playing song again.
        /// Also only creates a new instance of WaveOut if the waveOut is null
        /// or not paused.
        /// By Shayan Zahedanaraki from stackoverflow [1]
        /// </summary>
        private void player_play()
        {
            if (song_index < Queue.Count)
            {
                if (waveOut == null || waveOut.PlaybackState != PlaybackState.Paused)
                {
                    waveOut = new WaveOutEvent();

                    // Sets the volume to 50%
                    if (firstTimePlaying)
                    {
                        waveOut.Volume = 0.5F;
                        firstTimePlaying = false;
                    }
                    waveOut.PlaybackStopped += playbackstopped;
                }
                if (waveOut.PlaybackState != PlaybackState.Paused)
                {
                    try
                    {
                        audioFileReader = new MediaFoundationReader(Queue[song_index].FileLocation);
                    }
                    catch
                    {
                        playPauseButton1.playing = false;
                        MessageBox.Show("File not found or removed during usage", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    songProgressBar.Minimum = 0;
                    songProgressBar.Maximum = (int)audioFileReader.TotalTime.TotalMilliseconds;
                    songProgressBar.Value = 0;
                    waveOut.Init(audioFileReader);

                    progressBarTimer.Start(); // Start the progress bar timer
                }
                UpdateAlbumArt(SongManager.getCoverArt(Queue[song_index].FileLocation));
                UpdateSongName(Queue[song_index].Title);
                UpdateArtistName(Queue[song_index].GetArtists());
                waveOut.Play();
            }
            else
            {
                progressBarTimer.Stop(); // Stop the progress bar timer
            }
        }


        /// <summary>
        /// event catcher for if the playback has stopped.
        /// has an if statements that checks if forceStopped has been set to true
        /// by the FillQueue when replacing the playing song with another songsNext,
        /// does nothing to the currently playing song if thats the case,
        /// and sets it false for next time.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playbackstopped(object sender, StoppedEventArgs e)
        {
            if (forceStopped)
            {
                forceStopped = false;
                return;
            }

            song_index++; // play the next file
            player_play();
        }



        /// <summary>
        /// updates the Album art picture box to match currently playing song.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="coverArt"></param>
        private void UpdateAlbumArt(Image coverArt)
        {
            if (coverArt != null)
            {
                albumArtBox.Image = coverArt;
                albumArtBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                albumArtBox.Image = null;
            }
        }

        /// <summary>
        /// updates the Album art picture box to match currently playing song.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="coverArt"></param>
        private void UpdateSongName(string name)
        {
            if (name != null)
            {
                songLabel.Text = name;
            }
        }

        /// <summary>
        /// updates the Album art picture box to match currently playing song.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="coverArt"></param>
        private void UpdateArtistName(string name)
        {
            if (name != null)
            {
                artistLabel.Text = name;
            }
        }

        /// <summary>
        /// Fills the Queue of songsNext to play and runs the player_play funtion.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="input"></param>
        public void FillQueue(List<Song> input)
        {
            if (waveOut != null)
            {
                forceStopped = true; // Add this line
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            Queue = input;
            song_index = 0;
            isPaused = false;
            playPauseButton1.playing = true;
            player_play();
        }

        /// <summary>
        /// Picks a new song based on the index of a song in the Queue.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="input"></param>
        public void NewSong(int input)
        {
            waveOut.Stop();
            song_index = input;
            forceStopped = true;
            isPaused = false;
            playPauseButton1.playing = true;
            player_play();
        }

        /// <summary>
        /// Triggered when the user clicks on the Song Library in the contentTree.
        /// </summary>
        private void OpenLibrary()
        {
            //if childform already exists, get rid of it, and create new MusicLibraryForm instead.
            if (childForm != null)
            {
                childForm.Close();
                childForm.Dispose();
                childForm = null;
            }
            childForm = new LibraryMdiChild();
            childForm.MdiParent = this;
            childForm.StartPosition = FormStartPosition.Manual;
            childForm.Location = new Point(contentTree.Size.Width, startPosY);
            childForm.Size = new Size((int)(this.Size.Width / 1.285), contentTree.Size.Height);
            childForm.Show();
        }


        /// <summary>
        /// Triggered when the user clicks on the Song Library in the contentTree.
        /// </summary>
        private void PlaylistOpen(Playlist playlist)
        {
            // If childForm already exists, get rid of it, and create a new PlaylistMdiChild instead.
            if (childForm != null)
            {
                childForm.Close();
                childForm.Dispose();
                childForm = null;
            }

            childForm = new PlaylistMdiChild(playlist)
            {
                MdiParent = this,
                StartPosition = FormStartPosition.Manual,
                Location = new Point(contentTree.Size.Width, startPosY),
                Size = new Size((int)(this.Size.Width / 1.285), contentTree.Size.Height)
            };

            childForm.Show();
        }

        /// <summary>
        /// Loads the playlists already created into the content tree.
        /// </summary>
        private void loadPlaylists()
        {
            for (int i = 0; i < PlaylistManager.Playlists.Count; i++)
            {
                bool exists = false;
                for (int j = 0; j < contentTree.Nodes.Count; j++)
                {
                    if (PlaylistManager.Playlists[i].Name == contentTree.Nodes[j].Name)
                    {
                        exists = true;
                    }
                }
                if (exists == false)
                {
                    for (int k = 0; k < contentTree.Nodes.Count; k++)
                    {
                        if (contentTree.Nodes[k].Name == "SongLibrary")
                        {
                            TreeNode treeNode = new TreeNode(PlaylistManager.Playlists[i].Name);
                            contentTree.Nodes[k].Nodes.Add(treeNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds newly createed playlist to the tree.
        /// </summary>
        /// <param name="playlist"></param>
        private void AddPlaylistToTree(Playlist playlist)
        {
            TreeNode songLibraryNode = null;

            // Find the "SongLibrary" node
            for (int i = 0; i < contentTree.Nodes.Count; i++)
            {
                if (contentTree.Nodes[i].Name == "SongLibrary")
                {
                    songLibraryNode = contentTree.Nodes[i];
                    break;
                }
            }

            // If the "SongLibrary" node is not found, you may need to handle it here.
            bool exists = false;

            // Check if the playlist already exists in the tree
            for (int j = 0; j < songLibraryNode.Nodes.Count; j++)
            {
                if (playlist.Name == songLibraryNode.Nodes[j].Text || playlist.Name.Trim() == "")
                {
                    exists = true;
                    break;
                }
            }

            // If the playlist doesn't exist in the tree, add it
            if (!exists)
            {
                TreeNode treeNode = new TreeNode(playlist.Name);
                songLibraryNode.Nodes.Add(treeNode);
            }
        }


        /// <summary>
        /// Skips to the next song and updates attributes to keep the GUI up to date.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (waveOut != null && song_index != Queue.Count - 1)
            {
                waveOut.Stop();
                song_index++; // play the next file
                forceStopped = true;
                isPaused = false;
                playPauseButton1.playing = true;
                player_play();
                if (childForm is NowPlayingMdiChild)
                {
                    ((NowPlayingMdiChild)childForm).getSongs();
                }
            }
        }

        /// <summary>
        /// Event listener, Goes to the last audio in the Queue.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rewindButton_Click(object sender, EventArgs e)
        {
            if (song_index > 0)
            {
                waveOut.Stop();
                song_index--;
                forceStopped = true;
                isPaused = false;
                playPauseButton1.playing = true;
                player_play();
                if (childForm is NowPlayingMdiChild)
                {
                    ((NowPlayingMdiChild)childForm).getSongs();
                }
            }
        }

        /// <summary>
        /// Event listener for the pause and play button.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playPauseButton1_Click(object sender, EventArgs e)
        {
            if (isPaused && waveOut != null && waveOut.PlaybackState != PlaybackState.Stopped)
            {
                player_play();
                playPauseButton1.playing = true;
                isPaused = !isPaused;
            }
            else if (!isPaused && waveOut != null && waveOut.PlaybackState != PlaybackState.Stopped)
            {
                waveOut.Pause();
                playPauseButton1.playing = false;
                isPaused = !isPaused;
            }
        }

    }
}
