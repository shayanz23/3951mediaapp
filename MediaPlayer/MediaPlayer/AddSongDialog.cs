using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class AddSongsDialog : Form
    {

        private List<Song> songs = new List<Song>();

        /// <summary>
        /// Songs property for getting the songsNext selected by the user.
        /// </summary>
        public List<Song> Songs { get { return songs; } }


        public AddSongsDialog()
        {
            InitializeComponent();
            fillList();
            
        }

        /// <summary>
        /// Ok button that adds the songsNext selected by the user to the songsNext list for the parent to then
        /// add to the playlist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in songData.SelectedRows)
            {
                string title = row.Cells[1].Value.ToString();
                Song matchingSong = SongManager.Songs.FirstOrDefault(song => song.Title == title);

                if (matchingSong != null)
                {
                    songs.Add(matchingSong);
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

                if (SongManager.Songs[i].GetArtists().Length > 0)
                {
                    b += SongManager.Songs[i].GetArtists();
                }
                else
                {
                    b = "Unknown";
                }

                string c = SongManager.Songs[i].Duration;

                this.songData.Rows.Add(i + 1, a, b, c);

            }
            songData.ClearSelection();
        }

    }
}
