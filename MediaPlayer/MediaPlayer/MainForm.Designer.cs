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
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("New Playlist...");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Playlists", new System.Windows.Forms.TreeNode[] {
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Songs", new System.Windows.Forms.TreeNode[] {
            treeNode33,
            treeNode35});
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("Videos", new System.Windows.Forms.TreeNode[] {
            treeNode37});
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("Library");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("Pictures", new System.Windows.Forms.TreeNode[] {
            treeNode39});
            this.contentTree = new System.Windows.Forms.TreeView();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.songProgressBar = new System.Windows.Forms.ProgressBar();
            this.songLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.playPauseButton1 = new ControlLibraryShayan.PlayPauseButton();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contentTree
            // 
            this.contentTree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contentTree.Location = new System.Drawing.Point(1, 1);
            this.contentTree.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.contentTree.Name = "contentTree";
            treeNode33.Name = "SongLibrary";
            treeNode33.Text = "Library";
            treeNode34.Name = "NewSongPlaylist";
            treeNode34.Text = "New Playlist...";
            treeNode35.Name = "SongPlaylists";
            treeNode35.Text = "Playlists";
            treeNode36.Name = "SongsNode";
            treeNode36.Text = "Songs";
            treeNode37.Name = "VideoLibrary";
            treeNode37.Text = "Library";
            treeNode38.Name = "VideosNode";
            treeNode38.Text = "Videos";
            treeNode39.Name = "PictureLibrary";
            treeNode39.Text = "Library";
            treeNode40.Name = "PicturesNode";
            treeNode40.Text = "Pictures";
            this.contentTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode36,
            treeNode38,
            treeNode40});
            this.contentTree.Size = new System.Drawing.Size(206, 503);
            this.contentTree.TabIndex = 4;
            this.contentTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.contentTreeNodeMouseClick);
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(553, 554);
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
            this.previousButton.Location = new System.Drawing.Point(363, 554);
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
            this.songProgressBar.Location = new System.Drawing.Point(298, 520);
            this.songProgressBar.Name = "songProgressBar";
            this.songProgressBar.Size = new System.Drawing.Size(383, 22);
            this.songProgressBar.TabIndex = 12;
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.BackColor = System.Drawing.Color.White;
            this.songLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songLabel.Location = new System.Drawing.Point(103, 528);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(0, 16);
            this.songLabel.TabIndex = 14;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.BackColor = System.Drawing.Color.White;
            this.artistLabel.Location = new System.Drawing.Point(103, 554);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(0, 13);
            this.artistLabel.TabIndex = 15;
            // 
            // playPauseButton1
            // 
            this.playPauseButton1.FlatAppearance.BorderSize = 0;
            this.playPauseButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.playPauseButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.playPauseButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playPauseButton1.ForeColor = System.Drawing.Color.Black;
            this.playPauseButton1.Location = new System.Drawing.Point(472, 548);
            this.playPauseButton1.Name = "playPauseButton1";
            this.playPauseButton1.PausedBackgroundImage = null;
            this.playPauseButton1.playing = false;
            this.playPauseButton1.PlayingBackgroundImage = null;
            this.playPauseButton1.Size = new System.Drawing.Size(38, 36);
            this.playPauseButton1.TabIndex = 17;
            this.playPauseButton1.Text = "No Image";
            this.playPauseButton1.UseVisualStyleBackColor = true;
            this.playPauseButton1.Click += new System.EventHandler(this.playPauseButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.playPauseButton1);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.songProgressBar);
            this.Controls.Add(this.albumArtBox);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nextButton);
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
        private Button nextButton;
        private Button previousButton;
        private PictureBox albumArtBox;
        private ProgressBar songProgressBar;
        private Label songLabel;
        private Label artistLabel;
        private ControlLibraryShayan.PlayPauseButton playPauseButton1;
    }
}