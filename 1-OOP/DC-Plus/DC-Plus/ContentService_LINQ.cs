using DC_Plus.Models;
using System.Security.Cryptography;

namespace DC_Plus
{
    internal partial class ContentService
    {
        // Adott műfajba tartozó tartalmak listáját adja meg.
        public List<Content> GetContentsByGenre(string genre)
        {
            return contents.Where(c => c.Genre == genre).ToList();
        }

        // HF: A határozó névelővel kezdődőek ne kerüljenek az elejére
        // hanem a névelő után következő szó döntsön a sorrendről.
        // Egy sorból?
        // Csak a címeket adja meg, névsor szerint növekedve.
        public List<string> GetTitlesOrdered()
        {
            return contents.OrderBy(c => c.Title).Select(c => c.Title).ToList();
            /*
            List<string> result = contents.Select(c => c.Title).ToList();
            result.Sort();
            return result;
            */
            //return contents.Select(c => c.Title).OrderBy(c => c).ToList();
        }

        // Rendezi a tartalmakat megjelenési év,
        // majd cím szerint. Előre kerülnek az
        // újabb tartalmak.
        public List<Content> GetContentsOrderedByYearAndTitle()
        {
            return contents.OrderByDescending(c => c.ReleaseYear).ThenBy(c => c.Title).ToList();
        }

        // Megadja a sorozatok számát.
        public int GetSeriesCount()
        {
            return contents.Count(c => c is Series);
        }

        // Van-e felnőtteknek szóló tartalom?
        public bool HasMatureContent()
        {
            return contents.Any(c => c.AgeLimit == 18);
        }

        // Mikor jelent meg a legrégebbi film?
        public int GetOldestReleaseYear()
        {
            return contents.OfType<Film>().Min(c => c.ReleaseYear);
            //return contents.Where(c => c is Film).Min(c => c.ReleaseYear);
        }

        // Megadja az adott műfajban készült
        // legújabb filmet (a teljes objektumot).
        public Film? GetNewestFilmByGenre(string genre)
        {
            //return GetContentsByGenre(genre).OfType<Film>().OrderByDescending(f => f.ReleaseYear).First();
            return GetContentsByGenre(genre).OfType<Film>().MaxBy(f => f.ReleaseYear);
        }

        // Megadja az összes epizódot egy listában.
        // Gond: sima Select List<List<Episode>>-ot adna.
        public List<Episode> GetAllEpisodes()
        {
            //List<Episode> result = [];
            //foreach (Content content in contents)
            //{
            //    if (content is Series)
            //    {
            //        Series series = (Series)content;
            //        foreach (Episode episode in series.Episodes)
            //        {
            //            result.Add(episode);
            //        }
            //    }
            //}
            //return result;
            return contents.OfType<Series>().SelectMany(s => s.Episodes).ToList();
        }

        // Adjuk meg a hosszú epizódok címeit.
        public List<string> GetLongEpisodeTitles(int minutes)
        {
            return GetAllEpisodes().Where(e => e.Duration >= minutes).Select(e => e.Title).ToList();
        }

        // Adjuk meg a filmekre adott értékelések átlagát.
        public double GetAllRatingsAverage()
        {
            return contents.OfType<Film>().SelectMany(f => f.Ratings).Average();
        }

        // Adjuk meg a műfajokat (duplikációk nélkül)
        public HashSet<string> GetGenres()
        {
            return contents.Select(c => c.Genre).ToHashSet();
            //return contents.Select(c => c.Genre).Distinct().ToList();
        }

        // Műfajonként adjuk meg, hogy hány tartalom van
        //public Dictionary<string, int> GetContentCountByGenres()
        //{
        //    HashSet<string> genres = GetGenres();
        //    Dictionary<string, int> result = new();
        //    foreach (string genre in genres)
        //    {
        //        int count = contents.Count(c => c.Genre == genre);
        //        result.Add(genre, count);
        //    }
        //    return result;
        //}

        //public Dictionary<string, int> GetContentCountByGenres()
        //{
        //    IEnumerable<IGrouping<string, Content>> groups = contents.GroupBy(c => c.Genre);
        //    Dictionary<string, int> result = new();
        //    foreach (IGrouping<string, Content> group in groups)
        //    {
        //        result.Add(group.Key, group.Count());
        //    }
        //    return result;
        //}

        public Dictionary<string, int> GetContentCountByGenres()
        {
            return contents.GroupBy(c => c.Genre).ToDictionary(g => g.Key, g => g.Count());
        }

        // Adjuk meg minden rendezőhöz az első filmet, amit rendezett.
        public Dictionary<string, Film> GetFirstFilmByDirectors()
        {
            return contents.OfType<Film>().GroupBy(f => f.Director).ToDictionary(g => g.Key, g => g.MinBy(f => f.ReleaseYear)!);
        }

        // Megadja adott nézettség határok közötti filmeket.
        public List<Film> GetFilmsByViewCount(int min, int max)
        {
            return contents.OfType<Film>().Where(f => f.ViewCount >= min && f.ViewCount <= max).ToList();
        }
    }
}
