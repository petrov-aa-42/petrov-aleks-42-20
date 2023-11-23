using petrovkt42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace petrovkt42_20.Database
{
    public class PrepodDbContext : DbContext
    {
        public DbSet<Kafedra> Kafedra { get; set; }
        public DbSet<Prepod> Prepod { get; set; }
        public DbSet<Degree> Degree { get; set; }

        public PrepodDbContext(DbContextOptions<PrepodDbContext> options) : base(options)
        {
        }
    }
}
