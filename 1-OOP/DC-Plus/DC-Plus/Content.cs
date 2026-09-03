namespace DC_Plus
{
    internal abstract class Content : IWatchable
    {
        // public int id; // adattag, field, mező

        protected Content(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit)
        {
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            ReleaseYear = releaseYear;
            Duration = duration;
            AgeLimit = ageLimit;
            ViewCount = 0;
        }

        public int Id { get; } // tulajdonság, property
        public string Title { get; }
        public string Description { get; }
        public string Genre { get; }
        public int ReleaseYear { get; }
        public int Duration { get; }
        public int AgeLimit { get; }

        public int ViewCount { get; private set; }

        public void Watch()
        {
            ViewCount++;
        }

        public bool IsPopular
        {
            get => ViewCount > 1_000_000;
        }

        // Film: Odüsszeia - Rendező: Christopher Nolan
        // Sorozat: Pókember - Készítő: Stan Lee
        public abstract string GetSummary();
    }
}
