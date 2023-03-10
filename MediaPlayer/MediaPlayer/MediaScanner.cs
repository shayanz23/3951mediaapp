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
    public static class MediaScanner
    {

        //Lists for each type of content
        private static List<Audio> _audios = new List<Audio>();
        private static List<Video> _videos = new List<Video>();
        private static List<Picture> _pictures = new List<Picture>();

        //accepted file types
        private static string[] audioTypes = { ".mp3", ".wav", ".flac", ".m4a", ".ogg" };
        private static string[] videoTypes = { ".mp4", ".mkv", ".mov" };
        private static string[] pictureTypes = { ".jpg", ".gif", ".png" };

        //library paths
        private static string audioPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        private static string videoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        private static string picturePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        

        //properties for the Lists.
        public static List<Audio> Audios
        {
            get { return _audios; }
            set { _audios = value; }
        }

        public static List<Video> Videos
        {
            get { return _videos; }
            set { _videos = value; }
        }

        public static List<Picture> Pictures
        {
            get { return _pictures; }
            set { _pictures = value; }
        }

        /// <summary>
        /// Scans for audio files in the Music folder, gets their metadata, like album art, artists, Album, and duration,
        /// then creates a new Audio object and adds it to the static Audios List.
        /// </summary>
        /// <returns>success or fail bool</returns>
        public static bool scanAudio()
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
                    } catch (Exception ex)
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
                    catch { }

                    if (file != null)
                    {
                        audio.title = file.Tag.Title;
                        audio.genres = file.Tag.Genres;
                        audio.album = file.Tag.Album;
                        audio.artists = file.Tag.Performers;
                        audio.coverArt = getCoverArt(file);
                    }
                    if (audio.title == null) {
                        audio.title = Path.GetFileName(filePath);
                    }
                    _audios.Add(audio);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Scans for video files in the Videos folder, gets their metadata, like description, title, genres, and duration,
        /// then creates a new Audio object and adds it to the static Audios List.
        /// </summary>
        /// <returns>success or fail bool</returns>
        public static bool scanVideo()
        {
            try
            {
                string[] files = Directory.GetFiles(videoPath, "*.*", SearchOption.AllDirectories)
                                 .Where(file => videoTypes.Contains(Path.GetExtension(file)))
                                 .ToArray();
                foreach (string filePath in files)
                {
                    File file = null;
                    try
                    {
                        file = File.Create(filePath);
                    }
                    catch (Exception ex)
                    {
                        file = null;
                    }
                    Video video = new Video();
                    video.fileLocation = filePath;
                    if (file != null)
                    {
                        video.description = file.Tag.Description;
                        video.title = file.Tag.Title;
                        video.duration = file.Tag.Length;
                        video.categories = file.Tag.Genres;
                    }
                    if (video.title == null)
                    {
                        video.title = Path.GetFileName(filePath);
                    }
                    _videos.Add(video);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Scans for image files in the Pictures folder, gets their metadata, like tag date, artists, Album, and duration,
        /// then creates a new Audio object and adds it to the static Audios List.
        /// </summary>
        /// <returns>success or fail bool</returns>
        public static bool scanPicture()
        {
            try
            {
                string[] files = Directory.GetFiles(picturePath, "*.*", SearchOption.AllDirectories)
                                 .Where(file => pictureTypes.Contains(Path.GetExtension(file)))
                                 .ToArray();
                foreach (string filePath in files)
                {
                    File file = null;
                    try
                    {
                        file = File.Create(filePath);
                    }
                    catch (Exception ex)
                    {
                        file = null;
                    }
                    Picture picture = new Picture();
                    picture.fileLocation = filePath;
                    if (file != null)
                    {
                        picture.description = file.Tag.Description;
                        picture.title = file.Tag.Title;
                        if (file.Tag.DateTagged != null) picture.date = (DateTime)file.Tag.DateTagged;
                    }
                    if (picture.title == null)
                    {
                        picture.title = Path.GetFileName(filePath);
                    }
                    _pictures.Add(picture);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Runs the three scanner methods.
        /// </summary>
        /// <returns>returns whether all three were successful.</returns>
        public static bool scanAll()
        {
            bool audioScan = scanAudio();
            bool videoScan = scanVideo();
            bool pictureScan = scanPicture();
            return (audioScan && videoScan && pictureScan) ? true : false;
        }

        /// <summary>
        /// Helper method for the scanAudios that gets an Image object from file's album art metadata.
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
