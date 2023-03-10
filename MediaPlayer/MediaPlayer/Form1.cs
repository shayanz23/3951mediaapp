

using System.Collections;
using System.Drawing;
using System.Windows.Forms;

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


        public Form1()
        {
            InitializeComponent();
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
                childForm.Size = new Size((int)(this.Size.Width / 1.315), contentTree.Size.Height);
                childForm.Show();
            }
            // Create a MusicLibraryForm
            else
            {
                childForm = new MusicLibraryForm();
                childForm.MdiParent = this;
                childForm.StartPosition = FormStartPosition.Manual;
                childForm.Location = new Point(contentTree.Size.Width, startPosY);
                childForm.Size = new Size((int)(this.Size.Width / 1.315), contentTree.Size.Height);
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