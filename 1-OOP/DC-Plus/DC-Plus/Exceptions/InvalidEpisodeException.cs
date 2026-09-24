namespace DC_Plus.Exceptions
{
    public class InvalidEpisodeException : InvalidOperationException
    {
        public InvalidEpisodeException()
            : base("Van már ilyen epizód a sorozatban.")
        {
        }
    }
}
