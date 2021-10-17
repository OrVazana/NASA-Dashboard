using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA.BE;

namespace NASA.DAL
{
    public class DB : System.Data.Entity.DbContext
    {
        public DB() : base("NasaDb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public System.Data.Entity.DbSet<Planet> Planets { get; set; }
        public System.Data.Entity.DbSet<Image> Images { get; set; }
    }
}
