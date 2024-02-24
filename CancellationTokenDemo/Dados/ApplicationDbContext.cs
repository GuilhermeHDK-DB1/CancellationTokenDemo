using CancellationTokenDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CancellationTokenDemo.Dados;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    
    public DbSet<Tabela1> Tabela1 { get; set; }
    public DbSet<Tabela2> Tabela2 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Tabela1Configuration());
        modelBuilder.ApplyConfiguration(new Tabela2Configuration());
    }
}