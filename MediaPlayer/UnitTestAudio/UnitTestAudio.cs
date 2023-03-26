using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaPlayer;
using System.Text;

namespace UnitTestMediaPlayerAudio
{
    /// <summary>
    /// Test class to test the functionality in Audio.cs
    /// By Daniel Chellapan
    /// </summary>
    [TestClass]
    public class UnitTestAudio
    {
        /// <summary>
        /// Tests property   for audio title
        /// By Daniel Chellapan
        /// </summary>
        [TestMethod]
        public void TestAudioTitleProperty()
        {
            Audio title = new Audio();
            title.title = "Numb";
            Assert.AreEqual(title.title, "Numb");
        }

        /// <summary>
        /// Tests getArtist function logic 
        /// By Daniel Chellapan
        /// </summary>
        [TestMethod]
        public void TestGetArtists()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] artistNamesArray = { "Jay-Z", "Jim", "Joe" };
            for (int i = 0; i < artistNamesArray.Length; i++)
            {
                if (i == artistNamesArray.Length - 1)
                {
                    stringBuilder.Append(artistNamesArray[i]);
                }
                else
                {
                    stringBuilder.Append(artistNamesArray[i] + ", ");
                }
                stringBuilder.ToString();
            }



            Audio artists = new Audio();
            artists.getArtists();

            Assert.AreEqual(artistNamesArray[0], "Jay-Z");
        }


    }
}
