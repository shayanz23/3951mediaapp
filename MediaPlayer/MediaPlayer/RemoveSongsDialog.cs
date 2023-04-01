using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class RemoveSongsDialog : Form
    {

        List<Song> songs = new List<Song>();
        List<Song> songsToRm = new List<Song>();
        public List<Song> SongsToRm { get { return songsToRm; } }


        public RemoveSongsDialog( List<Song> songs)
        {
            InitializeComponent();
            this.songs = songs;
            fillList();
            
        }

        /// <summary>
        /// Ok button that adds songs in the playlist to list of songs the user can remove.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in songData.SelectedRows)
            {
                foreach (Song a in songs)
                {
                    if (row.Cells[1].Value.ToString() == a.Title)
                    {
                        SongsToRm.Add(a);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Fills the ListView with the songs
        /// By James Lum
        /// </summary>
        void fillList()
        {
            for (int i = 0; i < songs.Count; i++)
            {

                string a = songs[i].Title;
                string b = "";

                if (songs[i].GetArtists().Length > 0)
                {
                    b += songs[i].GetArtists();
                }
                else
                {
                    b = "Unknown";
                }

                string c = songs[i].Duration;

                this.songData.Rows.Add(i + 1, a, b, c);

            }
            songData.ClearSelection();
        }

    }
}
