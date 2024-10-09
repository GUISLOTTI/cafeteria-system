using CafeteriaApp.Domain;

namespace CafeteriaApp.Services;

public class VendaService
{
    private readonly AppDbContext _context;

    public VendaService(AppDbContext context)
    {
        _context = context;
    }

    public void RegistrarVenda(Venda venda)
    {
        var produto = _context.Produtos.Find(venda.ProdutoVendido.Id);

        if (produto != null && produto.QuantidadeEmEstoque >= venda.Quantidade)
        {
            produto.QuantidadeEmEstoque -= venda.Quantidade;
            venda.TotalVenda = venda.Quantidade * produto.PrecoUnitario;

            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Estoque insuficiente");
        }
    }
}