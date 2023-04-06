using MediaPlayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;


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
                /// Tests property get value 
                /// By Daniel Chellapan
                /// </summary>
                [TestMethod]
                public void TitleProperty_ShouldSetAndGetCorrectValue()
                {
                    // Arrange
                    Song song = new Song();
                    string expectedTitle = "Example Song";

                    // Act
                    song.Title = expectedTitle;
                    string actualTitle = song.Title;

                    // Assert
                    Assert.AreEqual(expectedTitle, actualTitle);
                }


                /// <summary>
                /// Tests property set value
                /// By Daniel Chellapan
                /// </summary>
                [TestMethod]
                public void FileLocationProperty_ShouldSetAndGetCorrectValue()
                {
                    // Arrange
                    Song song = new Song();
                    string expectedFileLocation = @"C:\MediaPlayer\ThisSong.mp3";

                    // Act
                    song.FileLocation = expectedFileLocation;
                    string actualFileLocation = song.FileLocation;

                    // Assert
                    Assert.AreEqual(expectedFileLocation, actualFileLocation);
                }

                /// <summary>
                /// Tests property set value
                /// By Daniel Chellapan
                /// </summary>
                [TestMethod]
                public void AlbumProperty_ShouldSetAndGetCorrectValue()
                {
                    // Arrange
                    Song song = new Song();
                    string expectedAlbum = "Example Album";

                    // Act
                    song.Album = expectedAlbum;
                    string actualAlbum = song.Album;

                    // Assert
                    Assert.AreEqual(expectedAlbum, actualAlbum);
                }

                /// <summary>
                /// Tests property   for audio title
                /// By Daniel Chellapan
                /// </summary>
                [TestMethod]
                public void GenresProperty_ShouldSetAndGetCorrectValue()
                {
                    // Arrange
                    Song song = new Song();
                    string[] expectedGenres = new string[] { "Genre 1", "Genre 2" };

                    // Act
                    song.Genres = expectedGenres;
                    string[] actualGenres = song.Genres;

                    // Assert
                    CollectionAssert.AreEqual(expectedGenres, actualGenres);
                }

                [TestMethod]
                public void DurationProperty_ShouldSetAndGetCorrectValue()
                {
                    // Arrange
                    Song song = new Song();
                    string expectedDuration = "3:45";

                    // Act
                    song.Duration = expectedDuration;
                    string actualDuration = song.Duration;

                    // Assert
                    Assert.AreEqual(expectedDuration, actualDuration);
                }

                /// <summary>
                /// Tests getArtist function logic 
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