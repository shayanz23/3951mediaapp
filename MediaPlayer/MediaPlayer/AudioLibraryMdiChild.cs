using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayer
{
    public partial class MusicLibraryForm : Form
    {
        public MusicLibraryForm()
        {
            InitializeComponent();
        }

        void fillList()
        {
            for (int i = 0; i < MediaScanner.Audios.Count; i++)
            {
                StringBuilder titleBuilder = new StringBuilder();
                StringBuilder artistBuilder = new StringBuilder();
                StringBuilder lengthBuilder = new StringBuilder();
                if (MediaScanner.Audios[i] != null)
                {
                    titleBuilder.Append(MediaScanner.Audios[i].title);
                }
            }
        }
    }
}
