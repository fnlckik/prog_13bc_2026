namespace DC_Plus
{
    internal abstract class Content
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
        }

        public int Id { get; } // tulajdonság, property
        public string Title { get; }
        public string Description { get; }
        public string Genre { get; }
        public int ReleaseYear { get; }
        public int Duration { get; }
        public int AgeLimit { get; }
    }
}
