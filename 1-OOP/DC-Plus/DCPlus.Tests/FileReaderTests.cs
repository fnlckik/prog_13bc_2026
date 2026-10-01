using DC_Plus;

namespace DCPlus.Tests;

public class FileReaderTests
{
    [SetUp]
    public void Setup()
    {
        using StreamWriter sw = new("test.txt");
        sw.WriteLine("alma");
        sw.WriteLine("körte");
        sw.WriteLine("barack");
    }

    [Test]
    public void ReadLines_FileNotFound()
    {
        Action tryRead = () => FileReader.ReadLines("hiba.txt");
        Assert.That(tryRead, Throws.TypeOf<FileNotFoundException>());
    }

    [Test]
    public void ReadLines_Test()
    {
        List<string> result = FileReader.ReadLines("test.txt");
        Assert.That(result, Has.Count.EqualTo(3));
        Assert.That(result[0], Is.EqualTo("alma"));
        Assert.That(result[1], Is.EqualTo("körte"));
        Assert.That(result[2], Is.EqualTo("barack"));
    }

    // Minden teszteset után lefut!
    [TearDown]
    public void DeleteTestFile()
    {
        File.Delete("test.txt");
    }
}
