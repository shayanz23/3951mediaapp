using System.Windows.Forms;

namespace MediaPlayer
{
    partial class NewPlaylistDialog
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
            this.OKPlaylistButton = new System.Windows.Forms.Button();
            this.CancelButton2 = new System.Windows.Forms.Button();
            this.NewPlaylistTextbox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OKPlaylistButton
            // 
            this.OKPlaylistButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKPlaylistButton.Location = new System.Drawing.Point(305, 46);
            this.OKPlaylistButton.Name = "OKPlaylistButton";
            this.OKPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this.OKPlaylistButton.TabIndex = 0;
            this.OKPlaylistButton.Text = "OK";
            this.OKPlaylistButton.UseVisualStyleBackColor = true;
            this.OKPlaylistButton.Click += new System.EventHandler(this.OKPlaylistButton_Click);
            // 
            // CancelButton2
            // 
            this.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton2.Location = new System.Drawing.Point(305, 93);
            this.CancelButton2.Name = "CancelButton2";
            this.CancelButton2.Size = new System.Drawing.Size(75, 23);
            this.CancelButton2.TabIndex = 1;
            this.CancelButton2.Text = "Cancel";
            this.CancelButton2.UseVisualStyleBackColor = true;
            // 
            // NewPlaylistTextbox
            // 
            this.NewPlaylistTextbox.Location = new System.Drawing.Point(26, 93);
            this.NewPlaylistTextbox.Name = "NewPlaylistTextbox";
            this.NewPlaylistTextbox.Size = new System.Drawing.Size(246, 23);
            this.NewPlaylistTextbox.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(246, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Enter a Name: ";
            // 
            // NewPlaylistDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 158);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.NewPlaylistTextbox);
            this.Controls.Add(this.CancelButton2);
            this.Controls.Add(this.OKPlaylistButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewPlaylistDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Playlist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button OKPlaylistButton;
        private Button CancelButton2;
        private TextBox NewPlaylistTextbox;
        private TextBox textBox1;
    }
}