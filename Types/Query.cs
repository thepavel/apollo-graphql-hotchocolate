namespace Odyssey.MusicMatcher;

[GraphQLDescription("An API that delivers music information including artists, albums, and playlists")]
public class Query
{
    [GraphQLDescription("Playlists hand-picked to be featured to all users.")]
    public List<Playlist> FeaturedPlaylists()
    {
        return
       [
           new Playlist("1", "GraphQL Groovin'"),
           new Playlist("2", "Graph Explorer Jams"),
           new Playlist("3", "Interpretive GraphQL Dance")
       ];
    }
}

