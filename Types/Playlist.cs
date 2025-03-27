namespace Odyssey.MusicMatcher;

public class Playlist
{
    [ID]
    public string Id { get; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public Playlist(string id, string name)
    {
        Id = id;
        Name = name;
    }
}
