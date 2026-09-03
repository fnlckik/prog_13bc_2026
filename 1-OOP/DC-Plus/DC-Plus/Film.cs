namespace DC_Plus
{
    internal class Film : Content, IDownloadable
    {
        public Film(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit,
                    string director, List<string> actors, double budget, double revenue)
             : base(id, title, description, genre, releaseYear, duration, ageLimit)
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
    }
}
