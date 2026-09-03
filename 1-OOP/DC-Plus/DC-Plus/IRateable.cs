namespace DC_Plus
{
    internal interface IRateable
    {
        List<int> Ratings { get; }
        double AverageRating { get; }
        void AddRating(int rating); // 0..10
    }
}
