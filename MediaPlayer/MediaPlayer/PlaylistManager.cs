using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Windows.Forms;

namespace MediaPlayer
{
    internal static class PlaylistManager
    {
        private static List<Playlist> playlists = new List<Playlist>();

        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/playlists.json";

        public static List<Playlist> Playlists { get { return playlists; } }

        public static void Save()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Playlist>));
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                serializer.WriteObject(fileStream, playlists);
            }
        }

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
                Read();
            }
        }



        public static void AddPlaylist(Playlist playlist)
        {
            if (playlist == null) throw new ArgumentNullException();
            if (playlist.Name == null || playlist.Name.Trim() == "")
            {
                throw new Exception("playlist Name cannot be empty");
            }
            foreach (Playlist playlist1 in playlists)
            {
                if (playlist1.Name == playlist.Name)
                {
                    return;
                }
            }
            playlists.Add(playlist);
        }
    }
}
