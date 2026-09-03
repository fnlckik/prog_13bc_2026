namespace DC_Plus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Content content = new Content();
            List<string> actors = [ "Matt Damon", "Tom Holland", "Robert Pattinson" ];
            // named argument
            // Alt + Enter -> Wrap every argument -> Align wrapped arguments
            Film film = new(id: 1,
                            title: "Odüsszeia",
                            description: "Odüsszeusz hazatér",
                            genre: "fantasy",
                            releaseYear: 2026,
                            duration: 174,
                            ageLimit: 16,
                            director: "Christopher Nolan",
                            actors: actors,
                            revenue: 1350,
                            budget: 375);
            Console.WriteLine($"Film címe: {film.Title}");

            Series series = new(id: 2,
                                title: "Pókember",
                                description: "Klasszikus pókember sorozat",
                                genre: "sci-fi",
                                releaseYear: 1994,
                                ageLimit: 12,
                                duration: 21,
                                creator: "Stan Lee",
                                isOngoing: false);
            Console.WriteLine($"Sorozat címe: {series.Title}");
            Console.WriteLine($"Epizódok száma: {series.Episodes.Count}");

            Episode ep1 = new(id: 1,
                              seriesId: 2,
                              title: "A gyík éjszakája (1. rész)",
                              season: 1,
                              episodeNumber: 1,
                              duration: 21,
                              releaseDate: new DateTime(1994, 11, 19));
            Episode ep2 = new(id: 2,
                              seriesId: 2,
                              title: "A Skorpió csípése",
                              season: 1,
                              episodeNumber: 6,
                              duration: 20,
                              releaseDate: new DateTime(1995, 3, 11));
            Episode ep3 = new(id: 3,
                              seriesId: 2,
                              title: "Az Igazságosztó közbelép",
                              season: 2,
                              episodeNumber: 7,
                              duration: 23,
                              releaseDate: new DateTime(1995, 11, 4));
            //series.Episodes.Add(ep1);
            //series.Episodes.Add(ep2);
            //series.Episodes.Add(ep3);
            //series.AddEpisode(ep1);
            //series.AddEpisode(ep2);
            //series.AddEpisode(ep3);
            series.AddEpisodes(ep1, ep2, ep3);
            series.Episodes.Clear();
            Console.WriteLine($"Epizódok száma: {series.Episodes.Count}");
            Console.WriteLine("Epizódok címei:");
            foreach (Episode ep in series.Episodes)
            {
                Console.WriteLine($"\t{ep}");
            }

            Console.WriteLine($"Nézettség: {film.ViewCount}");
            film.Watch();
            Console.WriteLine($"Nézettség: {film.ViewCount}");
            Console.WriteLine($"Népszerű-e: {film.IsPopular}");
            Console.WriteLine($"Profit: {film.Profit}");

            Console.WriteLine($"Évadok száma: {series.Seasons}");
            Console.WriteLine($"Sorozat hossza: {series.GetTotalDuration()}");

            Film film2 = new(id: 3,
                             title: "Eredet",
                             description: "Tolvajok, akik álmokba hatolva lopnak gondolatokat",
                             genre: "sci-fi",
                             releaseYear: 2010,
                             duration: 148,
                             ageLimit: 16,
                             director: "Christopher Nolan",
                             actors,
                             budget: 160,
                             revenue: 836);

            Film film3 = new(id: 4,
                             title: "Pókember: Vadiúj nap",
                             description: "Pókember új fejezetbe kezdi meg életét és szuperhős karrierjét",
                             genre: "akció",
                             releaseYear: 2026,
                             duration: 140,
                             ageLimit: 12,
                             director: "Jon Watts",
                             actors,
                             budget: 200,
                             revenue: 950);

            Series series2 = new(id: 5,
                                 title: "Agymenők",
                                 description: "Két zseniális fizikus és barátaik mindennapjai",
                                 genre: "vígjáték",
                                 releaseYear: 2007,
                                 ageLimit: 12,
                                 duration: 22,
                                 creator: "Chuck Lorre",
                                 isOngoing: false);
            Console.WriteLine();

            // Polimorfizmus: Ősosztály beli metódus másképp tud viselkedni (különböző implementációkkal rendelkezhet) az alosztályokban.
            List<Content> contents = [film, series, film2, film3, series2];
            foreach (Content content in contents)
            {
                Console.WriteLine(content.GetSummary());
            }
            Console.WriteLine();

            film.AddRating(8);
            film.AddRating(10);
            film.AddRating(7);
            Console.WriteLine($"Átlagos értékelés: {film.AverageRating:0.0}");
            Console.WriteLine();

            film.Download();
            Console.WriteLine($"Letöltve? {film.IsDownloaded}");
            film.DeleteDownload();
            Console.WriteLine($"Letöltve? {film.IsDownloaded}");
        }
    }
}
