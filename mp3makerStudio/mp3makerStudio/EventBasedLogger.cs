using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp3makerStudio
{
    class EventBasedLogger : ILogger
    {
        public delegate void LogHandler(string message);
        public event LogHandler Log;
        public event LogHandler Debug;

        public delegate void ProgressHandler(int percent);
        public event ProgressHandler Progress;

        public void WriteLog(string message)
        {
            if (Log != null)
            {
                Log(message);
            }
        }

        public void WriteDebug(string message)
        {
            if (Debug != null)
            {
                Debug(message);
            }
        }

        public void ReportProgress(int percent)
        {
            if (Progress != null)
            {
                Progress(percent);
            }
        }
    }


}
