using DC_Plus.Exceptions;
using DC_Plus.Models;

namespace DCPlus.Tests;

public class ContentTests
{
    private Content content;

    [SetUp]
    public void Setup()
    {
        content = new Film(id: 1,
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
    }

    [Test]
    public void Content_Test()
    {
        Content c = new Film(id: 1,
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
        Assert.That(c.Description, Is.EqualTo("Odüsszeusz hazatér"));
        Assert.That(c.ReleaseYear, Is.EqualTo(2026));
        Assert.That(c.Genre, Is.EqualTo("fantasy"));
    }

    [Test]
    public void Content_NegativeDuration()
    {
        Action instantiation = () => new Film(1, "", "", "", 5, -174, 0, "", [], 0, 0);
        Assert.That(instantiation, Throws.TypeOf<ArgumentException>());
    }

    [TestCase(0)]
    [TestCase(6)]
    [TestCase(12)]
    [TestCase(16)]
    [TestCase(18)]
    public void Content_ValidAgeLimit(int ageLimit)
    {
        Content result = new Film(1, "", "", "", 5, 174, ageLimit, "", [], 0, 0);
        Assert.That(result, Is.Not.Null);
    }

    [TestCase(-1)]
    [TestCase(1)]
    [TestCase(5)]
    [TestCase(7)]
    [TestCase(11)]
    [TestCase(13)]
    [TestCase(15)]
    [TestCase(17)]
    [TestCase(19)]
    public void Content_InvalidAgeLimit(int ageLimit)
    {
        Action instantiation = () => new Film(1, "", "", "", 5, 174, ageLimit, "", [], 0, 0);
        Assert.That(instantiation, Throws.TypeOf<ArgumentException>());
    }

    [TestCase(-100)]
    [TestCase(-1)]
    [TestCase(11)]
    [TestCase(110)]
    public void AddRating_InValidRating(int rating)
    {
        Action rate = () => content.AddRating(rating);
        Assert.That(rate, Throws.TypeOf<InvalidRatingException>());
    }

    [TestCase(0)]
    [TestCase(7)]
    [TestCase(10)]
    public void AddRating_ValidRating(int rating)
    {
        content.AddRating(rating);
        Assert.That(content.Ratings, Has.Count.EqualTo(1));
        Assert.That(content.Ratings, Does.Contain(rating));
    }

    [Test]
    public void AverageRating_NoRatings()
    {
        Func<double> average = () => content.AverageRating;
        Assert.That(average, Throws.TypeOf<InvalidOperationException>());
    }
}
