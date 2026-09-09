namespace DC_Plus.Interfaces
{
    internal interface IRateable
    {
        List<int> Ratings { get; }
        double AverageRating { get; }
        void AddRating(int rating); // 0..10
    }
}
