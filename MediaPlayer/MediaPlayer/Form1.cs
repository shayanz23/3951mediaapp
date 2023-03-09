

using System.Collections;

namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        Form childForm;
        int formWidth = 860;
        int formHeight = 580;
        int startPosX = 240;
        int startPosY = 0;


        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                if (treeView1.Nodes[i].Name == "SongsNode" || treeView1.Nodes[i].Name == "VideosNode" || treeView1.Nodes[i].Name == "PicturesNode")
                {
                    treeView1.Nodes[i].Expand();
                }
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
            } else if (e.Node.Name == "SongLibrary")
            {
                if (childForm != null)
                {
                    childForm.Dispose();
                    childForm = new MusicLibraryForm();
                    childForm.MdiParent = this;
                    childForm.StartPosition= FormStartPosition.Manual;
                    childForm.Location = new Point(startPosX, startPosY);
                    childForm.Size = new Size(formWidth, formHeight);
                    childForm.Show();
                } else
                {
                    childForm = new MusicLibraryForm();
                    childForm.MdiParent = this;
                    childForm.StartPosition = FormStartPosition.Manual;
                    childForm.Location = new Point(startPosX, startPosY);
                    childForm.Size = new Size(formWidth, formHeight);
                    childForm.Show();
                }
                
            }
        }

    }
}