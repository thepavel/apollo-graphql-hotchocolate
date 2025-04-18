using System.Threading.Tasks;
using SpotifyWeb;

namespace Odyssey.MusicMatcher;

[GraphQLDescription("An API that delivers music information including artists, albums, and playlists")]
public class Query
{
    [GraphQLDescription("Retrieves a specific playlist.")]
    public async Task<Playlist?> GetPlaylist([ID] string id, SpotifyService spotifyService)
    {
        var response = await spotifyService.GetPlaylistAsync(id);
        var playlist = new Playlist(response);
        return playlist;

    }

    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public async Task<List<Playlist>> FeaturedPlaylists(SpotifyService spotifyService)
    {
        var response = await spotifyService.GetFeaturedPlaylistsAsync();
        var items = response.Playlists.Items;
        var playlists = items.Select(p => new Playlist(p)).ToList();
        return [.. playlists];

    }
}

