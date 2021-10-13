using Microsoft.EntityFrameworkCore;
using NASA.BE;

namespace NASA.DAL
{
    class DB : DbContext
    {
        public DB() : base()
        {

        }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Asteroid> 
    }
}
