using MediaPlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPlayList
{//add more stuff again

    /// <summary>
    /// Tests to see if the playlist Constructor is not null
    /// By Daniel Chellapan
    /// </summary>
    [TestClass]
    public class PlayListUnitTest
    {
        /// <summary>
        /// Tests to see if the playlist Constructor is not null
        /// By Daniel Chellapan
        /// </summary>
        [TestMethod]
        public void TestConstructorNotNull()
        {
            string name = "My Playlist";
            Playlist playlist = new Playlist(name);
            Assert.IsNotNull(playlist.Songs);

        }

        /// <summary>
        /// Tests to see if the playlist 
        /// By Daniel Chellapan
        /// </summary>
        [TestMethod]
        public void TestConstructorCodeLengthMakesSense()
        {
            string name = "My Playlist";
            Playlist playlist = new Playlist(name);
            Assert.AreEqual(0, playlist.Songs.Count);
        }


        /// <summary>
        /// Tests getArtist function logic 
        /// By Daniel Chellapan
        /// </summary>
        [TestMethod]
        public void TestConstructorNameMakesSense()
        {
            string name = "My Playlist";
            Playlist playlist = new Playlist(name);

            Assert.AreEqual(name, playlist.Name);
        }
    }
}
