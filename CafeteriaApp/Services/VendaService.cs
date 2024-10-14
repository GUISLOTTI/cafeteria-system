using CafeteriaApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApp.Services;

public class VendaService
{
    private readonly AppDbContext _context;

    public VendaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task RegistrarVenda(Venda venda) // depois preciso mover essa responsabilidade pro EstoqueService.
    {
        var produto = await _context.Produtos.FindAsync(venda.ProdutoVendido.Id);

        if (produto != null && produto.QuantidadeEmEstoque >= venda.Quantidade)
        {
            produto.QuantidadeEmEstoque -= venda.Quantidade;
            venda.TotalVenda = venda.Quantidade * produto.PrecoUnitario;

            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Estoque insuficiente");
        }
    }

    public async Task<Venda> BuscarVendaPorId(int id)
    {
        if (id > 0)
        {
            return await _context.Vendas.FindAsync(id);
        }
        else
        {
            throw new ArgumentNullException("Id não pode ser 0.");
        }
    }

    public async Task<List<Venda>> ObterVendasPorPeriodo(DateTime dataInicio, DateTime dataFim)
    {
        return await _context.Vendas.Where(v => v.DataVenda >= dataInicio && v.DataVenda <= dataFim).ToListAsync();
    }
}
