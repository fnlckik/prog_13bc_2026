namespace DC_Plus
{
    internal static class FileReader
    {
        public static List<string> ReadLines(string path)
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
