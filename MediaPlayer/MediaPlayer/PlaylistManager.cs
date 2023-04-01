using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;

namespace MediaPlayer
{
    internal static class PlaylistManager
    {
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
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                serializer.WriteObject(fileStream, playlists);
            }
        }

        /// <summary>
        /// Reads the json file and sets the playlists list.
        /// </summary>
        public static void Read()
        {
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
}
