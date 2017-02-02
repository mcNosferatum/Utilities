using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mp3makerStudio
{
    public class DownloadItem
    {
        /// <summary>
        /// Ссылка на файл
        /// </summary>
        public Uri Address { get; set; }
        
        /// <summary>
        /// Путь сохранения
        /// </summary>
        public string Path { get; set; }
    }
}
