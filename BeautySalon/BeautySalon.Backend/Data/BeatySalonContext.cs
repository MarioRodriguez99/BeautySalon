using Microsoft.EntityFrameworkCore;
using BeautySalon.Shared.Entities;

namespace BeautySalon.Backend.Data
{
    public class BeatySalonContext : DbContext
    {
        public BeatySalonContext(DbContextOptions<BeatySalonContext> options) : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
    }
}