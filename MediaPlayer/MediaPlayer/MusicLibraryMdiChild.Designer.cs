using System.Windows.Forms;

namespace MediaPlayer
{
    partial class MusicLibraryForm
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
            this.SongList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.SongList.FormattingEnabled = true;
            this.SongList.ItemHeight = 25;
            this.SongList.Location = new System.Drawing.Point(21, 280);
            this.SongList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.SongList.Name = "listBox1";
            this.SongList.Size = new System.Drawing.Size(1418, 629);
            this.SongList.TabIndex = 0;
            // 
            // MusicLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 937);
            this.Controls.Add(this.SongList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "MusicLibraryForm";
            this.Text = "MusicLibraryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox SongList;
    }
}