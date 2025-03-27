namespace Odyssey.MusicMatcher;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or emotion")]
public class Playlist
{
    [GraphQLDescription("Unique identifier for the playlist")]
    [ID]
    public string Id { get; }

    [GraphQLDescription("The name of the playlist")]
    public string Name { get; set; }
    
    [GraphQLDescription("Describes what the listener should expect")]
    public string? Description { get; set; }

    public Playlist(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
