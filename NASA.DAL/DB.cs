using System.Data.Entity;
using System.Net.Http;

namespace NASA.DAL
{
    class DB : DbContext
    {
        static HttpClient client = new HttpClient();
        public DB() : base("NASA-DB2021")
        {

        }
    }
}
