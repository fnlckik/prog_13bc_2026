using DC_Plus.Models;

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
        //public List<Episode> GetAllEpisodes()
        //{

        //}
    }
}
