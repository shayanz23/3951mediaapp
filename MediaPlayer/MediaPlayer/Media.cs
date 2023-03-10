using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public abstract class Media
    {

        /// <summary>
        ///  Abstract Title property.
        /// </summary>
        public abstract string title { get; set; }

        /// <summary>
        /// File location sbstract property.
        /// </summary>
        public abstract string fileLocation { get; set; }
    }
}
