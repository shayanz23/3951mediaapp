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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("New Playlist...");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Library", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.contentTree = new System.Windows.Forms.TreeView();
            this.albumArtBox = new System.Windows.Forms.PictureBox();
            this.songProgressBar = new System.Windows.Forms.ProgressBar();
            this.songLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.rewindButton = new ControlLibraryShayan.PictureButton();
            this.forwardButton = new ControlLibraryShayan.PictureButton();
            this.playPauseButton1 = new ControlLibraryShayan.PlayPauseButton();
            this.timePlayedLabel = new System.Windows.Forms.Label();
            this.timeRemainingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).BeginInit();
            this.SuspendLayout();
            // 
            // contentTree
            // 
            this.contentTree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contentTree.Location = new System.Drawing.Point(1, 1);
            this.contentTree.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.contentTree.Name = "contentTree";
            treeNode1.Name = "NewSongPlaylist";
            treeNode1.Text = "New Playlist...";
            treeNode2.Name = "SongLibrary";
            treeNode2.Text = "Library";
            this.contentTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.contentTree.Size = new System.Drawing.Size(206, 503);
            this.contentTree.TabIndex = 4;
            this.contentTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.contentTreeNodeMouseClick);
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
            // rewindButton
            // 
            this.rewindButton.BackColor = System.Drawing.Color.White;
            this.rewindButton.FlatAppearance.BorderSize = 0;
            this.rewindButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rewindButton.ForeColor = System.Drawing.Color.Black;
            this.rewindButton.Location = new System.Drawing.Point(377, 547);
            this.rewindButton.Name = "rewindButton";
            this.rewindButton.Size = new System.Drawing.Size(44, 35);
            this.rewindButton.TabIndex = 21;
            this.rewindButton.Text = "No Image";
            this.rewindButton.UseVisualStyleBackColor = true;
            this.rewindButton.Click += new System.EventHandler(this.rewindButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.BackColor = System.Drawing.Color.White;
            this.forwardButton.FlatAppearance.BorderSize = 0;
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardButton.ForeColor = System.Drawing.Color.Black;
            this.forwardButton.Location = new System.Drawing.Point(565, 547);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(44, 35);
            this.forwardButton.TabIndex = 19;
            this.forwardButton.Text = "No Image";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // playPauseButton1
            // 
            this.playPauseButton1.BackColor = System.Drawing.Color.White;
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
            // timePlayedLabel
            // 
            this.timePlayedLabel.AutoSize = true;
            this.timePlayedLabel.Location = new System.Drawing.Point(261, 531);
            this.timePlayedLabel.Name = "timePlayedLabel";
            this.timePlayedLabel.Size = new System.Drawing.Size(34, 13);
            this.timePlayedLabel.TabIndex = 23;
            this.timePlayedLabel.Text = "00:00";
            // 
            // timeRemainingLabel
            // 
            this.timeRemainingLabel.AutoSize = true;
            this.timeRemainingLabel.Location = new System.Drawing.Point(687, 530);
            this.timeRemainingLabel.Name = "timeRemainingLabel";
            this.timeRemainingLabel.Size = new System.Drawing.Size(34, 13);
            this.timeRemainingLabel.TabIndex = 24;
            this.timeRemainingLabel.Text = "00:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.timeRemainingLabel);
            this.Controls.Add(this.timePlayedLabel);
            this.Controls.Add(this.rewindButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.playPauseButton1);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.songProgressBar);
            this.Controls.Add(this.albumArtBox);
            this.Controls.Add(this.contentTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.albumArtBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TreeView contentTree;
        private PictureBox albumArtBox;
        private ProgressBar songProgressBar;
        private Label songLabel;
        private Label artistLabel;
        private ControlLibraryShayan.PlayPauseButton playPauseButton1;
        private ControlLibraryShayan.PictureButton forwardButton;
        private ControlLibraryShayan.PictureButton rewindButton;
        private Label timePlayedLabel;
        private Label timeRemainingLabel;
    }
}