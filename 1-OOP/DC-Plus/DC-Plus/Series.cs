namespace DC_Plus
{
    internal class Series : Content
    {
        public Series(int id, string title, string description, string genre, int releaseYear, int duration, int ageLimit,
                      string creator, List<Episode> episodes, bool isOngoing)
               : base(id, title, description, genre, releaseYear, duration, ageLimit)
        {
            Creator = creator;
            Episodes = episodes;
            IsOngoing = isOngoing;
        }

        public string Creator { get; }
        public List<Episode> Episodes { get; }
        public bool IsOngoing { get; }
    }
}
