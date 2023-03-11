using System.Windows.Forms;

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
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("New Playlist...");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Playlists", new System.Windows.Forms.TreeNode[] {
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Songs", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Videos", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Pictures", new System.Windows.Forms.TreeNode[] {
            treeNode23});
            this.contentTree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contentTree
            // 
            this.contentTree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contentTree.Location = new System.Drawing.Point(1, 1);
            this.contentTree.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.contentTree.Name = "contentTree";
            treeNode17.Name = "SongLibrary";
            treeNode17.Text = "Library";
            treeNode18.Name = "NewSongPlaylist";
            treeNode18.Text = "New Playlist...";
            treeNode19.Name = "SongPlaylists";
            treeNode19.Text = "Playlists";
            treeNode20.Name = "SongsNode";
            treeNode20.Text = "Songs";
            treeNode21.Name = "VideoLibrary";
            treeNode21.Text = "Library";
            treeNode22.Name = "VideosNode";
            treeNode22.Text = "Videos";
            treeNode23.Name = "PictureLibrary";
            treeNode23.Text = "Library";
            treeNode24.Name = "PicturesNode";
            treeNode24.Text = "Pictures";
            this.contentTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode22,
            treeNode24});
            this.contentTree.Size = new System.Drawing.Size(206, 503);
            this.contentTree.TabIndex = 4;
            this.contentTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.contentTreeNodeMouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 535);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(547, 535);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 20);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(320, 535);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 20);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // albumArtBox
            // 
            this.albumArtBox.Location = new System.Drawing.Point(24, 510);
            this.albumArtBox.Name = "albumArtBox";
            this.albumArtBox.Size = new System.Drawing.Size(62, 58);
            this.albumArtBox.TabIndex = 10;
            this.albumArtBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 573);
            this.Controls.Add(this.albumArtBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.contentTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TreeView contentTree;
        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox albumArtBox;
    }
}