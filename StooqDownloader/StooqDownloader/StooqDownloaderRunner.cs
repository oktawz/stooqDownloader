using System;
using System.Collections.Generic;
using System.Text;

namespace StooqDownloader
{
    class StooqDownloaderRunner
    {
        static void Main(string[] args)
        {
            StooqDownloader _stooqDownloader = new StooqDownloader();
            _stooqDownloader.DownloadStooqData();
        }
    }
}
