using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestPlayList
{
    [TestClass]
    public class UnitTest1
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
