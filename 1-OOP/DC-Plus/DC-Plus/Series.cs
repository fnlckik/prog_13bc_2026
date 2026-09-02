namespace DC_Plus
{
    internal class Series : Content
    {
        private List<Episode> episodes; // field (adattag)

        public Series(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit,
                      string creator, bool isOngoing)
               : base(id, title, description, genre, releaseYear, duration, ageLimit)
        {
            Creator = creator;
            episodes = [];
            IsOngoing = isOngoing;
        }

        public string Creator { get; }
        public List<Episode> Episodes { get => [.. episodes]; } // property (tulajdonság)
        public bool IsOngoing { get; }

        public void AddEpisode(Episode ep)
        {
            episodes.Add(ep);
        }
    }
}
