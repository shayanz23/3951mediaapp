using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MediaPlayer
{

    [DataContract]
    public class Playlist
    {

        /// <summary>
        /// PLaylist name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// List of songsNext in playlist.
        /// </summary>
        [DataMember]
        public List<Song> Songs { get; set; }

        /// <summary>
        /// Constructor for playlist.
        /// </summary>
        /// <param name="name"></param>
        public Playlist(string name)
        {
            Name = name;
            Songs = new List<Song>();
        }
    }
}
