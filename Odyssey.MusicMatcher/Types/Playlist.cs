using SpotifyWeb;

namespace Odyssey.MusicMatcher;

[GraphQLDescription("A curated collection of tracks designed for a specific activity or emotion")]
public class Playlist
{

    public Playlist(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public Playlist(SpotifyWeb.Playlist obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;

    }

    public Playlist(PlaylistSimplified obj)
    {
        Id = obj.Id;
        Name = obj.Name;
        Description = obj.Description;
    }

    [GraphQLDescription("Unique identifier for the playlist")]
    [ID]
    public string Id { get; }

    [GraphQLDescription("The name of the playlist")]
    public string Name { get; set; }

    [GraphQLDescription("Describes what the listener should expect")]
    public string? Description { get; set; }

}
