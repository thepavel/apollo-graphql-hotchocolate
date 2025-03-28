namespace Odyssey.MusicMatcher;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or emotion")]
public class Playlist(string id, string name)
{
    [GraphQLDescription("Unique identifier for the playlist")]
    [ID]
    public string Id { get; } = id;

    [GraphQLDescription("The name of the playlist")]
    public string Name { get; set; } = name;

    [GraphQLDescription("Describes what the listener should expect")]
    public string? Description { get; set; }
}
