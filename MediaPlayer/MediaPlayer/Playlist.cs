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

        public Playlist(string name)
        {
            Name = name;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Audio> Songs { get; set; }
    }
}
