
namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = ReadFromFile("../../../names.txt");
            Console.WriteLine(names.Count);
            Console.WriteLine(names[names.Count-1]);
        }

        private static List<string> ReadFromFile(string path)
        {
            List<string> result = [];
            using StreamReader sr = new(path);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine()!;
                result.Add(line);
            }
            return result;
        }
    }
}
