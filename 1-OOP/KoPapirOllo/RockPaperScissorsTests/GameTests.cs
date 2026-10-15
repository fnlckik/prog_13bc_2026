using RockPaperScissors;

namespace RockPaperScissorsTests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("kõ", true)]
        [TestCase("papír", true)]
        [TestCase("olló", true)]
        [TestCase("Sanyi", false)]
        [TestCase("Balassagyarmat", false)]
        public void IsValid_Test(string item, bool expected)
        {
            var result = Game.IsValid(item);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("kõ", "kõ", "Döntetlen")]
        [TestCase("kõ", "papír", "Béla")]
        [TestCase("papír", "olló", "Béla")]
        [TestCase("olló", "kõ", "Béla")]
        [TestCase("olló", "papír", "Anna")]
        public void DecideWinner_Test(string a, string b, string expected)
        {
            var result = Game.DecideWinner(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        public void Game_InvalidBet()
        {
            Action act = () => new Game("kõ", "kõ", -1);
            Assert.That(act, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        public void Game_InvalidChoice()
        {
            Action act = () => new Game("alma", "kõ", 100);
            Assert.That(act, Throws.TypeOf<ArgumentException>());
        }

        public void Game_Test()
        {
            var result = new Game("kõ", "papír", 100);
            Assert.Multiple(() =>
            {
                Assert.That(result.Choice1, Is.EqualTo("kõ"));
                Assert.That(result.Choice2, Is.EqualTo("papír"));
                Assert.That(result.Bet, Is.EqualTo(100));
            });
        }
    }
}