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
    public static class SongScanner
    {

        //Lists for each type of content
        private static List<Audio> _audios = new List<Audio>();

        //accepted file types
        private static string[] audioTypes = { ".mp3", ".wav", ".flac", ".m4a", ".ogg" };

        //library paths
        private static string audioPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        

        //properties for the Lists.
        public static List<Audio> Audios
        {
            get { return _audios; }
            set { _audios = value; }
        }

        /// <summary>
        /// Scans for audio files in the Music folder, gets their metadata, like album art, artists, Album, and duration,
        /// then creates a new Audio object and adds it to the static Audios List.
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
                    Audio audio = new Audio();
                    audio.fileLocation = filePath;
                    try
                    {
                        using (var audioFileReader = new NAudio.Wave.AudioFileReader(filePath))
                        {
                            var audioFileLength = audioFileReader.TotalTime.TotalSeconds;
                            TimeSpan timeSpan = TimeSpan.FromSeconds(audioFileLength);
                            audio.duration = timeSpan.ToString(@"mm\:ss");
                        }
                    } 
                    catch {
                        audio.duration = "Unknown";
                    }

                    if (file != null)
                    {
                        audio.title = file.Tag.Title;
                        audio.genres = file.Tag.Genres;
                        audio.album = file.Tag.Album;
                        audio.artists = file.Tag.Performers;
                        audio.albumArt = getCoverArt(file);
                    }
                    if (audio.title == null) {
                        audio.title = Path.GetFileName(filePath);
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
            for (int i = 0; i < Audios.Count; i++)
            {
                for (int j = i + 1; j < Audios.Count; j++)
                {
                    if (Audios[i].title == Audios[j].title)
                    {
                        duplicateCounter++;
                        Audios[j].title = Audios[j].title + " " + duplicateCounter;
                    }
                }
            }
        }

        /// <summary>
        /// Helper method for the scanAudios that gets an Image object from file's album art metadata.
        /// By Shayan Zahedanaraki
        /// </summary>
        /// <param name="file"></param>
        /// <returns>returns the image object.</returns>
        public static Image getCoverArt(File file)
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
    }
}
