using System.Windows.Forms;

namespace MediaPlayer
{
    partial class PlaylistMdiChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistMdiChild));
            this.playButton = new System.Windows.Forms.Button();
            this.shuffleButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.songData = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addSongs = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.remSongsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.songData)).BeginInit();
            this.SuspendLayout();
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(207, 124);
            this.playButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(74, 23);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // shuffleButton
            // 
            this.shuffleButton.Location = new System.Drawing.Point(304, 124);
            this.shuffleButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.shuffleButton.Name = "shuffleButton";
            this.shuffleButton.Size = new System.Drawing.Size(74, 23);
            this.shuffleButton.TabIndex = 3;
            this.shuffleButton.Text = "Shuffle";
            this.shuffleButton.UseVisualStyleBackColor = true;
            this.shuffleButton.Click += new System.EventHandler(this.shuffleButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(40, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 62);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(102, 23);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 62);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(102, 85);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 62);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(40, 85);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(62, 62);
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // songData
            // 
            this.songData.AllowUserToAddRows = false;
            this.songData.AllowUserToDeleteRows = false;
            this.songData.AllowUserToOrderColumns = true;
            this.songData.AllowUserToResizeColumns = false;
            this.songData.AllowUserToResizeRows = false;
            this.songData.BackgroundColor = System.Drawing.Color.White;
            this.songData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.songData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.songData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.songData.ColumnHeadersHeight = 25;
            this.songData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.Artist,
            this.Duration});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.songData.DefaultCellStyle = dataGridViewCellStyle5;
            this.songData.EnableHeadersVisualStyles = false;
            this.songData.GridColor = System.Drawing.Color.Silver;
            this.songData.Location = new System.Drawing.Point(12, 163);
            this.songData.Margin = new System.Windows.Forms.Padding(2);
            this.songData.MultiSelect = false;
            this.songData.Name = "songData";
            this.songData.ReadOnly = true;
            this.songData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.songData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.songData.RowHeadersVisible = false;
            this.songData.RowHeadersWidth = 62;
            this.songData.RowTemplate.Height = 33;
            this.songData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.songData.Size = new System.Drawing.Size(708, 304);
            this.songData.TabIndex = 0;
            this.songData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SongData_CellClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 18;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.FillWeight = 75F;
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 8;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Artist
            // 
            this.Artist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Artist.FillWeight = 25F;
            this.Artist.HeaderText = "Artist";
            this.Artist.MinimumWidth = 8;
            this.Artist.Name = "Artist";
            this.Artist.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Duration.HeaderText = "Duration";
            this.Duration.MinimumWidth = 8;
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 78;
            // 
            // addSongs
            // 
            this.addSongs.Location = new System.Drawing.Point(402, 124);
            this.addSongs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.addSongs.Name = "addSongs";
            this.addSongs.Size = new System.Drawing.Size(74, 23);
            this.addSongs.TabIndex = 8;
            this.addSongs.Tag = resources.GetString("addSongs.Tag");
            this.addSongs.Text = "Add Songs";
            this.addSongs.UseVisualStyleBackColor = true;
            this.addSongs.Click += new System.EventHandler(this.addSongs_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(201, 47);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(86, 31);
            this.nameLabel.TabIndex = 9;
            this.nameLabel.Text = "label1";
            // 
            // remSongsBtn
            // 
            this.remSongsBtn.Location = new System.Drawing.Point(502, 124);
            this.remSongsBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.remSongsBtn.Name = "remSongsBtn";
            this.remSongsBtn.Size = new System.Drawing.Size(94, 23);
            this.remSongsBtn.TabIndex = 10;
            this.remSongsBtn.Tag = resources.GetString("remSongsBtn.Tag");
            this.remSongsBtn.Text = "Remove Songs";
            this.remSongsBtn.UseVisualStyleBackColor = true;
            this.remSongsBtn.Click += new System.EventHandler(this.remSongsBtn_Click);
            // 
            // PlaylistMdiChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 487);
            this.Controls.Add(this.remSongsBtn);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.addSongs);
            this.Controls.Add(this.songData);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.shuffleButton);
            this.Controls.Add(this.playButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "PlaylistMdiChild";
            this.Text = "MusicLibraryForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.songData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button playButton;
        private Button shuffleButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private DataGridView songData;
        private Button addSongs;
        private Label nameLabel;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Artist;
        private DataGridViewTextBoxColumn Duration;
        private Button remSongsBtn;
    }
}