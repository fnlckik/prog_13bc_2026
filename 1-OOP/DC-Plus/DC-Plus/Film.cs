namespace DC_Plus
{
    internal class Film : Content
    {
        public Film(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit,
                    string director, List<string> actors, double budget, double revenue)
             : base(id, title, description, genre, releaseYear, duration, ageLimit)
        {
            Director = director;
            Actors = actors;
            Budget = budget;
            Revenue = revenue;
        }

        public string Director { get; }
        public List<string> Actors { get; }
        public double Budget { get; }
        public double Revenue { get; }
    }
}
