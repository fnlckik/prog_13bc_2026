using DC_Plus;
using DC_Plus.Exceptions;
using DC_Plus.Models;
using NUnit.Framework.Internal;

namespace DCPlus.Tests;

public class ContentServiceTests
{
    private Film film1, film2;
    private Series series;
    private ContentService service;

    [SetUp]
    public void Setup()
    {
        film1 = new(id: 1,
                    title: "Odüsszeia",
                    description: "Odüsszeusz hazatér",
                    genre: "fantasy",
                    releaseYear: 2026,
                    duration: 174,
                    ageLimit: 16,
                    director: "Christopher Nolan",
                    actors: ["Matt Damon", "Tom Holland", "Robert Pattinson"],
                    revenue: 1350,
                    budget: 375);

        series = new(id: 2,
                    title: "Pókember",
                    description: "Klasszikus pókember sorozat",
                    genre: "sci-fi",
                    releaseYear: 1994,
                    ageLimit: 12,
                    duration: 21,
                    creator: "Stan Lee",
                    isOngoing: false);

        film2 = new(id: 3,
                    title: "Eredet",
                    description: "Tolvajok, akik álmokba hatolva lopnak gondolatokat",
                    genre: "sci-fi",
                    releaseYear: 2010,
                    duration: 148,
                    ageLimit: 16,
                    director: "Christopher Nolan",
                    actors: [],
                    budget: 160,
                    revenue: 836);
        service = new([film1, series, film2]);
    }

    [Test]
    public void GetById_NotFound()
    {
        Action act = () => service.GetById(100);
        Assert.That(act, Throws.TypeOf<ContentNotFoundException>());
    }

    [Test]
    public void GetById_Test()
    {
        var result = service.GetById(1);
        Film expected = new(id: 1,
                            title: "Odüsszeia",
                            description: "Odüsszeusz hazatér",
                            genre: "fantasy",
                            releaseYear: 2026,
                            duration: 174,
                            ageLimit: 16,
                            director: "Christopher Nolan",
                            actors: ["Matt Damon", "Tom Holland", "Robert Pattinson"],
                            revenue: 1350,
                            budget: 375);
        //Assert.That(result, Is.EqualTo(expected)); // Passed (sajnos)
        //Assert.That(result, Is.SameAs(expected)); // Failed (hurrá)
        Assert.That(result, Is.SameAs(film1));
    }

    [Test]
    public void SearchByTitle_NoResult()
    {
        var result = service.SearchByTitle("alma");
        //Assert.That(result, Has.Count.EqualTo(0));
        Assert.That(result, Is.Empty);
    }

    [TestCase("Odüsszeia")]
    [TestCase("Odü")]
    [TestCase("szeia")]
    [TestCase("SZEIA")]
    [TestCase("odü")]
    [TestCase("Ü")]
    [TestCase("ü")]
    public void SearchByTitle_OneResult(string search)
    {
        var result = service.SearchByTitle(search);
        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result[0], Is.SameAs(film1));
    }

    [Test]
    public void SearchByTitle_MultipleResult()
    {
        var result = service.SearchByTitle("er");
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result, Does.Contain(series));
        Assert.That(result, Does.Contain(film2));
        Assert.That(result, Does.Not.Contain(film1));
    }

    [Test]
    public void GetContentsByGenre_NoResult()
    {
        var result = service.GetContentsByGenre("akció");
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void GetContentsByGenre_Test()
    {
        var result = service.GetContentsByGenre("sci-fi");
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result, Does.Contain(series));
        Assert.That(result, Does.Contain(film2));
        Assert.That(result, Does.Not.Contain(film1));
    }

    [Test]
    public void GetNewestFilmByGenre_NoResult()
    {
        var result = service.GetNewestFilmByGenre("akció");
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GetNewestFilmByGenre_Test()
    {
        var result = service.GetNewestFilmByGenre("sci-fi");
        Assert.That(result, Is.SameAs(film2));
    }

    // Eredet, Odüsszeia, Pókember
    // film2, film1, series
    [Test]
    public void GetTitlesOrdered_Unordered()
    {
        var result = service.GetTitlesOrdered();
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(film2.Title));
            Assert.That(result[1], Is.EqualTo(film1.Title));
            Assert.That(result[2], Is.EqualTo(series.Title));
        });
    }

    [Test]
    public void GetTitlesOrdered_Ordered()
    {
        ContentService testService = new([film2, film1, series]);
        var result = testService.GetTitlesOrdered();
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(film2.Title));
            Assert.That(result[1], Is.EqualTo(film1.Title));
            Assert.That(result[2], Is.EqualTo(series.Title));
        });
    }

    [Test]
    public void GetTitlesOrdered_ReversedOrder()
    {
        ContentService testService = new([series, film1, film2]);
        var result = testService.GetTitlesOrdered();
        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(film2.Title));
            Assert.That(result[1], Is.EqualTo(film1.Title));
            Assert.That(result[2], Is.EqualTo(series.Title));
        });
    }

    [Test]
    public void GetAllRatingsAverage_NoRating()
    {
        Action act = () => service.GetAllRatingsAverage();
        Assert.That(act, Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void GetAllRatingsAverage_Test()
    {
        int[] numbers = [1, 4, 7];
        film1.AddRating(numbers[0]);
        film1.AddRating(numbers[1]);
        film2.AddRating(numbers[2]);
        series.AddRating(2);
        var result = service.GetAllRatingsAverage();
        Assert.That(result, Is.EqualTo(numbers.Average()));
    }

    [Test]
    public void GetContentCountByGenres_Test()
    {
        var result = service.GetContentCountByGenres();
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result["sci-fi"], Is.EqualTo(2));
        Assert.That(result["fantasy"], Is.EqualTo(1));
    }

    [Test]
    public void GetFilmsByViewCount_Test()
    {
        Film f0 = new(1, "", "", "", 1, 1, 0, "", [], 1, 1, 50);
        Film f1 = new(1, "", "", "", 2, 1, 0, "", [], 1, 1, 99);
        Film f2 = new(1, "", "", "", 3, 1, 0, "", [], 1, 1, 100); // T
        Film f3 = new(1, "", "", "", 4, 1, 0, "", [], 1, 1, 101); // T
        Film f4 = new(1, "", "", "", 5, 1, 0, "", [], 1, 1, 180); // T
        Film f5 = new(1, "", "", "", 6, 1, 0, "", [], 1, 1, 199); // T
        Film f6 = new(1, "", "", "", 7, 1, 0, "", [], 1, 1, 200); // T
        Film f7 = new(1, "", "", "", 8, 1, 0, "", [], 1, 1, 201);
        Film f8 = new(1, "", "", "", 9, 1, 0, "", [], 1, 1, 2000);
        ContentService testService = new([f0, f1, f2, f3, f4, f5, f6, f7, f8]);
        var result = testService.GetFilmsByViewCount(100, 200);
        Assert.Multiple(() =>
        {
            Assert.That(result, Has.Count.EqualTo(5));
            Assert.That(result, Does.Not.Contain(f0));
            Assert.That(result, Does.Not.Contain(f1));
            Assert.That(result, Does.Contain(f2));
            Assert.That(result, Does.Contain(f3));
            Assert.That(result, Does.Contain(f4));
            Assert.That(result, Does.Contain(f5));
            Assert.That(result, Does.Contain(f6));
            Assert.That(result, Does.Not.Contain(f7));
            Assert.That(result, Does.Not.Contain(f8));
        });
    }
}
