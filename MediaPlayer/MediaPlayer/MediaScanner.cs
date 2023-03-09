using Microsoft.VisualBasic.Devices;
using System.Collections;
using TagLib;
using File = TagLib.File;
using NAudio;

namespace MediaPlayer
{
    public static class MediaScanner
    {
        private static List<Audio> _audios = new List<Audio>();
        private static List<Video> _videos = new List<Video>();
        private static List<Picture> _pictures = new List<Picture>();

        private static string[] audioTypes = { ".mp3", ".wav", ".flac", ".m4a", ".ogg" };
        private static string[] videoTypes = { ".mp4", ".mkv", ".mov" };
        private static string[] pictureTypes = { ".jpg", ".gif", ".png" };

        private static string audioPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        private static string videoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        private static string picturePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        


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
        /// Scans for 
        /// </summary>
        /// <returns></returns>
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
                    using (var audioFileReader = new NAudio.Wave.AudioFileReader(filePath))
                    {
                        var audioFileLength = audioFileReader.TotalTime.TotalSeconds;
                        TimeSpan timeSpan = TimeSpan.FromSeconds(audioFileLength);
                        audio.duration = timeSpan.ToString(@"mm\:ss");
                    }
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
                        video.genres = file.Tag.Genres;
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


        public static bool scanAll()
        {
            bool audioScan = scanAudio();
            bool videoScan = scanVideo();
            bool pictureScan = scanPicture();
            return (audioScan && videoScan && pictureScan) ? true : false;
        }

        public static Image getCoverArt(File file)
        {
            IPicture? pic = file.Tag.Pictures.Length > 0 ? file.Tag.Pictures[0] : null;
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
