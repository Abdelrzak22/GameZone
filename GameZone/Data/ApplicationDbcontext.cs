using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class ApplicationDbcontext : DbContext

    {

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevice>()
                .HasKey(p => new { p.GameId, p.DeviceId });


            modelBuilder.Entity<Categorey>()
                .HasData(new Categorey[] {

                    new Categorey{ Id=1, Name="Action" },
                    new Categorey{ Id=2, Name="Sports" },
                    new Categorey{ Id=3, Name="Fighting" },
                    new Categorey{ Id=4, Name="Film" },
                    new Categorey{ Id=5, Name="Adventure" },
                    new Categorey{ Id=6, Name="Racing" },
                });


            modelBuilder.Entity<Device>()
                .HasData(new Device[] {


                    new Device{ Id=1,Name="Playstation",Icon="bi bi-playstation" },
                    new Device{ Id=2,Name="xbox",Icon="bi bi-xbox" },
                    new Device{Id=3 ,Name="Nintendo switch",Icon="bi bi-nintendo-switch"},
                    new Device{ Id=4 ,Name="Pc",Icon="bi bi-pc-display"}

                });
                
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Categorey> Categories { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
       
    }
}
