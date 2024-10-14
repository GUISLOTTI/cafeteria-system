using Microsoft.EntityFrameworkCore;

namespace CafeteriaApp.Domain;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente?> Clientes { get; set; }
    public DbSet<Venda> Vendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Username=Guislotti;Password=5040;Database=cafeteria");
    }
}