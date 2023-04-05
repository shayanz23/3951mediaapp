using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class NewPlaylistDialog : Form
    {

        /// <summary>
        /// name property for the New playlist.
        /// </summary>
        public string newPlaylistName { get; set; }
        public NewPlaylistDialog()
        {
            InitializeComponent();
            NewPlaylistTextbox.Select();
        }

        /// <summary>
        /// Ok button that checks if playlist name is already used or empty and doesn't continue if so.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKPlaylistButton_Click(object sender, EventArgs e)
        {
            if (NewPlaylistTextbox.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Name must not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            } 
            else if (PlaylistManager.Playlists.Any(item => item.Name == NewPlaylistTextbox.Text.ToString()))
            {
                MessageBox.Show("Name must not be already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else if (NewPlaylistTextbox.Text.ToString() == "New Playlist..." || NewPlaylistTextbox.Text.ToString() == "Library" 
                || NewPlaylistTextbox.Text.ToString() == "Now Playing")
            {
                MessageBox.Show("Invalid Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            else
            {
                newPlaylistName = NewPlaylistTextbox.Text;
                DialogResult = DialogResult.OK;
            }
            
        }
    }
}
