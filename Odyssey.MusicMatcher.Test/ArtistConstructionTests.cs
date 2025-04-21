namespace Odyssey.MusicMatcher.Test;

[TestClass]
public class ArtistConstructionTests
{
    [TestMethod]
    public void ArtistIdAndName_AreSetByConstructor()
    {
        // Arrange
        var id = "123";
        var name = "Test Artist";

        // Act
        var artist = new Artist(id, name);

        // Assert
        Assert.AreEqual(id, artist.Id);
        Assert.AreEqual(name, artist.Name);
    }
}