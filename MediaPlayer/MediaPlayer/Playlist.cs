using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        /// List of songs in playlist.
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
