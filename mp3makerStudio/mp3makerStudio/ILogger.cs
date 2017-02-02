using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp3makerStudio
{
    public interface ILogger
    {
        void WriteLog(string message);
        void WriteDebug(string message);
        void ReportProgress(int percent);
    }
}
