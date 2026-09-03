
namespace DC_Plus
{
    internal abstract class Content : IWatchable, IRateable
    {
        // public int id; // adattag, field, mező
        private static int[] validAgeLimits = { 0, 6, 12, 16, 18 };

        //if (!validAgeLimits.Any(e => e == ageLimit)) throw new ArgumentException("Érvénytelen korhatár.");
        protected Content(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit)
        {
            if (duration < 0) throw new ArgumentException("A játékidő nem lehet negatív.");
            if (!validAgeLimits.Contains(ageLimit)) throw new ArgumentException("Érvénytelen korhatár.");
            Id = id;
            Title = title;
            Description = description;
            Genre = genre;
            ReleaseYear = releaseYear;
            Duration = duration;
            AgeLimit = ageLimit; // 0, 6, 12, 16, 18
            ViewCount = 0;
            Ratings = [];
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

        public List<int> Ratings { get; }

        public double AverageRating => Ratings.Average();

        // Film: Odüsszeia - Rendező: Christopher Nolan
        // Sorozat: Pókember - Készítő: Stan Lee
        public abstract string GetSummary();

        public void AddRating(int rating)
        {
            if (rating < 0 || rating > 10) throw new ArgumentOutOfRangeException("Az értékelés 0 és 10 közötti kell legyen.");
            Ratings.Add(rating);
        }
    }
}
