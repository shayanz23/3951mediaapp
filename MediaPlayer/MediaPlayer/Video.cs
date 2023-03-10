using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public class Video : Media
    {

        /// <summary>
        /// Title property.
        /// </summary>
        public override string title { get; set; }

        /// <summary>
        /// File location property.
        /// </summary>
        public override string fileLocation { get; set; }

        /// <summary>
        /// Category property.
        /// </summary>
        public string[] categories { get; set; }

        /// <summary>
        /// Director property.
        /// </summary>
        public string director { get; set; }

        /// <summary>
        /// duration property.
        /// </summary>
        public string duration { get; set; }

        /// <summary>
        /// description property.
        /// </summary>
        public string description { get; set; }
    }
}
