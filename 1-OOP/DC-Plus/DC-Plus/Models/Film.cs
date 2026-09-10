using DC_Plus.Interfaces;

namespace DC_Plus.Models
{
    internal class Film : Content, IDownloadable
    {
        public Film(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit,
                    string director, List<string> actors, double budget, double revenue, int viewCount = 0)
             : base(id, title, description, genre, releaseYear, duration, ageLimit, viewCount)
        {
            Director = director;
            Actors = actors;
            Budget = budget;
            Revenue = revenue;
            IsDownloaded = false;
        }

        public string Director { get; }
        public List<string> Actors { get; }
        public double Budget { get; } // Kiadás: millióban megadva
        public double Revenue { get; } // Bevétel

        public double Profit => Revenue - Budget;

        public bool IsDownloaded { get; private set; }

        public void DeleteDownload()
        {
            if (!IsDownloaded) throw new InvalidOperationException("Csak letöltött film törölhető.");
            IsDownloaded = false;
        }

        public void Download()
        {
            IsDownloaded = true;
        }

        public override string GetSummary()
        {
            return $"Film: {Title} - Rendező: {Director}";
        }

        public static Film Parse(string line)
        {
            string[] data = line.Split(";");
            Film film = new(id: int.Parse(data[0]),
                            title: data[1],
                            description: data[2],
                            genre: data[4],
                            releaseYear: int.Parse(data[3]),
                            duration: int.Parse(data[6]),
                            ageLimit: int.Parse(data[5]),
                            viewCount: int.Parse(data[7]),
                            director: data[8],
                            actors: data[9].Split('|').ToList(),
                            revenue: int.Parse(data[10]),
                            budget: int.Parse(data[11]));
            int[] ratings = data[12].Split('|').Select(int.Parse).ToArray();
            film.AddRatings(ratings);
            return film;
        }
    }
}
