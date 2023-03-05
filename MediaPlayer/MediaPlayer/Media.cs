using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer
{
    public abstract class Media
    {
        public abstract string title { get; set; }
        public abstract string fileLocation { get; set; }
    }
}
