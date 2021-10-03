using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.BE
{
    public class TodayPhoto
    {
        public DateTime date { get; set; }
        public string explanation { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }

        public TodayPhoto()
        {

        }

        public TodayPhoto(DateTime date, string explanation,string hdurl,string media_type,string service_version, string title,string url)
        {
            this.date = date;
            this.explanation = explanation;
            this.hdurl = hdurl;
            this.media_type = media_type;
            this.service_version = service_version;
            this.title = title;
            this.url = url;
        }
    }
}
