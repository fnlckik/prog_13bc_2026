namespace DC_Plus.Exceptions
{
    internal class InvalidEpisodeException : InvalidOperationException
    {
        public InvalidEpisodeException()
            : base("Van már ilyen epizód a sorozatban.")
        {
        }
    }
}
