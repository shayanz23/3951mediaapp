using ControlLibraryShayan;
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
        MediaFoundationReader audioFileReader;
        WaveOutEvent waveOut;
        private bool forceStopped;
        List<Audio> Queue = new List<Audio>();
        private bool isPaused;
        private Timer scrollTimer;
        private int scrollPosition;
        private string originalText;
        private Timer progressBarTimer;

        public MainForm()
        {
            InitializeComponent();
            setButtonImages();
            songLabelStart();
            VolumeInit();
            ScrollInit();
            ProgressBarInit();
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
            SongLibraryOpen();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            PlaylistManager.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ProgressBarInit()
        {
            progressBarTimer = new Timer();
            progressBarTimer.Interval = 100; // Update the progress bar every 100ms
            progressBarTimer.Tick += ProgressBarTimer_Tick;
            songProgressBar.MouseDown += SongProgressBar_MouseDown;
        }

        /// <summary>
        /// 
        /// </summary>
        private void VolumeInit()
        {
            volumeTrackbar.Value = 50;
            volumeTrackbar.Scroll += VolumeTrackbar_Scroll;
        }

        private void ScrollInit()
        {
            // Create a new timer
            scrollPosition = 0;
            scrollTimer = new Timer();
            scrollTimer.Interval = 150; // Set the timer interval (in milliseconds)
            scrollTimer.Enabled = IsTextTooLong(songLabel.Text, songLabel);
            scrollTimer.Tick += ScrollTimer_Tick;
        }

        /// <summary>
        /// 
        /// </summary>
        private void songLabelStart()
        {
            songLabel.AutoSize = false;
            songLabel.Width = 160;
            songLabel.Height = 20;
        }

        /// <summary>
        /// 
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
        /// Event listener for the Tick event of ScrollTimer,
        /// adds spaces to the text and runs GetScrollingText for the scrolling effect.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            scrollPosition++;

            if (scrollPosition > originalText.Length * 7) // 7 is an approximate character width in pixels
            {
                scrollPosition = 0;
            }

            songLabel.Text = "  " + GetScrollingText(originalText, scrollPosition);
        }

        /// <summary>
        /// Takes a string and returns it from the startPosition,
        /// also brings the parts behind the startPosition to the end.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="originalText"></param>
        /// <param name="startPosition"></param>
        /// <returns></returns>
        private string GetScrollingText(string originalText, int startPosition)
        {
            if (string.IsNullOrEmpty(originalText))
            {
                return string.Empty;
            }

            int displayLength = (songLabel.Width / 7) + 1; // 7 is an approximate character width in pixels
            string displayText = new string(' ', displayLength);

            for (int i = 0; i < displayLength; i++)
            {
                int charPosition = (startPosition + i) % originalText.Length;
                displayText = displayText.Remove(i, 1).Insert(i, originalText[charPosition].ToString());
            }

            return displayText;
        }

        /// <summary>
        /// Checks if the text is too long to fit in the label.
        /// Shayan Zahedanaraki
        /// </summary>
        /// <param name="text"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        private bool IsTextTooLong(string text, Label label)
        {
            using (Graphics g = CreateGraphics())
            {
                SizeF textSize = g.MeasureString(text, label.Font);
                return textSize.Width > label.Width;
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
        /// Plays the songs newly selected, unless the PlaybackState.Paused,
        /// then it just starts playing the currently playing song again.
        /// Also only creates a new instance of WaveOut if the waveOut is null
        /// or not paused.
        /// By Shayan Zahedanaraki
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
                    audioFileReader = new MediaFoundationReader(Queue[song_index].fileLocation);

                    songProgressBar.Minimum = 0;
                    songProgressBar.Maximum = (int)audioFileReader.TotalTime.TotalMilliseconds;
                    songProgressBar.Value = 0;
                    waveOut.Init(audioFileReader);

                    progressBarTimer.Start(); // Start the progress bar timer
                }
                UpdateAlbumArt(Queue[song_index].albumArt);
                UpdateSongName(Queue[song_index].title);
                UpdateArtistName(Queue[song_index].getArtists());
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
        /// by the FillQueue when replacing the playing song with another songs,
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
        /// updates the album art picture box to match currently playing song.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="coverArt"></param>
        private void UpdateAlbumArt(Image coverArt)
        {
            if (coverArt != null)
            {
                albumArtBox.Image = coverArt;
                albumArtBox.SizeMode = PictureBoxSizeMode.StretchImage;
            } else
            {
                albumArtBox.Image = null;
            }
        }

        /// <summary>
        /// updates the album art picture box to match currently playing song.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="coverArt"></param>
        private void UpdateSongName(string name)
        {
            if (name != null)
            {
                name = name + "     ";
                originalText = name;
                songLabel.Text = name;
                scrollTimer.Enabled = IsTextTooLong(name, songLabel);
            }
        }

        /// <summary>
        /// updates the album art picture box to match currently playing song.
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
        /// Fills the queue of songs to play and runs the player_play funtion.
        /// By Shayan Zahedanaraki
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
            playPauseButton1.playing = true;
            player_play();
        }


        /// <summary>
        /// Triggered when the user clicks on the Song Library in the contentTree.
        /// </summary>
        private void SongLibraryOpen()
        {

            //if childform already exists, get rid of it, and create new MusicLibraryForm instead.
            if (childForm != null)
            {
                childForm.Dispose();
            }
                childForm = new MusicLibraryForm();
                childForm.MdiParent = this;
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.Location = new Point(contentTree.Size.Width, startPosY);
                childForm.Size = new Size((int)(this.Size.Width / 1.285), contentTree.Size.Height);
                childForm.Show();
            
        }

        /// <summary>
        /// Items in contentTree click handler.
        /// By Shayan Zahedanaraki
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
                SongLibraryOpen();
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
            }
        }

        /// <summary>
        /// Event listener, Goes to the last audio in the queue.
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
