using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SpotifyWeb;

namespace Odyssey.MusicMatcher.Tests;

[TestClass]
public class PlaylistTest
{
    
    [TestMethod]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var id = "test-id";
        var name = "test-name";

        // Act
        var playlist = new Playlist(id, name);

        // Assert
        Assert.AreEqual(id, playlist.Id);
        Assert.AreEqual(name, playlist.Name);
        Assert.IsNull(playlist.Description);
    
    }

    [TestMethod]
    public void PlaylistSimplifiedConstructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var id = "test-id";
        var name = "test-name";
        var description = "test-description";

        // Act
        var playlistSimplified = new Playlist(new PlaylistSimplified
        {
            Id = id,
            Name = name,
            Description = description
        });

        // Assert
        Assert.AreEqual(id, playlistSimplified.Id);
        Assert.AreEqual(name, playlistSimplified.Name);
        Assert.AreEqual(description, playlistSimplified.Description);
    }

    [TestMethod]
    public void PlaylistConstructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var id = "test-id";
        var name = "test-name";
        var description = "test-description";
        

        // Act
        var playlist = new Playlist(new SpotifyWeb.Playlist
        {
            Id = id,
            Name = name,
            Description = description,
            
        });

        // Assert
        Assert.AreEqual(id, playlist.Id);
        Assert.AreEqual(name, playlist.Name);
        Assert.AreEqual(description, playlist.Description);
    }


#region SpotifyServiceTests
        
        [TestMethod]
        public async Task Tracks_FetchesTracksFromSpotifyService()
        {
            // Arrange
            var id = "test-id";
            var mockSpotifyService = new Mock<SpotifyService>();
            var mockTracks = new List<PlaylistTrackItem>
            {
                new PlaylistTrackItem { Id = "track1" },
                new PlaylistTrackItem { Id = "track2" }
            };
            mockSpotifyService
                .Setup(s => s.GetPlaylistsTracksAsync(id))
                .ReturnsAsync(new SpotifyWeb.PaginatedOfPlaylistTrack
                {
                    Items =
                    [
                        new SpotifyWeb.PlaylistTrack { Track = mockTracks[0] },
                        new SpotifyWeb.PlaylistTrack { Track = mockTracks[1] }
                    ]
                     //mockTracks.Select(t => t.Id == "track1" ? new SpotifyWeb.PlaylistTrack { Track = t } : null).ToList()
                });
    
    
            var playlist = new Playlist(id, "test-name");
    
            // Act
            var tracks = await playlist.Tracks(mockSpotifyService.Object);
    
            // Assert
            Assert.IsNotNull(tracks);
            Assert.AreEqual(2, tracks.Count);
            Assert.AreEqual("track1", tracks[0].Id);
            Assert.AreEqual("track2", tracks[1].Id);
    
            // Verify caching
            mockSpotifyService.Verify(s => s.GetPlaylistsTracksAsync(id), Times.Once);
            var cachedTracks = await playlist.Tracks(mockSpotifyService.Object);
            Assert.AreEqual(tracks, cachedTracks);
        }
    
        [TestMethod]
        public async Task Tracks_HandlesEmptyResponse()
        {
            // Arrange
            var id = "test-id";
            
            var mockSpotifyService = new Mock<SpotifyService>();
            mockSpotifyService
                .Setup(s => s.GetPlaylistsTracksAsync(id))
                .ReturnsAsync(new SpotifyWeb.PaginatedOfPlaylistTrack
                {
                    Items = new List<SpotifyWeb.PlaylistTrack>()
                });
                //.ReturnsAsync(new SpotifyWeb.PaginatedOfPlaylistTrack { Items = new List<SpotifyWeb.PlaylistTrack>() });
    
            var playlist = new Playlist(id, "test-name");
    
            // Act
            var tracks = await playlist.Tracks(mockSpotifyService.Object);
    
            // Assert
            Assert.IsNotNull(tracks);
            Assert.IsTrue(tracks.Count == 0);
        }
    
        // [TestMethod]
        // public async Task Tracks_CachesResults()
        // {
        //     // Arrange
        //     var id = "test-id";
        //     var mockSpotifyService = new Mock<SpotifyService>();
        //     var mockTracks = new List<SpotifyWeb.Track>
        //     {
        //         new SpotifyWeb.Track { Id = "track1" }
        //     };
        //     mockSpotifyService
        //         .Setup(s => s.GetPlaylistsTracksAsync(id))
        //         .ReturnsAsync(new SpotifyWeb.PlaylistTracksResponse
        //         {
        //             Items = mockTracks.Select(t => new SpotifyWeb.PlaylistTrack { Track = t }).ToList()
        //         });
    
        //     var playlist = new Playlist(id, "test-name");
    
        //     // Act
        //     var firstCallTracks = await playlist.Tracks(mockSpotifyService.Object);
        //     var secondCallTracks = await playlist.Tracks(mockSpotifyService.Object);
    
        //     // Assert
        //     Assert.AreEqual(firstCallTracks, secondCallTracks);
        //     mockSpotifyService.Verify(s => s.GetPlaylistsTracksAsync(id), Times.Once);
        // }
#endregion
}