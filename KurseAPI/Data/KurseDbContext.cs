using KurseAPI.Models;
using Microsoft.EntityFrameworkCore;

public class KurseDbContext : DbContext
{
    public KurseDbContext(DbContextOptions<KurseDbContext> options) : base(options)
    {
    }

    public DbSet<Kurse> Kurses { get; set; }
}
