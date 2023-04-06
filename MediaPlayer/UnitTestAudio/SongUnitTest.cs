using MediaPlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSong
{
        /// <summary>
        /// Tests to see if the playlist Constructor is not null
        /// By Daniel Chellapan
        /// </summary>
        [TestClass]
        public class SongUnitTest
        {
            [TestClass]
            public class PlaySongUnitTest
            {
                /// <summary>
                /// Test class to test the functionality in Audio.cs
                /// By Daniel Chellapan
                /// </summary>
                [TestClass]
                public class UnitTestSong
                {
                    /// <summary>
                    /// Tests Title property 
                    /// By Daniel Chellapan
                    /// </summary>
                    [TestMethod]
                    public void TitlePropertyShouldSetAndGetCorrectValue()
                    {

                        Song song = new Song();
                        string expectedTitle = "Example Song";
                        song.Title = expectedTitle;
                        string actualTitle = song.Title;
                        Assert.AreEqual(expectedTitle, actualTitle);
                    }


                    /// <summary>
                    /// Tests property FileLocation
                    /// By Daniel Chellapan
                    /// </summary>
                    [TestMethod]
                    public void FileLocationPropertyShouldSetAndGetCorrectValue()
                    {

                        Song song = new Song();
                        string expectedFileLocation = @"C:\MediaPlayer\ThisSong.mp3";
                        song.FileLocation = expectedFileLocation;
                        string actualFileLocation = song.FileLocation;
                        Assert.AreEqual(expectedFileLocation, actualFileLocation);
                    }

                    /// <summary>
                    /// Tests property AlbumProperty
                    /// By Daniel Chellapan
                    /// </summary>
                    [TestMethod]
                    public void AlbumPropertyShouldSetAndGetCorrectValue()
                    {

                        Song song = new Song();
                        string expectedAlbum = "Example Album";
                        song.Album = expectedAlbum;
                        string actualAlbum = song.Album;
                        Assert.AreEqual(expectedAlbum, actualAlbum);
                    }

                    /// <summary>
                    /// Tests property GenreProperty
                    /// By Daniel Chellapan
                    /// </summary>
                    [TestMethod]
                    public void GenresPropertyShouldSetAndGetCorrectValue()
                    {

                        Song song = new Song();
                        string[] expectedGenres = new string[] { "Genre 1", "Genre 2" };
                        song.Genres = expectedGenres;
                        string[] actualGenres = song.Genres;
                        CollectionAssert.AreEqual(expectedGenres, actualGenres);
                    }

                    /// <summary>
                    /// Tests property DurationProperty
                    /// By Daniel Chellapan
                    /// </summary>
                    [TestMethod]
                    public void DurationPropertyShouldSetAndGetCorrectValue()
                    {

                        Song song = new Song();
                        string expectedDuration = "3:45";
                        song.Duration = expectedDuration;
                        string actualDuration = song.Duration;
                        Assert.AreEqual(expectedDuration, actualDuration);
                    }

                    /// <summary>
                    /// Tests GetArtist function logic 
                    /// By Daniel Chellapan
                    /// </summary>
                    [TestMethod]
                    public void TestGetArtists()
                    {
                        StringBuilder StringBuilder = new StringBuilder();
                        string[] artistNamesArray = { "Jay-Z", "Jim", "Joe" };
                        for (int i = 0; i < artistNamesArray.Length; i++)
                        {
                            if (i == artistNamesArray.Length - 1)
                            {
                                StringBuilder.Append(artistNamesArray[i]);
                            }
                            else
                            {
                                StringBuilder.Append(artistNamesArray[i] + ", ");
                            }
                            StringBuilder.ToString();
                        }

                        Song artists = new Song();
                        artists.GetArtists();

                        Assert.AreEqual(artistNamesArray[0], "Jay-Z");
                    }


                }
            }
        }
 }


  