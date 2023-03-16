using System.Windows.Forms;

namespace MediaPlayer
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("New Playlist...");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Playlists", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Songs", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Videos", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Pictures", new System.Windows.Forms.TreeNode[] {
            treeNode15});
            this.contentTree = new System.Windows.Forms.TreeView();
            this.pausePlayButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.songProgressBar = new System.Windows.Forms.ProgressBar();
            this.songLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contentTree
            // 
            this.contentTree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contentTree.Location = new System.Drawing.Point(1, 1);
            this.contentTree.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.contentTree.Name = "contentTree";
            treeNode9.Name = "SongLibrary";
            treeNode9.Text = "Library";
            treeNode10.Name = "NewSongPlaylist";
            treeNode10.Text = "New Playlist...";
            treeNode11.Name = "SongPlaylists";
            treeNode11.Text = "Playlists";
            treeNode12.Name = "SongsNode";
            treeNode12.Text = "Songs";
            treeNode13.Name = "VideoLibrary";
            treeNode13.Text = "Library";
            treeNode14.Name = "VideosNode";
            treeNode14.Text = "Videos";
            treeNode15.Name = "PictureLibrary";
            treeNode15.Text = "Library";
            treeNode16.Name = "PicturesNode";
            treeNode16.Text = "Pictures";
            this.contentTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode14,
            treeNode16});
            this.contentTree.Size = new System.Drawing.Size(206, 503);
            this.contentTree.TabIndex = 4;
            this.contentTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.contentTreeNodeMouseClick);
            // 
            // pausePlayButton
            // 
            this.pausePlayButton.Location = new System.Drawing.Point(459, 548);
            this.pausePlayButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pausePlayButton.Name = "pausePlayButton";
            this.pausePlayButton.Size = new System.Drawing.Size(66, 20);
            this.pausePlayButton.TabIndex = 6;
            this.pausePlayButton.Text = "PlayPause";
            this.pausePlayButton.UseVisualStyleBackColor = true;
            this.pausePlayButton.Click += new System.EventHandler(this.playPauseButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(560, 548);
            this.nextButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(64, 20);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(360, 548);
            this.previousButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(64, 20);
            this.previousButton.TabIndex = 8;
            this.previousButton.Text = "Previous";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // albumArtBox
            // 
            this.albumArtBox.BackColor = System.Drawing.Color.White;
            this.albumArtBox.Location = new System.Drawing.Point(24, 510);
            this.albumArtBox.Name = "albumArtBox";
            this.albumArtBox.Size = new System.Drawing.Size(62, 58);
            this.albumArtBox.TabIndex = 10;
            this.albumArtBox.TabStop = false;
            // 
            // songProgressBar
            // 
            this.songProgressBar.Location = new System.Drawing.Point(302, 519);
            this.songProgressBar.Name = "songProgressBar";
            this.songProgressBar.Size = new System.Drawing.Size(383, 23);
            this.songProgressBar.TabIndex = 12;
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.BackColor = System.Drawing.Color.White;
            this.songLabel.Location = new System.Drawing.Point(103, 520);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(0, 13);
            this.songLabel.TabIndex = 14;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.BackColor = System.Drawing.Color.White;
            this.artistLabel.Location = new System.Drawing.Point(103, 546);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(0, 13);
            this.artistLabel.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 573);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.songProgressBar);
            this.Controls.Add(this.albumArtBox);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.pausePlayButton);
            this.Controls.Add(this.contentTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TreeView contentTree;
        private Button pausePlayButton;
        private Button nextButton;
        private Button previousButton;
        private PictureBox albumArtBox;
        private ProgressBar songProgressBar;
        private Label songLabel;
        private Label artistLabel;
    }
}