using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace MediaPlayer
{
    /// <summary>
    /// Used code: https://stackoverflow.com/questions/38926777/how-to-play-a-list-of-songs-using-naudio-and-c
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Child form that is not yet instantiated
        /// </summary>
        Form childForm;
        int startPosY = 0;
        int song_index; // index of the song
        AudioFileReader audioFileReader;
        WaveOutEvent waveOut;
        private bool forceStopped;
        List<Audio> Queue = new List<Audio>();
        private bool isPaused;

        public MainForm()
        {
            InitializeComponent();
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;
            //sets the size of form1.
            this.Size = new Size(1000, 620);
            albumArtBox.Size = new Size(65, 65);
            song_index = 0;
            isPaused = false;
            waveOut = null;
            // Expands the three main nodes of the treeview that shows the contents.
            for (int i = 0; i < contentTree.Nodes.Count; i++)
            {
                if (contentTree.Nodes[i].Name == "SongsNode" || contentTree.Nodes[i].Name == "VideosNode" || contentTree.Nodes[i].Name == "PicturesNode")
                {
                    contentTree.Nodes[i].Expand();
                }
            }
        }




        /// <summary>
        /// Plays the songs newly selected, unless the PlaybackState.Paused,
        /// then it just starts playing the currently playing song again.
        /// Also only creates a new instance of WaveOut if the waveOut is null
        /// or not paused.
        /// </summary>
        private void player_play()
        {
            if (song_index < Queue.Count)
            {
                if (waveOut == null || waveOut.PlaybackState != PlaybackState.Paused)
                {
                    waveOut = new WaveOutEvent();
                    waveOut.PlaybackStopped += playbackstopped;
                }
                if (waveOut.PlaybackState != PlaybackState.Paused)
                {
                    audioFileReader = new AudioFileReader(Queue[song_index].fileLocation);

                    songProgressBar.Minimum = 0;
                    songProgressBar.Maximum = (int)audioFileReader.TotalTime.TotalMilliseconds;
                    songProgressBar.Value = 0;
                    UpdateProgressBar(audioFileReader);
                    waveOut.Init(audioFileReader);
                }
                UpdateAlbumArt(Queue[song_index].albumArt);
                UpdateSongName(Queue[song_index].title);
                UpdateArtistName(Queue[song_index].getArtists());
                waveOut.Play();
            }
        }

        /// <summary>
        /// event catcher for if the playback has stopped.
        /// has an if statements that checks if forceStopped has been set to true
        /// by the FillQueue when replacing the playing song with another songs,
        /// does nothing to the currently playing song if thats the case,
        /// and sets it false for next time.
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
        /// updates the album art picture box to match currently playing song.
        /// </summary>
        /// <param name="coverArt"></param>
        private void UpdateAlbumArt(Image coverArt)
        {
            if (coverArt != null)
            {
                albumArtBox.Image = coverArt;
                albumArtBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        /// <summary>
        /// updates the album art picture box to match currently playing song.
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
        /// updates the album art picture box to match currently playing song.
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
        /// Updates the progress bar, currently not working.
        /// </summary>
        /// <param name="reader"></param>
        private void UpdateProgressBar(AudioFileReader reader)
        {
            try
            {
                Invoke(new Action(() => {
                    songProgressBar.Value = (int)reader.CurrentTime.TotalMilliseconds;
                }));
            } catch { }
            
        }



        /// <summary>
        /// Fills the queue of songs to play and runs the player_play funtion.
        /// </summary>
        /// <param name="input"></param>
        public void FillQueue(List<Audio> input)
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
            player_play();
        }


        /// <summary>
        /// Triggered when the user clicks on the Song Library in the contentTree.
        /// </summary>
        private void SongLibraryClick()
        {

            //if childform already exists, get rid of it, and create new MusicLibraryForm instead.
            if (childForm != null)
            {
                childForm.Dispose();
                childForm = new MusicLibraryForm();
                childForm.MdiParent = this;
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.Location = new Point(contentTree.Size.Width, startPosY);
                childForm.Size = new Size((int)(this.Size.Width / 1.295), contentTree.Size.Height);
                childForm.Show();
            }
            // Create a MusicLibraryForm
            else
            {
                childForm = new MusicLibraryForm();
                childForm.MdiParent = this;
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.Location = new Point(contentTree.Size.Width, startPosY);
                childForm.Size = new Size((int)(this.Size.Width / 1.295), contentTree.Size.Height);
                childForm.Show();
            }
        }


        /// <summary>
        /// Items in contentTree click handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contentTreeNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ArrayList songPlaylistNames = new ArrayList();
            if (e.Node.Name == "NewSongPlaylist")
            {
                using (NewPlaylistDialog newPlaylistDialog = new NewPlaylistDialog())
                {
                    if (newPlaylistDialog.ShowDialog() == DialogResult.OK)
                    {
                        TreeNode playlist = new TreeNode(newPlaylistDialog.newPlaylistName);
                        e.Node.Parent.Nodes.Add(playlist);
                    }
                    songPlaylistNames.Add(newPlaylistDialog.newPlaylistName);
                }
            }
            else if (e.Node.Name == "SongLibrary")
            {
                SongLibraryClick();
            }
        }

        /// <summary>
        /// Event listener for the pause and play button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playPauseButton_Click(object sender, EventArgs e)
        {
            if (isPaused && waveOut != null && waveOut.PlaybackState != PlaybackState.Stopped)
            {
                player_play();
                isPaused = !isPaused;
            } 
            else if (!isPaused && waveOut != null && waveOut.PlaybackState != PlaybackState.Stopped)
            {
                waveOut.Pause();
                isPaused = !isPaused;
            }
        }

        /// <summary>
        /// Event listener for the pause and play button.
        /// Sets the forced stop to true, so that the playbackstopped
        /// event listener's main function isn't 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                song_index++; // play the next file
                forceStopped = true;
                isPaused = false;
                player_play();
            }
        }

        /// <summary>
        /// Event listener, Goes to the last audio in the queue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousButton_Click(object sender, EventArgs e)
        {
            
            if (song_index > 0)
            {
                waveOut.Stop();
                song_index--;
                forceStopped = true;
                isPaused = false;
                player_play();
            }
        }
    }
}
