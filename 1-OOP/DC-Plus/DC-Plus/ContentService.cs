using DC_Plus.Exceptions;
using DC_Plus.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DC_Plus
{
    // Service réteg: üzleti logikát végzi
    internal class ContentService
    {
        private List<Content> contents;

        public ContentService(List<Content> contents)
        {
            this.contents = contents;
        }

        public ContentService()
        {
            this.contents = [];
        }

        public Content GetById(int id)
        {
            if (contents.All(c => c.Id != id)) throw new ContentNotFoundException();
            return contents.First(c => c.Id == id);
        }

        public List<Content> SearchByTitle(string search)
        {
            return contents.Where(c => c.Title.ToLower().Contains(search.ToLower())).ToList();
        }

        public List<Film> GetFilms()
        {
            //return contents.Where(c => c is Film).Select(c => c as Film).ToList()!;
            //return contents.Where(c => c is Film).Select(c => (Film)c).ToList();
            //return contents.Where(c => c is Film).Cast<Film>().ToList();
            return contents.OfType<Film>().ToList();
        }

        // Clean Code: Egy függvény egy feladat!
        // Beolvas + Konvertál + Eltárol
        public void ReadFile(string path)
        {
            try
            {
                IEnumerable<string> lines = FileReader.ReadLines(path).Skip(1);
                foreach (string line in lines)
                {
                    try
                    {
                        Film film = Film.Parse(line); // Series.Parse(line)
                        contents.Add(film);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Hibás adat: {line}");
                    }
                }
                Console.WriteLine(contents.Count);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Hiányzó fájl: {path}");
            }
        }

        public void ReadFile2(string path)
        {
            try
            {
                IEnumerable<string> lines = FileReader.ReadLines(path).Skip(1);
                foreach (string line in lines)
                {
                    try
                    {
                        Series film = Series.Parse(line); // Series.Parse(line)
                        contents.Add(film);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Hibás adat: {line}");
                    }
                }
                Console.WriteLine(contents.Count);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Hiányzó fájl: {path}");
            }
        }
    }
}
