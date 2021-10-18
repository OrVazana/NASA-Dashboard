using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA.BE;
using System;

namespace NASA.DAL
{
    public class DB : System.Data.Entity.DbContext
    {
        public DbSet<Planet> Planets { get; set; }

        public string DbPath { get; private set; }

        public DB()
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NASA2021ProjectDB;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        
    }
}
