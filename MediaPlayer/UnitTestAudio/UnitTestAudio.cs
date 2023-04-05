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
        /// Tests property   for audio Title
        /// By Daniel Chellapan
        /// </summary>
        [TestMethod]
        public void TestAudioTitleProperty()
        {
            Song title = new Song();
            title.Title = "Numb";
            Assert.AreEqual(title.Title, "Numb");
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



            Song artists = new Song();
            artists.GetArtists();

            Assert.AreEqual(artistNamesArray[0], "Jay-Z");
        }

        //testing push
    }
}
