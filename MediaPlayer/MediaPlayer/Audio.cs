using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public class Audio : Media
    {
        public override string title { get; set; }

        public override string fileLocation { get; set; }

        public string album { get; set; }

        public string[] artists { get; set; }

        public string[] genres { get; set; }

        public string duration { get; set; }

        public Image coverArt { get; set; }

    }
}
