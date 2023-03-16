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
    public partial class MusicLibraryForm : Form
    {
        /// <summary>
        /// Currently selected audio.
        /// </summary>
        Audio selectedAudio;
        /// <summary>
        /// All the songs in this library or playlist.
        /// </summary>
        List<Audio> songs = new List<Audio>();
        /// <summary>
        /// songs about to be passed to parent to play.
        /// </summary>
        List<Audio> Queue = new List<Audio>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public MusicLibraryForm()
        {
            InitializeComponent();
            SongList.View = View.Details;
            SongList.Columns.Add("Songs: ");
            SongList.Columns[0].Width = 600;
            SongList.ItemSelectionChanged += myListView_ItemSelectionChanged;
            fillList();
            SongList.Width = Width;
            songs = getSongs();
            fillPictures();
        }

        /// <summary>
        /// fills in the decorative picture boxes for this library or playlist.
        /// </summary>
        public void fillPictures()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            if (SongList.Items.Count == 0)
            {
                return;
            }
            if (SongList.Items.Count >= 4 && songs[0].coverArt != null
                && songs[1].coverArt != null && songs[2].coverArt != null
                && songs[3].coverArt != null)
            {
                pictureBox1.Image = songs[0].coverArt;
                pictureBox2.Image = songs[1].coverArt;
                pictureBox3.Image = songs[2].coverArt;
                pictureBox4.Image = songs[3].coverArt;
            } 
            else if (SongList.Items.Count < 4 && songs[0].coverArt != null
                && songs[1].coverArt != null && songs[2].coverArt != null)
            {
                pictureBox1.Image = songs[0].coverArt;
                pictureBox2.Image = songs[1].coverArt;
                pictureBox3.Image = songs[2].coverArt;
                pictureBox4.Image = songs[1].coverArt;
            }
            else if (SongList.Items.Count < 3 && songs[0].coverArt != null
                && songs[1].coverArt != null)
            {
                pictureBox1.Image = songs[0].coverArt;
                pictureBox2.Image = songs[1].coverArt;
                pictureBox3.Image = songs[0].coverArt;
                pictureBox4.Image = songs[1].coverArt;
            }
            else if (SongList.Items.Count < 2 && songs[0].coverArt != null)
            {
                pictureBox1.Image = songs[0].coverArt;
                pictureBox2.Image = songs[0].coverArt;
                pictureBox3.Image = songs[0].coverArt;
                pictureBox4.Image = songs[0].coverArt;
            }
        }
        
        /// <summary>
        /// Event listener for when a song is chosen, the fillQueue is called,
        /// putting all songs after in the Queue,
        /// then the parent fillQueue is called to then play the songs in the Queue;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                // Get the selected item
                ListViewItem selectedItem = e.Item;

                selectedAudio = null;
                // Perform the desired action for the selected item
                for (int i = 0; i < MediaScanner.Audios.Count; i++)
                {
                    if (MediaScanner.Audios[i].title == selectedItem.Name)
                    {
                        selectedAudio= MediaScanner.Audios[i];
                        i = MediaScanner.Audios.Count;
                    }
                }
                if (selectedAudio != null)
                {
                    MainForm parent = (MainForm)this.MdiParent;
                    fillQueue();
                    parent.FillQueue(Queue);

                }
            }
        }

        /// <summary>
        /// Fills the queue with the songs after and including the selected one.
        /// </summary>
        void fillQueue()
        {
            Queue.Clear();
            bool add = false;
            for (int i = 0; i < MediaScanner.Audios.Count; i++)
            {
                if (MediaScanner.Audios[i] == selectedAudio)
                {
                    add = true;
                }
                if (add)
                {
                    Queue.Add(MediaScanner.Audios[i]);
                }
            }
        }



        /// <summary>
        /// Adds spaces or removes charecters from the end to make string a length 50. 
        /// (does not take into account that different characters are different lengths).
        /// </summary>
        /// <param name="stringBuilder"></param>
        void format(ref StringBuilder stringBuilder)
        {
            if (stringBuilder.Length >= 50)
            {
                int lengthTaken = stringBuilder.Length - 50;
                for (int j = lengthTaken; j > 0; j--)
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, stringBuilder.Length - 1);
                }
            }
            if (stringBuilder.Length < 50)
            {
                int lengthAdded = 50 - stringBuilder.Length;
                for (int j = 0; j < lengthAdded - 1; j++)
                {
                    stringBuilder.Append(' ');
                }
            }

        }

        /// <summary>
        /// Fills the song list with the list of songs found by the MediaScanner.
        /// </summary>
        void fillList()
        {
            for (int i = 0; i < MediaScanner.Audios.Count; i++)
            {
                StringBuilder titleBuilder = new StringBuilder();
                StringBuilder artistBuilder = new StringBuilder();
                StringBuilder durationBuilder = new StringBuilder();
                if (MediaScanner.Audios[i] != null)
                {
                    titleBuilder.Append(MediaScanner.Audios[i].title);
                    if (MediaScanner.Audios[i].artists == null)
                    {
                        artistBuilder.Append("Unknown");
                    }
                    else
                    {
                        artistBuilder.Append(MediaScanner.Audios[i].getArtists());
                    }
                    if (MediaScanner.Audios[i].duration == null)
                    {
                        durationBuilder.Append("Unknown");
                    }
                    else
                    {
                        durationBuilder.Append(MediaScanner.Audios[i].duration.ToString());
                    }
                    ListViewItem songItem = new ListViewItem();
                    songItem.Name = titleBuilder.ToString();
                    format(ref titleBuilder);
                    format(ref artistBuilder);
                    songItem.Text = titleBuilder.ToString()
                        + artistBuilder.ToString() + durationBuilder.ToString();
                    
                    SongList.Items.Add(songItem);

                }
            }
        }

        /// <summary>
        /// Gets songs in the library and returns them. Mainly for playlists though,
        /// not too useful here.
        /// </summary>
        /// <returns></returns>
        private List<Audio> getSongs()
        {
            List<Audio> songsInLibrary = new List<Audio>();
            for (int i = 0; i < SongList.Items.Count && i < MediaScanner.Audios.Count; i++)
            {
                if (SongList.Items[i].Name == MediaScanner.Audios[i].title)
                {
                    songsInLibrary.Add(MediaScanner.Audios[i]);
                }
            }
            return songsInLibrary;
        }

        /// <summary>
        /// Event listener for shuffle button click, 
        /// shuffles songs in library and gives it to MainForm to play them.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shuffleButton_Click(object sender, EventArgs e)
        {
            List<Audio> songCandidates = getSongs();
            WeightedShuffle(songCandidates, (a, b) 
                => JaroWinklerSimilarity(a.getArtists(), b.getArtists()));
            Queue = songCandidates;
            MainForm parent = (MainForm)this.MdiParent;
            parent.FillQueue(Queue);

        }

        /// <summary>
        /// Shuffles audios based on weight.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="weightFunc"></param>
        public static void WeightedShuffle<T>(IList<T> list, Func<T, T, double> weightFunc)
        {
            Random random = new Random();

            for (int i = list.Count - 1; i > 0; i--)
            {
                // Calculate the cumulative weight array
                List<double> cumulativeWeights = new List<double>();
                double totalWeight = 0;

                for (int j = 0; j <= i; j++)
                {
                    double weight = weightFunc(list[i], list[j]);
                    totalWeight += weight;
                    cumulativeWeights.Add(totalWeight);
                }

                // Pick a random number in the range [0, totalWeight)
                double randomWeight = random.NextDouble() * totalWeight;

                // Find the index of the first element in cumulativeWeights larger than randomWeight
                int selectedIndex = cumulativeWeights.FindIndex(w => w > randomWeight);

                // If the selectedIndex is not found, set it to the last index
                if (selectedIndex < 0)
                {
                    selectedIndex = i;
                }

                // Swap the selected element with the last element
                T temp = list[i];
                list[i] = list[selectedIndex];
                list[selectedIndex] = temp;
            }
        }

        /// <summary>
        /// Gives weights for two strings based on how similar they are for the WeightedShuffle.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
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
        /// Sets queue to the whole library from the begining and starts playing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playButton_Click(object sender, EventArgs e)
        {
            Queue = getSongs();
            MainForm parent = (MainForm)this.MdiParent;
            parent.FillQueue(Queue);
        }


    }
}
