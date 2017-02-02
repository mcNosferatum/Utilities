using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace mp3makerStudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RadioStation[] rs = null;

        void DownloadFile(string Path, string Name)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(new Uri(Path), Name);
                //webClient.DownloadProgressChanged += (sender1, e1) =>
                //{
                //    progressBar1.Invoke((MethodInvoker)(() =>
                //    {
                //        progressBar1.Value = e1.ProgressPercentage;
                //    }));
                //};
            }
        }

        RadioStation[] ParseM3U(String playlistFileName)
        {
            using (StreamReader sr = File.OpenText(playlistFileName))
            {
                String strPlList = sr.ReadToEnd();
                String[] lines = strPlList.Split(new String[] { "\n", "\r", "\n\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<RadioStation> radiostations = new List<RadioStation>();
                if (lines[0].Trim().ToUpper() == "#EXTM3U")
                {
                    String title = String.Empty;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].StartsWith("#EXTINF", StringComparison.CurrentCultureIgnoreCase))
                        {
                            String[] info = lines[i].Split(new String[] { ":", "," }, StringSplitOptions.None);
                            if (info.Length > 2)
                                title = info[2];
                            radiostations.Add(new RadioStation(title, String.Empty, 0, String.Empty, lines[++i], String.Empty));
                        }
                        else if (lines[i].StartsWith("# ", StringComparison.CurrentCultureIgnoreCase))
                        {
                            title = lines[i].Substring(2);
                            radiostations.Add(new RadioStation(title, String.Empty, 0, String.Empty, lines[++i], String.Empty));
                        }
                        title = String.Empty;
                    }
                }
                else
                {
                    for (int i = 0; i < lines.Length; i++)
                        radiostations.Add(new RadioStation(String.Empty, String.Empty, 0, String.Empty, lines[i].Trim(), String.Empty));
                }

                return radiostations.ToArray();
            }
        }

        void CreateFileToDM(RadioStation[] rs)
        {
            StringBuilder sb = new StringBuilder();
            if (rs == null) return;

            foreach (RadioStation item in rs)
            {
                int ind = item.address.IndexOf('?');
                string short_address = item.address.Remove(ind);
                sb.Append(short_address);
                sb.Append("?&/");
                sb.Append(item.croped_title + ".mp3");
                sb.Append("\r\n");
            }

            File.WriteAllText("D:\\new_file.txt", sb.ToString());
            MessageBox.Show("Файл D:\\new_file.txt создан");
        }

        private void DownloadFiles(Queue<DownloadItem> items)
        {
            //Initialize the logger and its events
            var logger = new EventBasedLogger();
            logger.Log += WriteLog;
            logger.Debug += WriteDebug;
            logger.Progress += WriteProgress;

            //create the downloader object and set its logger
            var downloader = new FileDownloader { Logger = logger };
            new Thread(() =>
                {
                    //create cancellation token source
                    using (var source = new CancellationTokenSource())
                    {
                        //Start download...
                        // Note: You can use async, instead of the synced version

                        downloader.StartDownload(items, source.Token);
                    }
                }).Start();
        }

        //Write progress to console
        static bool finished = false;
        void WriteProgress(int percent)
        {
            if (percent == 100)
            {
                finished = true;
                WriteOutput("Finish");
            }
            Debug.WriteLine("Progress: {0}%", percent);
            progressBar1.Invoke((MethodInvoker)(() =>
            {
                progressBar1.Value = percent;
            }));
        }

        /// <summary>
        /// Вывод в окошко
        /// </summary>
        /// <param name="_Text"></param>
        void WriteOutput(string _Text)
        {
            tbOutput.Invoke((MethodInvoker)(() =>
            {
                tbOutput.Text += _Text + "\r\n";
            }));
        }

        //Write debug message to console
        void WriteDebug(string message)
        {
            Debug.WriteLine("Debug: {0}", message);
            WriteOutput(message + " (Debug)");
        }

        //Write log message to console
        void WriteLog(string message)
        {
            Debug.WriteLine("Log: {0}", message);
            WriteOutput(message + " (Log)");
        }

        private void tsmiSelectM3U_Click(object sender, EventArgs e)
        {
            openM3UFileDialog.InitialDirectory = "d:\\";
            openM3UFileDialog.Filter = "m3u files (*.m3u)|*.m3u";
            openM3UFileDialog.RestoreDirectory = true;

            if (openM3UFileDialog.ShowDialog() == DialogResult.OK)
            {
                rs = ParseM3U(openM3UFileDialog.FileName);
                CreateFileToDM(rs);
            }

            this.Text = String.Format("Всего композиций {0}", rs.Length);
        }

        private void tsmiDownloadMP3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            this.Text = rs.Length.ToString();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DownloadFiles(CreateQueue(fbd.SelectedPath, rs));
            }

            #region OldCode
		            //new Thread(() =>
            //{
            //    for (int i = 0; i < rs.Length; i++)
            //    {
            //        this.Invoke((MethodInvoker)(() =>
            //        {
            //            this.Text = String.Format("{0}/{1}", (i + 1), rs.Length);
            //        }));

            //        //ThreadPool.QueueUserWorkItem(o =>
            //        //{
            //        DownloadFile(rs[i].croped_address,
            //            String.Format("{0}\\{1}.mp3", fbd.SelectedPath, rs[i].croped_title));
            //        //});
            //    }
            //}).Start(); 
	#endregion
        }

        Queue<DownloadItem> CreateQueue(string PathToSave, RadioStation[] rs)
        {
            var items = new Queue<DownloadItem>();
            for (int i = 0; i < rs.Length; i++)
            {
                items.Enqueue(new DownloadItem
                {
                    Address = new Uri(rs[i].croped_address),
                    Path = String.Format("{0}\\{1}.mp3", PathToSave, rs[i].croped_title)
                });
            }
            return items;
        }

        Queue<DownloadItem> CreateQueue(string _Text)
        {
            var items = new Queue<DownloadItem>();

            String[] lines = _Text.Split(new String[] { "\n", "\r", "\n\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            this.Text = lines.Length.ToString();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');
                if (split.Length >= 2)
                {
                    items.Enqueue(new DownloadItem
                    {
                        Address = new Uri(split[0]),
                        Path = split[1]
                    });
                }
            }

            return items;
        }

        private void tsmiDownloadErrors_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = File.OpenText(ofd.FileName))
                {
                    String strPlList = sr.ReadToEnd();
                    DownloadFiles(CreateQueue(strPlList));
                }
            }
        }

        private void tsmiDownloadFromOutput_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            var Queue = CreateQueue(tbOutput.Text);
            tbOutput.Text = "";
            DownloadFiles(Queue);
        }

        private void tsmiRenameFiles_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            foreach (string item in files)
            {
                try
                {
                    TagLib.File tagFile = TagLib.File.Create(item);
                    string artist = RadioStation.toUtf8(tagFile.Tag.FirstPerformer);
                    string title = RadioStation.toUtf8(tagFile.Tag.Title);

                    if (!String.IsNullOrEmpty(title))
                    {
                        int ind = item.LastIndexOf('\\');
                        //переименование
                        File.Move(item, item.Remove(ind + 1) + artist + " - " + title + ".mp3");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(item);
                    Debug.WriteLine("------------------------- ");
                }
            }
        }

        private void tsmiCheckFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < rs.Length; i++)
                {
                    if (!File.Exists(String.Format("{0}\\{1}.mp3", fbd.SelectedPath, rs[i].croped_title)))
                        tbOutput.Text += rs[i].croped_title + "\r\n";
                }
            }
        }
    }
}
