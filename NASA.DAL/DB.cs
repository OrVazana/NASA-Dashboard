using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA.DAL
{
    class DB : DbContext
    {
        public DB():base("NASA-DB2021")
        {

        }
        //public DbSet<> astroids
    }
}
