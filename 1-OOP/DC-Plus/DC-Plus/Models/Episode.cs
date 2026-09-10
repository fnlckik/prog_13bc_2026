namespace DC_Plus.Models
{
    internal class Episode
    {
        public Episode(int id, int seriesId, string title, DateTime releaseDate, int season, int episodeNumber, int duration, int viewCount = 0)
        {
            Id = id;
            SeriesId = seriesId;
            Title = title;
            ReleaseDate = releaseDate;
            Season = season;
            EpisodeNumber = episodeNumber;
            Duration = duration;
            ViewCount = viewCount;
        }

        public int Id { get; }
        public int SeriesId { get; } // Melyik sorozatban van?
        public string Title { get; }
        public DateTime ReleaseDate { get; }
        public int Season { get; } // 2. évad
        public int EpisodeNumber { get; } // 3. epizód
        public int Duration { get; }
        public int ViewCount { get; }

        // "A Skorpió csípése - S1E6"
        public override string ToString()
        {
            return $"{Title} - S{Season:00}E{EpisodeNumber:00}";
        }

        public static Episode Parse(string line)
        {
            string[] data = line.Split(";");
            Episode episode = new(id: int.Parse(data[0]),
                                  seriesId: int.Parse(data[1]),
                                  title: data[2],
                                  season: int.Parse(data[3]),
                                  episodeNumber: int.Parse(data[4]),
                                  duration: int.Parse(data[5]),
                                  releaseDate: DateTime.Parse(data[6]),
                                  viewCount: int.Parse(data[7]));
            return episode;
        }
    }
}
