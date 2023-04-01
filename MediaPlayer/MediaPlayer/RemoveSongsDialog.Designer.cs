using System.Windows.Forms;

namespace MediaPlayer
{
    partial class RemoveSongsDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OKPlaylistButton = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.songData = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.songData)).BeginInit();
            this.SuspendLayout();
            // 
            // OKPlaylistButton
            // 
            this.OKPlaylistButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKPlaylistButton.Location = new System.Drawing.Point(619, 418);
            this.OKPlaylistButton.Name = "OKPlaylistButton";
            this.OKPlaylistButton.Size = new System.Drawing.Size(64, 20);
            this.OKPlaylistButton.TabIndex = 0;
            this.OKPlaylistButton.Text = "OK";
            this.OKPlaylistButton.UseVisualStyleBackColor = true;
            this.OKPlaylistButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton2
            // 
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(533, 418);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(64, 20);
            this.CancelButton2.TabIndex = 1;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(12, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(151, 15);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "Select Songs from Playlist:";
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.songData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.songData.ColumnHeadersHeight = 25;
            this.songData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.Artist,
            this.Duration});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.songData.DefaultCellStyle = dataGridViewCellStyle2;
            this.songData.EnableHeadersVisualStyles = false;
            this.songData.GridColor = System.Drawing.Color.Silver;
            this.songData.Location = new System.Drawing.Point(15, 37);
            this.songData.Margin = new System.Windows.Forms.Padding(2);
            this.songData.Name = "songData";
            this.songData.ReadOnly = true;
            this.songData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.songData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.songData.RowHeadersVisible = false;
            this.songData.RowHeadersWidth = 62;
            this.songData.RowTemplate.Height = 33;
            this.songData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.songData.Size = new System.Drawing.Size(668, 366);
            this.songData.TabIndex = 5;
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
            // RemoveSongsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 450);
            this.Controls.Add(this.songData);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OKPlaylistButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveSongsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Remove songs";
            ((System.ComponentModel.ISupportInitialize)(this.songData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button OKPlaylistButton;
        private Button CancelButton2;
        private Label nameLabel;
        private DataGridView songData;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Artist;
        private DataGridViewTextBoxColumn Duration;
    }
}