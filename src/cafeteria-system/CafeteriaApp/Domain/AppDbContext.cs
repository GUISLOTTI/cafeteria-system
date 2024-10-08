using Microsoft.EntityFrameworkCore;

namespace CafeteriaApp.Domain;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Venda> Vendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres;Username=Guislotti;Password=504030;Database=cafeteria");
    }
}