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

        // ------------------------------------

        public void TryDivide()
        {
            calc.Divide(5, 0);
        }

        // Ha elvégezném az osztást, akkor kivételt kapnék!
        [Test]
        public void Divide_Throws_Exception()
        {
            Assert.That(() => calc.Divide(5, 0), Throws.Exception);
        }

        [Test]
        public void Divide_Throws_DivideByZeroException()
        {
            Assert.That(() => calc.Divide(5, 0), Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void Divide_Throws_CorrectMessage()
        {
            var ex = Assert.Throws<DivideByZeroException>(() => calc.Divide(5, 0));
            Assert.That(ex.Message, Is.EqualTo("Nem lehet 0-val osztani."));
        }

        [TestCase(6, 2, 3)]
        [TestCase(10, 3, 3)]
        [TestCase(17, 3, 5)]
        public void Divide_Test(int a, int b, int expected)
        {
            int result = calc.Divide(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Boundary Value Analysis (BVA) -> edge case
        // Minden ekvivalenciaosztályból (3) veszünk ki egy-egy reprezentánst.
        // + a határokat teszteljük
        [TestCase(-1)]
        [TestCase(151)]
        public void IsAdult_InvalidAge(int age)
        {
            Assert.That(() => calc.IsAdult(age), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(0, false)]
        [TestCase(17, false)]
        [TestCase(18, true)]
        [TestCase(19, true)]
        [TestCase(150, true)]
        public void IsAdult_Test(int age, bool expected)
        {
            bool result = calc.IsAdult(age);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}