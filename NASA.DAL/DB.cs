using Microsoft.EntityFrameworkCore;
using NASA.BE;

namespace NASA.DAL
{
    public class DB : DbContext
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
