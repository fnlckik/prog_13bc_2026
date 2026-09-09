namespace DC_Plus.Interfaces
{
    internal interface IDownloadable
    {
        bool IsDownloaded { get; }
        void Download();
        void DeleteDownload();
    }
}
