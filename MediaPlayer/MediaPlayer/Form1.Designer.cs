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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.treeView1.Location = new System.Drawing.Point(2, 2);
            this.treeView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.treeView1.Name = "treeView1";
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
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode22,
            treeNode24});
            this.treeView1.Size = new System.Drawing.Size(409, 964);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(864, 1028);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1094, 1028);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(641, 1028);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 38);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1858, 1102);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private TreeView treeView1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}