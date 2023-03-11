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
            this.SongList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // SongList
            // 
            this.SongList.HideSelection = false;
            this.SongList.Location = new System.Drawing.Point(12, 164);
            this.SongList.Name = "SongList";
            this.SongList.Size = new System.Drawing.Size(709, 311);
            this.SongList.TabIndex = 1;
            this.SongList.UseCompatibleStateImageBehavior = false;
            // 
            // MusicLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 487);
            this.Controls.Add(this.SongList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MusicLibraryForm";
            this.Text = "MusicLibraryForm";
            this.ResumeLayout(false);

        }

        #endregion
        private ListView SongList;
    }
}