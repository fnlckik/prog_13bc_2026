namespace DC_Plus
{
    internal interface IDownloadable
    {
        bool IsDownloaded { get; }
        void Download();
        void DeleteDownload();
    }
}
