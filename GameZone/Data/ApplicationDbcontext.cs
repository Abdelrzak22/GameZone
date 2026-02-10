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
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Categorey> Categories { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
       
    }
}
