using DC_Plus.Models;

// Unit teszt: egy modul (class) tesztelése
// Integrációs teszt: több modul együttes viselkedése
namespace DCPlus.Tests
{
    public class FilmTests
    {
        private Film film;

        [SetUp]
        public void Setup()
        {
            film = new(id: 1,
                       title: "Odüsszeia",
                       description: "Odüsszeusz hazatér",
                       genre: "fantasy",
                       releaseYear: 2026,
                       duration: 174,
                       ageLimit: 16,
                       director: "Christopher Nolan",
                       actors: ["Matt Damon", "Tom Holland", "Robert Pattinson"],
                       revenue: 1350,
                       budget: 375); // Arrange, Act
        }

        [Test]
        public void Film_Test()
        {
            Assert.Multiple(() =>
            {
                Assert.That(film.ReleaseYear, Is.EqualTo(2026));
                Assert.That(film.Title, Is.EqualTo("Odüsszeia"));
                Assert.That(film.AgeLimit, Is.EqualTo(16));
                //Assert.That(film.Actors.Count, Is.EqualTo(3));
                Assert.That(film.Actors, Has.Count.EqualTo(3));
            });
        }

        [Test]
        public void Download_Test()
        {
            film.Download(); // Act
            Assert.That(film.IsDownloaded, Is.True); // Assert
        }

        [Test]
        public void DeleteDownload_Success()
        {
            Download_Test(); // függünk a Download-tól
            film.DeleteDownload();
            Assert.That(film.IsDownloaded, Is.False);
        }

        [Test]
        public void DeleteDownload_Fail()
        {
            Assert.That(() => film.DeleteDownload(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void GetSummary()
        {
            string result = film.GetSummary();
            Assert.That(result, Is.EqualTo("Film: Odüsszeia - Rendezõ: Christopher Nolan"));
        }

        [Test]
        public void Parse_Succes()
        {
            Film f = Film.Parse("3;A sötét lovag;Batmannek és szövetségeseinek egy kaotikus bûnözõvel, a Jokerrel kell szembenézniük.;2008;Akció;12;152;18670000;Christopher Nolan;Christian Bale|Heath Ledger|Aaron Eckhart|Michael Caine|Gary Oldman|Maggie Gyllenhaal|Morgan Freeman|Cillian Murphy|Tom Hardy;185000000;1006000000;10|10|10|9|10");
            Assert.Multiple(() =>
            {
                Assert.That(f.ReleaseYear, Is.EqualTo(2008));
                Assert.That(f.Title, Is.EqualTo("A sötét lovag"));
                Assert.That(f.AgeLimit, Is.EqualTo(12));
                Assert.That(f.Actors, Has.Count.EqualTo(9));
                Assert.That(f.Ratings, Has.Count.EqualTo(5)); // Content osztályban van az AddRatings
                Assert.That(f.Ratings[0], Is.EqualTo(10));
            });
        }

        [Test]
        public void Parse_IndexOutOfRange()
        {
            Action function = () => Film.Parse("3;A sötét lovag;10|10|10|9|10"); // Arrange, Act
            Assert.That(function, Throws.TypeOf<IndexOutOfRangeException>()); // Assert
        }

        [TestCase("f3;;;20;;12;152;18;;;18;10;")]
        [TestCase("3;;;f20;;12;152;18;;;18;10;")]
        [TestCase("3;;;20;;f12;152;18;;;18;10;")]
        [TestCase("3;;;20;;12;1f52;18;;;18;10;")]
        [TestCase("3;;;20;;12;152;1f8;;;18;10;")]
        [TestCase("3;;;20;;12;152;18;;;1f8;10;")]
        [TestCase("3;;;20;;12;152;18;;;18;1f0;")]
        public void Parse_FormatException(string line)
        {
            Action function = () => Film.Parse(line);
            Assert.That(function, Throws.TypeOf<FormatException>());
        }

        // 100% method coverage-hoz kéne még a Profit getterje is...
    }
}