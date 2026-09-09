namespace DC_Plus.Interfaces
{
    internal interface IWatchable
    {
        int ViewCount { get; }
        void Watch();
    }
}
