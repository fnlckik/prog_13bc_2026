using DC_Plus.Models;

namespace DCPlus.Tests;

public class SeriesTests
{
    private Series series;
    private Episode ep1, ep2, ep3;

    [SetUp]
    public void Setup()
    {
        series = new(id: 2,
                     title: "Pókember",
                     description: "Klasszikus pókember sorozat",
                     genre: "sci-fi",
                     releaseYear: 1994,
                     ageLimit: 12,
                     duration: 21,
                     creator: "Stan Lee",
                     isOngoing: false);
        ep1 = new(id: 1,
                  seriesId: 2,
                  title: "A gyík éjszakája (1. rész)",
                  season: 1,
                  episodeNumber: 1,
                  duration: 21,
                  releaseDate: new DateTime(1994, 11, 19));
        ep2 = new(id: 2,
                  seriesId: 2,
                  title: "A Skorpió csípése",
                  season: 1,
                  episodeNumber: 6,
                  duration: 20,
                  releaseDate: new DateTime(1995, 3, 11));
        ep3 = new(id: 3,
                  seriesId: 2,
                  title: "Az Igazságosztó közbelép",
                  season: 2,
                  episodeNumber: 7,
                  duration: 23,
                  releaseDate: new DateTime(1995, 11, 4));
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
