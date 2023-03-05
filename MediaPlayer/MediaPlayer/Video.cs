using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public class Video : Media
    {
        public override string title { get; set; }

        public override string fileLocation { get; set; }

        public string[] genres { get; set; }

        public string director { get; set; }

        public string duration { get; set; }

        public string description { get; set; }
    }
}
