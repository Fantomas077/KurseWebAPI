using KurseAPI.Models;
using Microsoft.EntityFrameworkCore;

public class KurseDbContext : DbContext
{
    public KurseDbContext(DbContextOptions<KurseDbContext> options) : base(options)
    {
    }

    public DbSet<Kurse> Kurses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Adresse> Adresses { get; set; }
    public DbSet<Kauf> Käufe { get; set; }
    public DbSet<Language> Language { get; set; }


}
