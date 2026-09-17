using DC_Plus.Exceptions;

namespace DC_Plus.Models
{
    public class Series : Content
    {
        private List<Episode> episodes; // field (adattag)

        public Series(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit,
                      string creator, bool isOngoing, int viewCount = 0)
               : base(id, title, description, genre, releaseYear, duration, ageLimit, viewCount)
        {
            Creator = creator;
            episodes = [];
            IsOngoing = isOngoing;
        }

        public string Creator { get; }
        public List<Episode> Episodes { get => [.. episodes]; } // property (tulajdonság)
        public bool IsOngoing { get; }

        // Clean Code: Egy függvény egy feladat!
        public void AddEpisode(Episode ep)
        {
            if (episodes.Any(e => e.Season == ep.Season && e.EpisodeNumber == ep.EpisodeNumber)) throw new InvalidEpisodeException();
            episodes.Add(ep);
        }

        // params: változó számú paraméter megadható
        public void AddEpisodes(params Episode[] episodes)
        {
            foreach (Episode ep in episodes)
            {
                AddEpisode(ep);
            }
        }

        public int Seasons
        {
            get
            {
                if (episodes.Count == 0) return 0;
                return episodes.Max(e => e.Season);
            }
        }

        public int GetTotalDuration()
        {
            return episodes.Sum(e => e.Duration);
        }

        public override string GetSummary()
        {
            return $"Sorozat: {Title} - Készítő: {Creator}";
        }

        public static Series Parse(string line)
        {
            string[] data = line.Split(";");
            Series series = new(id: int.Parse(data[0]),
                                title: data[1],
                                description: data[2],
                                genre: data[4],
                                releaseYear: int.Parse(data[3]),
                                duration: int.Parse(data[6]),
                                ageLimit: int.Parse(data[5]),
                                viewCount: int.Parse(data[7]),
                                creator: data[8],
                                isOngoing: bool.Parse(data[9]));
            int[] ratings = data[10].Split('|').Select(int.Parse).ToArray();
            series.AddRatings(ratings);
            return series;
        }
    }
}
