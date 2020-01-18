using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace StooqDownloader
{
    class StooqDownloader
    {
        IConfigurationBuilder _configurationBuilder;

        public StooqDownloader()
        {
            _configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        }

        private DownloaderCfg GetConfigValues()
        {
            IConfigurationRoot configuration = _configurationBuilder.Build();
            var destDir = configuration.GetSection("StooqDownloadrConfig:destDir").Value;
            var tickersFile = configuration.GetSection("StooqDownloadrConfig:tickersFile").Value;
            var startDt = configuration.GetSection("StooqDownloadrConfig:startDt").Value;
            var endDt = configuration.GetSection("StooqDownloadrConfig:endDt").Value;
            return new DownloaderCfg(destDir, tickersFile, startDt, endDt);
        }

      

        public void DownloadStooqData()
        {
            var configValues = GetConfigValues();
            DateTime endtDt = DateTime.Now;

            var destDir = configValues.DestDir;
            if (configValues.EndDt.Trim().Equals(""))
            {
                endtDt = DateTime.Now;
            }
            else
            {
                endtDt = Convert.ToDateTime(configValues.EndDt);
            }

            var startDtStr = configValues.StartDt.Replace("-", "");
            var endDtStr = endtDt.Year +
                 (endtDt.Month < 10 ? "0" + endtDt.Month.ToString() : endtDt.Month.ToString())
                + (endtDt.Day < 10 ? "0" + endtDt.Day.ToString() : endtDt.Day.ToString());

            using (var client = new WebClient())
            {
                var tickerStr = "";
                try
                {
                    tickerStr = File.ReadAllText(configValues.TickersFile);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine($"Directory {Path.GetDirectoryName(configValues.TickersFile)} does not exits ");
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"File {configValues.TickersFile} does not exits ");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Problem while opening {configValues.TickersFile} file");
                } 
                catch (Exception ex)
                {
                    Console.WriteLine($"Is file name correct: {configValues.TickersFile}?");
                }

                var tickers = tickerStr.Split(',').ToList();
                foreach (var ticker in tickers)
                {
                    var downloadStr = "https://stooq.pl/q/d/l/?s=" + ticker + "&d1=" + startDtStr + "&d2=" + endDtStr + "&i=d";
                    client.DownloadFile(downloadStr, destDir + ticker + ".csv");
                    Console.WriteLine(ticker);
                }

            }
        }
        
    }
}
