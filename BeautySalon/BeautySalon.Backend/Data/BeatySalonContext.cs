using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Backend.Data
{
    public class BeatySalonContext : DbContext
    {
        public BeatySalonContext(DbContextOptions<BeatySalonContext> options) : base(options)
        {
        }
    }
}