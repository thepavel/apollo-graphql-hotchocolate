namespace Odyssey.MusicMatcher;

public class Query
{
    public string Hello()
    {
        return "Hello world";
    }

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

