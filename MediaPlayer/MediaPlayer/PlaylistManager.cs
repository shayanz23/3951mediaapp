using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace MediaPlayer
{
    internal static class PlaylistManager
    {

        /// <summary>
        /// List of the playlists.
        /// </summary>
        private static List<Playlist> playlists = new List<Playlist>();

        /// <summary>
        /// Path to the json file.
        /// </summary>
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/playlists.json";

        /// <summary>
        /// List of playlists the user has created.
        /// </summary>
        public static List<Playlist> Playlists { get { return playlists; } }

        /// <summary>
        /// Saves the playlists and their contents to a json file in the music directory.
        /// </summary>
        public static void Save()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Playlist>));
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    serializer.WriteObject(fileStream, playlists);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reads the json file and sets the playlists list.
        /// </summary>
        public static void Read()
        {
            //Instance of class for comparing the title of songsNext
            SongTitleEqualityComparer titleComparer = new SongTitleEqualityComparer();
            //boolean for deciding whether to save json or not.
            bool removed = false;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Playlist>));
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    List<Playlist> deserializedList = (List<Playlist>)serializer.ReadObject(fileStream);
                    playlists = deserializedList;
                }
            } catch
            {
                Save();
            }

            //Checks if songsNext exist in the library, if not they are removed.
            for (int i = 0; i < playlists.Count; i++)
            {
                int originalCount = playlists[i].Songs.Count;
                List<Song> filteredSongs = playlists[i].Songs
                    .Where(song => SongManager.Songs.Any(s => s.Title == song.Title)) // Compare songsNext by title or any unique property
                    .ToList();

                if (originalCount != filteredSongs.Count)
                {
                    removed = true;
                    playlists[i].Songs = filteredSongs;
                }
            }

            //Checks if there are duplicate songsNext and removes them.
            for (int i = 0; i < playlists.Count; i++)
            {
                int originalCount = playlists[i].Songs.Count;
                List<Song> distinctSongs = playlists[i].Songs.Distinct(titleComparer).ToList();

                if (originalCount != distinctSongs.Count)
                {
                    removed = true;
                    playlists[i].Songs = distinctSongs;
                }
            }
            if (removed) { 
                Save();
            }
        }

        /// <summary>
        /// Removes a playlist based on the name.
        /// </summary>
        /// <param name="name"></param>
        public static void RemovePlaylist(string name)
        {
            foreach (Playlist playlist in playlists)
            {
                if (name == playlist.Name)
                {
                    playlists.Remove(playlist);
                    return;
                }
            }
        }

        /// <summary>
        /// Adds a playlists to playlists.
        /// </summary>
        /// <param name="playlist"> playlist to be added.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddPlaylist(Playlist playlist)
        {
            if (playlist == null) throw new ArgumentNullException();
            if (playlist.Name == null || playlist.Name.Trim() == "")
            {
                MessageBox.Show("playlist cannot have no or empty name", "no name", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Playlist playlist1 in playlists)
            {
                if (playlist1.Name == playlist.Name)
                {
                    MessageBox.Show("playlist cannot have the same name", "no name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            playlists.Add(playlist);
        }
    }

    /// <summary>
    /// Title comparator class for the songsNext.
    /// </summary>
    internal class SongTitleEqualityComparer : IEqualityComparer<Song>
    {
        public bool Equals(Song x, Song y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Title == y.Title;
        }

        public int GetHashCode(Song obj)
        {
            return obj.Title != null ? obj.Title.GetHashCode() : 0;
        }
    }

}
