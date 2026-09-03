namespace DC_Plus
{
    internal class Episode
    {
        public Episode(int id, int seriesId, string title, DateTime releaseDate, int season, int episodeNumber, int duration)
        {
            Id = id;
            SeriesId = seriesId;
            Title = title;
            ReleaseDate = releaseDate;
            Season = season;
            EpisodeNumber = episodeNumber;
            Duration = duration;
        }

        public int Id { get; }
        public int SeriesId { get; } // Melyik sorozatban van?
        public string Title { get; }
        public DateTime ReleaseDate { get; }
        public int Season { get; } // 2. évad
        public int EpisodeNumber { get; } // 3. epizód
        public int Duration { get; }

        // "A Skorpió csípése - S1E6"
        public override string ToString()
        {
            return $"{Title} - S{Season:00}E{EpisodeNumber:00}";
        }
    }
}
