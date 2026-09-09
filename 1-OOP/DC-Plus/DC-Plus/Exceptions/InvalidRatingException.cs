namespace DC_Plus.Exceptions
{
    internal class InvalidRatingException : ArgumentOutOfRangeException
    {
        public InvalidRatingException()
            : base("Az értékelés 0 és 10 közötti kell legyen.")
        {
        }
    }
}
