namespace DC_Plus.Exceptions
{
    public class ContentNotFoundException : InvalidOperationException
    {
        public ContentNotFoundException()
            : base("Nincs ilyen azonosítójú tartalom.")
        {
        }
    }
}
