namespace TextHelperApp.Tests
{
    public class TextHelperTests
    {
        private TextHelper th;

        [SetUp]
        public void Setup()
        {
            th = new(); // Arrange - elõkészület
        }

        [TestCase("macificam")]
        [TestCase("taco cat")]
        [TestCase("Géza kék az ég")]
        [TestCase("")]
        [TestCase("t")]
        [TestCase("apa")]
        public void IsPalindrome_True(string s)
        {
            bool result = th.IsPalindrome(s); // Act - elvégzés
            Assert.That(result, Is.True); // Assert - ellenõrzés
        }

        [TestCase("kérek")]
        [TestCase("anya")]
        [TestCase("medvefarhát")]
        [TestCase("káposztás")]
        [TestCase("kecske")]
        public void IsPalindrome_False(string s)
        {
            bool result = th.IsPalindrome(s); // Act - elvégzés
            Assert.That(result, Is.False); // Assert - ellenõrzés
        }

        // Keresés tétel tesztelése!
        [Test]
        public void FirstWithE_Middle()
        {
            string[] words = ["vörös", "narancs", "szürke", "kék"]; // Arrange
            string result = th.FirstWithE(words); // Act
            Assert.That(result, Is.EqualTo("szürke")); // Assert
        }

        [Test]
        public void FirstWithE_First()
        {
            string[] words = ["Eger", "vörös", "narancs", "kék"];
            string result = th.FirstWithE(words);
            Assert.That(result, Is.EqualTo("Eger"));
        }

        [Test]
        public void FirstWithE_Last()
        {
            string[] words = ["vörös", "narancs", "kék", "kiégek"];
            string result = th.FirstWithE(words);
            Assert.That(result, Is.EqualTo("kiégek"));
        }

        [Test]
        public void FirstWithE_NoMatch()
        {
            string[] words = ["vörös", "narancs", "kék"]; // Arrange
            Action f = () => th.FirstWithE(words); // Act
            Assert.That(f, Throws.TypeOf<InvalidOperationException>()); // Assert
        }
    }
}