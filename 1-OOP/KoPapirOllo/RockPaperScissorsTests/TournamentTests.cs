using RockPaperScissors;

namespace RockPaperScissorsTests;

public class TournamentTests
{
    private Game g1, g2, g3, g4, g5;
    private Tournament t;

    [SetUp]
    public void Setup()
    {
        // Anna: 1000 - 100 + 500 + 200 = 1600
        g1 = new("kő", "papír", 100); // Béla nyert
        g2 = new("olló", "olló", 200); // Döntetlen
        g3 = new("kő", "olló", 500); // Anna nyert
        g4 = new("papír", "kő", 200); // Anna nyert
        g5 = new("kő", "kő", 300); // Döntetlen
        t = new(DateTime.Now);
        t.AddGame(g1);
        t.AddGame(g2);
        t.AddGame(g3);
        t.AddGame(g4);
        t.AddGame(g5);
    }

    [Test]
    public void Tournament_Test()
    {
        var result = new Tournament(DateTime.Now); // new DateTime(2026, 10, 15)
        Assert.Multiple(() =>
        {
            Assert.That(result.Money1, Is.EqualTo(1000));
            Assert.That(result.Money2, Is.EqualTo(1000));
            Assert.That(result.Games, Is.Empty);
        });
    }

    [TestCase("Anna", 2)]
    [TestCase("Béla", 1)]
    public void CountWins_Test(string player, int expected)
    {
        var result = t.CountWins(player);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetFirstDraw_Test()
    {
        var result = t.GetFirstDraw();
        Assert.That(result, Is.SameAs(g2));
    }

    [Test]
    public void GetFirstDraw_NoDraw()
    {
        Tournament testTournament = new(DateTime.Now);
        var result = testTournament.GetFirstDraw();
        Assert.That(result, Is.Null);
    }

    [Test]
    public void GetDrawGames_Test()
    {
        var result = t.GetDrawGames();
        Assert.That(result, Has.Count.EqualTo(2));
        Assert.That(result, Does.Contain(g2));
        Assert.That(result, Does.Contain(g5));
    }

    [Test]
    public void GetFinalMoney_Test()
    {
        var result = t.GetFinalMoney();
        Assert.Multiple(() =>
        {
            Assert.That(result["Anna"], Is.EqualTo(1600));
            Assert.That(result["Béla"], Is.EqualTo(400));
        });
    }

    [Test]
    public void GetFinalMoney_Fail()
    {
        Tournament testTournament = new(DateTime.Now);
        Game g = new("kő", "papír", 1200);
        testTournament.AddGame(g);
        Action act = () => testTournament.GetFinalMoney();
        Assert.That(act, Throws.TypeOf<InvalidOperationException>());
    }
}
