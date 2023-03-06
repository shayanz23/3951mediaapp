namespace MediaPlayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("New Playlist...");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Playlists", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Songs", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Videos", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Pictures", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeView1.Location = new System.Drawing.Point(-1, -1);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "SongLibrary";
            treeNode1.Text = "Library";
            treeNode2.Name = "NewSongPlaylist";
            treeNode2.Text = "New Playlist...";
            treeNode3.Name = "SongPlaylists";
            treeNode3.Text = "Playlists";
            treeNode4.Name = "SongsNode";
            treeNode4.Text = "Songs";
            treeNode5.Name = "VideoLibrary";
            treeNode5.Text = "Library";
            treeNode6.Name = "VideosNode";
            treeNode6.Text = "Videos";
            treeNode7.Name = "PictureLibrary";
            treeNode7.Text = "Library";
            treeNode8.Name = "PicturesNode";
            treeNode8.Text = "Pictures";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode6,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(246, 574);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 670);
            this.Controls.Add(this.treeView1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private TreeView treeView1;
    }
}