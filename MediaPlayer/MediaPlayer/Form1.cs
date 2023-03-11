

using NAudio.Wave;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Child form that is not yet instantiated
        /// </summary>
        Form childForm;
        int formWidth = 860;
        int formHeight = 580;
        int startPosX = 240;
        int startPosY = 0;
        List<Audio> Queue = new List<Audio> ();

        Audio selectedAudio;


        public Form1()
        {
            InitializeComponent();

            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.White;

            //sets the size of form1.
            this.Size = new Size(1000, 620);

            // Expands the three main nodes of the treeview that shows the contents.
            for (int i = 0; i < contentTree.Nodes.Count; i++)
            {
                if (contentTree.Nodes[i].Name == "SongsNode" || contentTree.Nodes[i].Name == "VideosNode" || contentTree.Nodes[i].Name == "PicturesNode")
                {
                    contentTree.Nodes[i].Expand();
                }
            }
        }


        public void SetSelectedAudio(Audio a)
        {
            selectedAudio = a;
            MessageBox.Show(selectedAudio.getArtists());
            fillQueue();
            PlayPause();

        }


        void PlayPause()
        {
            // Create a WaveOutEvent to play the audio
            WaveOutEvent waveOut = new WaveOutEvent();

            // Loop through the files and play them in order
            for (int i = 0;  i < Queue.Count; i++)
            {
                // Create a WaveFileReader for the file
                var reader = new AudioFileReader(Queue[i].fileLocation);

                // Add the reader to the WaveOutEvent
                waveOut.Init(reader);

                // Play the audio
                waveOut.Play();

                // Wait for the audio to finish playing
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(100);
                }

                // Dispose of the WaveFileReader to free up resources
                reader.Dispose();
            }

            // Dispose of the WaveOutEvent to free up resources
            waveOut.Dispose();
        }

        void fillQueue()
        {
            bool add = false;
            for (int i = 0; i < MediaScanner.Audios.Count; i++)
            {
                if (MediaScanner.Audios[i] == selectedAudio)
                {
                    add = true;
                }
                if (add)
                {
                    Queue.Add(MediaScanner.Audios[i]);
                }
            }
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

    }
}