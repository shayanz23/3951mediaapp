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

        /// <summary>
        /// Title property.
        /// </summary>
        public override string title { get; set; }

        /// <summary>
        /// File location property.
        /// </summary>
        public override string fileLocation { get; set; }

        /// <summary>
        /// Image resolution property.
        /// </summary>
        public Size resolution { get; set; }

        /// <summary>
        /// Date property.
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// description property.
        /// </summary>
        public string description { get; set; }
    }
}
