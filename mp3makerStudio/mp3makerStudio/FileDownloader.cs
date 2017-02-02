using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace mp3makerStudio
{
 public class FileDownloader
    {
        private int processed = 0;
        private int initialCount = 0;

        public ILogger Logger { get; set; }
        private void OnProgress(int percent)
        {
            if (Logger != null)
            {
                Logger.ReportProgress(percent);
            }
        }

        public void StartDownload(IEnumerable<DownloadItem> items, CancellationToken ct)
        {
            initialCount = items.Count();

            Parallel.ForEach
                (items,
                new ParallelOptions { MaxDegreeOfParallelism = 8 },
                file =>
                    {
                        if (ct.IsCancellationRequested)
                            ct.ThrowIfCancellationRequested();

                        try
                        {
                            if (!File.Exists(file.Path))
                            {
                                try
                                {
                                    using (var cli = new WebClient())
                                    {
                                        cli.DownloadFile(file.Address, file.Path);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine(ex.Message);
                                    if (Logger != null)
                                    {
                                        Logger.WriteLog(file.Address + ", " + file.Path  + ", " + ex.Message);
                                    }
                                }
                            }

                            int pro = Interlocked.Increment(ref processed);
                            double percent = 100.0 * pro / initialCount;
                            OnProgress((int)percent);
                        }
                        catch (Exception)
                        {
                            if (File.Exists(file.Path))
                                File.Delete(file.Path);
                        }
                    }
                );
        }
    }
}
