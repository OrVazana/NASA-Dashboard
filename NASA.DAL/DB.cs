using Microsoft.EntityFrameworkCore;
using NASA.BE;

namespace NASA.DAL
{
    public class DB : DbContext
    {
        public DbSet<Planet> Planets { get; set; }
        public DB()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NASA2021ProjectDB;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>().HasData(
                new Planet() { Name = "Earth", ImageSource = "/Images/Earth.png", Description = "Earth is the third planet from the Sun and the only astronomical object known to harbour and support life. About 29.2% of Earth's surface is land consisting of continents and islands. The remaining 70.8% is covered with water." },
                new Planet() { Name = "Mars", ImageSource = "/Images/mars.png", Description = "Mars is the fourth planet from the Sun and the second-smallest planet in the Solar System, being larger than only Mercury. In English, Mars carries the name of the Roman god of war and is often referred to as the Red Planet" },
                new Planet() { Name = "Jupiter", ImageSource = "/Images/Jupiter.png", Description = "Jupiter is the fifth planet from the Sun and the largest in the Solar System. It is a gas giant with a mass more than two and a half times that of all the other planets in the Solar System combined, but slightly less than one-thousandth the mass of the Sun." },
                new Planet() { Name = "Saturn", ImageSource = "/Images/saturn.png", Description = "Saturn is the sixth planet from the Sun and the second-largest in the Solar System, after Jupiter. It is a gas giant with an average radius of about nine and a half times that of Earth. It only has one-eighth the average density of Earth; however, with its larger volume, Saturn is over 95 times more massive." },
                new Planet() { Name = "Uranus", ImageSource = "/Images/URANUS.png", Description = "Uranus is the seventh planet from the Sun. Its name is a reference to the Greek god of the sky, Uranus, who, according to Greek mythology, was the great-grandfather of Ares (Mars), grandfather of Zeus (Jupiter) and father of Cronus (Saturn)." },
                new Planet() { Name = "Neptune", ImageSource = "/Images/NEPTUNE.png", Description = "Neptune is the eighth and farthest known Solar planet from the Sun. In the Solar System, it is the fourth-largest planet by diameter, the third-most-massive planet, and the densest giant planet. It is 17 times the mass of Earth, slightly more massive than its near-twin Uranus." },
                new Planet() { Name = "Mercury", ImageSource = "/Images/Mercury.png", Description = "Mercury is the smallest planet in the Solar System and the closest to the Sun. Its orbit around the Sun takes 87.97 Earth days, the shortest of all the Sun's planets. It is named after the Roman god Mercurius (Mercury), god of commerce" },
                new Planet() { Name = "Venus", ImageSource = "/Images/Venus_new.png", Description = "Venus is the second planet from the Sun. It is named after the Roman goddess of love and beauty. As the brightest natural object in Earth's night sky after the Moon, Venus can cast shadows and can be, on rare occasions, visible to the naked eye in broad daylight." });
        }
    }
}
