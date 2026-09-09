namespace DC_Plus.Exceptions
{
    internal class ContentNotFoundException : InvalidOperationException
    {
        public ContentNotFoundException()
            : base("Nincs ilyen azonosítójú tartalom.")
        {
        }
    }
}
