namespace CalculatorApp.Tests
{
    // ~ Ez az osztály teszteket tartalmaz.
    [TestFixture] // ma már nem kötelezõ
    public class CalculatorTests
    {
        private Calculator calc;

        // Minden teszt elõtt lefut.
        [SetUp]
        public void Setup()
        {
            calc = new(); // Arrange
        }

        // Elõkészítés, végrehajtás, állítás
        // AAA minta: Arrange, Act, Assert (kijelentés, állítás)
        // Classic model VS Constraint model
        [Test]
        public void Square_5_25()
        {
            int result = calc.Square(5); // Act
            //Assert.AreEqual(25, result);
            Assert.That(result, Is.EqualTo(25)); // Assert
        }

        [Test]
        public void Square_3_9()
        {
            int result = calc.Square(3);
            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void Square_m7_49()
        {
            int result = calc.Square(-7);
            Assert.That(result, Is.EqualTo(49));
        }

        [Test]
        public void IsEven_1()
        {
            bool result = calc.IsEven(1);
            Assert.That(result, Is.False); // Is.EqualTo(false)
        }

        [Test]
        public void IsEven_12()
        {
            bool result = calc.IsEven(12);
            Assert.That(result, Is.True);
        }

        /*
        [Test]
        public void Add_2_3()
        {
            int result = calc.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Add_69_83()
        {
            int result = calc.Add(69, 83);
            Assert.That(result, Is.EqualTo(152));
        }

        [Test]
        public void Add_5_m3()
        {
            int result = calc.Add(5, -3);
            Assert.That(result, Is.EqualTo(2));
        }
        */

        [TestCase(2, 3, 5)]
        [TestCase(69, 83, 152)]
        [TestCase(5, -3, 2)]
        public void Add_Test(int a, int b, int expected)
        {
            int result = calc.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}