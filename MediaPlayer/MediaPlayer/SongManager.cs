using System.Collections;
using TagLib;
using File = TagLib.File;
using NAudio;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace MediaPlayer
{

    /// <summary>
    /// The static class that scans the media directories (music, videos, pictures) for audio, video, and pictures.
    /// </summary>
    public static class SongManager
    {

        //Lists for each type of content
        private static List<Song> _audios = new List<Song>();

        //accepted file types
        private static string[] audioTypes = { ".mp3", ".wav", ".flac", ".m4a", ".ogg" };

        //library paths
        private static string audioPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        

        //properties for the Lists.
        public static List<Song> Songs
        {
            get { return _audios; }
            set { _audios = value; }
        }

        /// <summary>
        /// Scans for audio files in the Music folder, gets their metadata, like Album art, Artists, Album, and Duration,
        /// then creates a new Audio object and adds it to the static Songs List.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <returns>success or fail bool</returns>
        public static bool Scan()
        {
            try
            {
                string[] files = Directory.GetFiles(audioPath, "*.*", SearchOption.AllDirectories)
                                 .Where(file => audioTypes.Contains(Path.GetExtension(file)))
                                 .ToArray();
                foreach (string filePath in files)
                {
                    File file = null;
                    try
                    {
                        file = File.Create(filePath);
                    }
                    catch (Exception)
                    {
                        file = null;
                    }
                    Song audio = new Song();
                    audio.FileLocation = filePath;
                    try
                    {
                        using (var audioFileReader = new NAudio.Wave.AudioFileReader(filePath))
                        {
                            var audioFileLength = audioFileReader.TotalTime.TotalSeconds;
                            TimeSpan timeSpan = TimeSpan.FromSeconds(audioFileLength);
                            audio.Duration = timeSpan.ToString(@"mm\:ss");
                        }
                    } 
                    catch {
                        audio.Duration = "Unknown";
                    }

                    if (file != null)
                    {
                        audio.Title = file.Tag.Title;
                        audio.Genres = file.Tag.Genres;
                        audio.Album = file.Tag.Album;
                        audio.Artists = file.Tag.Performers;
                    }
                    if (audio.Title == null) {
                        audio.Title = Path.GetFileName(filePath);
                    }
                    _audios.Add(audio);
                }
                checkDuplicates();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Checks if there are songs with the same titles, and changes the duplicate titles.
        /// By Shayan Zahedanaraki
        /// </summary>
        private static void checkDuplicates()
        {
            int duplicateCounter = 1;
            for (int i = 0; i < Songs.Count; i++)
            {
                for (int j = i + 1; j < Songs.Count; j++)
                {
                    if (Songs[i].Title == Songs[j].Title)
                    {
                        duplicateCounter++;
                        Songs[j].Title = Songs[j].Title + " " + duplicateCounter;
                    }
                }
            }
        }

        /// <summary>
        /// Helper method for the scanAudios that gets an Image object from file's Album art metadata.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="file"></param>
        /// <returns>returns the image object.</returns>
        public static Image getCoverArt(string filePath)
        {
            File file = null;
            try
            {
                file = File.Create(filePath);
            }
            catch (Exception)
            {
                file = null;
            }
            if (file != null)
            {
                IPicture pic = file.Tag.Pictures.Length > 0 ? file.Tag.Pictures[0] : null;
                if (pic != null)
                {
                    // Convert the picture data to an Image object
                    MemoryStream ms = new MemoryStream(pic.Data.Data);
                    Image image = Image.FromStream(ms);
                    return image;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
