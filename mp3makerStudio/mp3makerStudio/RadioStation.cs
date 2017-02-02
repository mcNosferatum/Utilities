using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace mp3makerStudio
{
    class RadioStation
    {
        public string title, genre, country, address, comment;
        public int bitRate;

        public RadioStation(String title, String genre, int bitRate, String country, String address, String comment)
        {
            this.title = title;
            this.genre = genre;
            this.bitRate = bitRate;
            this.country = country;
            this.address = address;
            this.comment = comment;
        }

        public string croped_title
        {
            get 
            {
                string _title = toUtf8(title);
                _title = _title.Replace(" ", "_");
                _title = RemoveDoubleSimbols('_', _title);
                _title = RemoveDoubleSimbols('.', _title);
                if (_title.Length > 200)
                    _title = _title.Remove(200);
                //_title = RemoveDoubleSimbols(' ', _title);
                return _title;
            }
        }

        public string croped_address
        {
            get
            {
                int ind = address.IndexOf('?');
                return address.Remove(ind);
            }
        }

        public string RemoveDoubleSimbols(char simbol, string curr_str)
        {
            string double_simbol = new String(new char[] { simbol, simbol });
            while (curr_str.IndexOf(double_simbol) > 0)
            {
                curr_str = curr_str.Replace(double_simbol, simbol.ToString());
            }

            return curr_str;
        }

        public static string toUtf8(string unknown)
        {
            if (unknown == null) return null;

            char[] charInvalidFileChars = Path.GetInvalidFileNameChars();
            foreach (char charInvalid in charInvalidFileChars)
            {
                unknown = unknown.Replace(charInvalid, ' ');
            }

            return new string(unknown.ToCharArray().Select(x => ((x + 848) >= 'А' && (x + 848) <= 'ё') ? (char)(x + 848) : x).ToArray());
        }
    }
}
