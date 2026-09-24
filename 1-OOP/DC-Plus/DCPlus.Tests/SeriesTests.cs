using DC_Plus.Exceptions; // InvalidEpisodeException
using DC_Plus.Models; // Series, Episode

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
                  episodeNumber: 1,
                  duration: 23,
                  releaseDate: new DateTime(1995, 11, 4));
    }

    [Test]
    public void AddEpisode_OneEpisode()
    {
        series.AddEpisode(ep1);
        //Assert.That(series.Episodes.Count, Is.EqualTo(1));
        Assert.That(series.Episodes, Has.Count.EqualTo(1));
        Assert.That(series.Episodes[0], Is.EqualTo(ep1));
    }

    [Test]
    public void AddEpisode_MultipleEpisodes()
    {
        series.AddEpisode(ep1); // 1. évad 1. rész false && false
        series.AddEpisode(ep2); // 1. évad 6. rész true && false
        series.AddEpisode(ep3); // 2. évad 1. rész false && true
        Assert.That(series.Episodes, Has.Count.EqualTo(3));
        Assert.That(series.Episodes, Does.Contain(ep1));
        Assert.That(series.Episodes, Does.Contain(ep2));
        Assert.That(series.Episodes, Does.Contain(ep3));
    }

    // Hány saját osztályt használunk ebben a tesztben? 3 db
    // => integrációs teszt
    [Test]
    public void AddEpisode_DuplicateEpisode() // true && true
    {
        series.AddEpisode(ep1);
        Assert.That(() => series.AddEpisode(ep1), Throws.TypeOf<InvalidEpisodeException>());
    }

    // Először írjuk meg a teszteket, majd utána csináljuk meg az implementációt.
    // TDD: Test Driven Development
    [Test]
    public void AddEpisode_WrongEpisode()
    {
        // Az 2-es azonosítójú sorozathoz adok egy olyan epizódot
        // ami az 1-es azonosítójú sorozathoz tartozik.
        Episode ep = new(500, 1, "", DateTime.Now, 3, 5, 20);
        Assert.That(() => series.AddEpisode(ep), Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void Seasons_NoEpisode()
    {
        Assert.That(series.Seasons, Is.EqualTo(0));
    }

    [Test]
    public void Seasons_OneEpisode()
    {
        series.AddEpisode(ep1);
        Assert.That(series.Seasons, Is.EqualTo(1));
    }

    [Test]
    public void Seasons_MultipleEpisodes()
    {
        series.AddEpisodes(ep1, ep2, ep3);
        Assert.That(series.Seasons, Is.EqualTo(2));
    }

    [Test]
    public void GetTotalDuration_NoEpisode()
    {
        Assert.That(series.GetTotalDuration(), Is.EqualTo(0));
    }

    [Test]
    public void GetTotalDuration_OneEpisode()
    {
        series.AddEpisode(ep1);
        Assert.That(series.GetTotalDuration(), Is.EqualTo(ep1.Duration));
    }

    [Test]
    public void GetTotalDuration_MultipleEpisodes()
    {
        series.AddEpisodes(ep1, ep2, ep3);
        List<Episode> testList = [ep1, ep2, ep3];
        int expected = testList.Sum(e => e.Duration);
        Assert.That(series.GetTotalDuration(), Is.EqualTo(expected));
    }
}
