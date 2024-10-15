namespace CafeteriaApp.Domain;

public class Venda
{
    public int Id { get; set; }
    public Task<Produto> ProdutoVendido { get; set; }
    public Task<Cliente?> Cliente { get; set; } // Cliente, se for fiado
    public int Quantidade { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal TotalVenda { get; set; }
}