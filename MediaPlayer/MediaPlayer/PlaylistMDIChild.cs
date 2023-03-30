using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MediaPlayer
{
    public partial class PlaylistMdiChild : Form
    {

        // Declare variables and collections
        private Dictionary<string, Audio> titleToAudioLookup;
        Audio selectedAudio;
        List<Audio> songs = new List<Audio>();
        List<Audio> Queue = new List<Audio>();

        /// <summary>
        /// Constructor for the MusicLibraryForm class
        /// </summary>
        public PlaylistMdiChild()
        {
            InitializeComponent();
            getSongs();
            titleToAudioLookup = songs.ToDictionary(audio => audio.title);
            fillList();
            fillPictures();
            songData.Size = new Size(760, 325);

        }

        /// <summary>
        /// Fills the form with pictures
        /// By Shayan Zahedanaraki
        /// </summary>
        public void fillPictures()
        {

            bool hasNonNullAlbumArt = songs.Any(song => song.albumArt != null);
            if (!hasNonNullAlbumArt)
            {
                return;
            }
            int numOfCompatible = 0;
            List<PictureBox> pictureBoxes = new List<PictureBox>
            {
                pictureBox1,
                pictureBox2,
                pictureBox3,
                pictureBox4
            };
            int index = 0;
            int imagesListCount = songs.Count;

            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxes[i].Image = null;
                while (songs[index % imagesListCount].albumArt == null)
                {
                    index++;
                }

                pictureBoxes[i].Image = songs[index % imagesListCount].albumArt;
                index++;
            }
        }

        /// <summary>
        /// Fills the queue with the songs
        /// By Shayan Zahedanaraki
        /// </summary>
        void fillQueue()
        {
            Queue.Clear();
            bool add = false;
            for (int i = 0; i < songs.Count; i++)
            {
                if (songs[i] == selectedAudio)
                {
                    add = true;
                }
                if (add)
                {
                    Queue.Add(songs[i]);
                }
            }
        }

        /// <summary>
        /// Fills the ListView with the songs
        /// By James
        /// </summary>
        void fillList()
        {
            for (int i = 0; i < songs.Count; i++)
            {

                string a = songs[i].title;
                string b = "";

                if (songs[i].getArtists().Length > 0) {
                        b += songs[i].getArtists();
                } else {
                    b = "Unknown";
                }

                string c = songs[i].duration;

                this.songData.Rows.Add(i, a, b, c);
                
            }
            songData.ClearSelection();
        }

        /// <summary>
        /// Retrieves the songs from MediaScanner
        /// By Shayan Zahedanaraki
        /// </summary>
        private void getSongs()
        {
            for (int i = 0; i < SongScanner.Audios.Count; i++)
            {
                songs.Add(SongScanner.Audios[i]);
            }
        }

        /// <summary>
        /// Performs a weighted shuffle on the list
        /// By Shayan Zahedanaraki
        /// </summary>
        public static void WeightedShuffle<T>(IList<T> list, Func<T, T, double> weightFunc)
        {
            Random random = new Random();

            for (int i = list.Count - 1; i > 0; i--)
            {
                List<double> cumulativeWeights = new List<double>();
                double totalWeight = 0;

                for (int j = 0; j <= i; j++)
                {
                    double weight = weightFunc(list[i], list[j]);
                    totalWeight += weight;
                    cumulativeWeights.Add(totalWeight);
                }

                double randomWeight = random.NextDouble() * totalWeight;

                int selectedIndex = cumulativeWeights.FindIndex(w => w > randomWeight);

                if (selectedIndex < 0)
                {
                    selectedIndex = i;
                }

                T temp = list[i];
                list[i] = list[selectedIndex];
                list[selectedIndex] = temp;
            }
        }

        /// <summary>
        /// Calculates the Jaro-Winkler similarity between two strings
        /// By Shayan Zahedanaraki
        /// </summary>
        public static double JaroWinklerSimilarity(string s1, string s2)
        {
            int m = 0;
            int n = s1.Length;
            int p = s2.Length;

            if (n == 0 || p == 0)
            {
                return 0;
            }

            int range = Math.Max(0, Math.Max(n, p) / 2 - 1);

            bool[] s1Matches = new bool[n];
            bool[] s2Matches = new bool[p];

            for (int i = 0; i < n; i++)
            {
                int start = Math.Max(0, i - range);
                int end = Math.Min(i + range + 1, p);

                for (int j = start; j < end; j++)
                {
                    if (s2Matches[j]) continue;
                    if (s1[i] != s2[j]) continue;

                    s1Matches[i] = true;
                    s2Matches[j] = true;
                    m++;
                    break;
                }
            }

            if (m == 0)
            {
                return 0;
            }

            int k = 0;
            int numTranspositions = 0;
            for (int i = 0; i < n; i++)
            {
                if (!s1Matches[i]) continue;

                while (!s2Matches[k]) k++;

                if (s1[i] != s2[k]) numTranspositions++;

                k++;
            }

            double jaro = ((double)m / n + (double)m / p + (double)(m - numTranspositions / 2) / m) / 3;

            int prefixLength = 0;

            for (int i = 0; i < Math.Min(4, Math.Min(n, p)); i++)
            {
                if (s1[i] == s2[i]) prefixLength++;
                else break;
            }

            return jaro + prefixLength * 0.1 * (1 - jaro);
        }

        /// <summary>
        /// Handles the click event for the shuffle button
        /// By Shayan Zahedanaraki
        /// </summary>
        private void shuffleButton_Click(object sender, EventArgs e)
        {
            List<Audio> songCandidates = new List<Audio>(songs);
            WeightedShuffle(songCandidates, (a, b)
                => JaroWinklerSimilarity(a.getArtists(), b.getArtists()));
            Queue = new List<Audio>(songCandidates);
            MainForm parent = (MainForm)MdiParent;
            parent.FillQueue(Queue);

        }

        /// <summary>
        /// Handles the click event for the play button
        /// By Shayan Zahedanaraki
        /// </summary>
        private void playButton_Click(object sender, EventArgs e)
        {
            Queue = new List<Audio>(songs);
            MainForm parent = (MainForm)this.MdiParent;
            parent.FillQueue(Queue);
        }

        private void SongData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            songData.ClearSelection();
        }

        /// <summary>
        /// Handles the event when the DataGridView selection is changed.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SongData_CellClick(object sender, DataGridViewCellEventArgs e) {

            if (e.RowIndex == -1)
            {
                return;
            }
            string selectedItem = songData[1, e.RowIndex].Value.ToString();
            selectedAudio = null;

            titleToAudioLookup.TryGetValue(selectedItem, out selectedAudio);

            if (selectedAudio != null) {
                MainForm parent = (MainForm)this.MdiParent;
                fillQueue();
                parent.FillQueue(Queue);
            }

        }
    }
}