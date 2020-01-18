using System;
using System.Collections.Generic;
using System.Text;

namespace StooqDownloader
{
    class DownloaderCfg
    {
        public string DestDir { get; private set; }
        public string TickersFile { get; private set; }
        public string StartDt { get; private set; }
        public string EndDt { get; private set; }

        public DownloaderCfg(string destDir, string tickersFile, string startDt, string endDt)
        {
            DestDir = destDir;
            TickersFile = tickersFile;
            StartDt = startDt;
            EndDt = endDt;
        }
    }
}
