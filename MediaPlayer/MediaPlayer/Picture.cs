using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public class Picture : Media
    {
        public override string title { get; set; }

        public override string fileLocation { get; set; }

        public Size resolution { get; set; }

        public DateTime date { get; set; }

        public string description { get; set; }
    }
}
