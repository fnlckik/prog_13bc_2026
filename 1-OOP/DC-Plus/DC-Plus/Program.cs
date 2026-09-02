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

            Episode ep1 = new(id: 1,
                              seriesId: 1,
                              title: "A gyík éjszakája (1. rész)",
                              season: 1,
                              episodeNumber: 1,
                              duration: 21,
                              releaseDate: new DateTime(1994, 11, 19));
            Episode ep2 = new(id: 2,
                              seriesId: 1,
                              title: "A Skorpió csípése",
                              season: 1,
                              episodeNumber: 6,
                              duration: 20,
                              releaseDate: new DateTime(1995, 3, 11));
            Episode ep3 = new(id: 3,
                              seriesId: 1,
                              title: "Az Igazságosztó közbelép",
                              season: 2,
                              episodeNumber: 7,
                              duration: 23,
                              releaseDate: new DateTime(1995, 11, 4));
        }
    }
}
