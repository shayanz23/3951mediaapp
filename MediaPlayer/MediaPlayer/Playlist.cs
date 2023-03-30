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

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Audio> Songs { get; set; }

        public Playlist(string name)
        {
            Name = name;
            Songs = new List<Audio>();
        }
    }
}
