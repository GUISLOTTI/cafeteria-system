using System.Data;
using CafeteriaApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApp.Services;

public class EstoqueService
{
    private readonly AppDbContext _context;

    public EstoqueService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AtualizarEstoque(Produto produto, int quantidadeVendida)
    {
        if (produto == null)
        {
            throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo");
        }
        
        if (quantidadeVendida <= 0)
        {
            throw new ArgumentException("Quantidade vendida deve ser maior que zero.", nameof(quantidadeVendida));
        }

        if (produto.QuantidadeEmEstoque < quantidadeVendida)
        {
            throw new InvalidOperationException("Estoque insuficiente para o produto.");
        }
        
        produto. QuantidadeEmEstoque -= quantidadeVendida;
        
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public bool VerificarDisponibilidadeDeEstoque(int produtoId, int quantidadeDesejada)
    {
        var produto = _context.Produtos.Find(produtoId);

        if (produto == null)
        {
            throw new Exception("Produto não encontrado.");
        }

        if (quantidadeDesejada <= 0)
        {
            throw new ArgumentException("A quantidade deseajda deve ser maior que zero.");
        }

        if (produto.QuantidadeEmEstoque >= quantidadeDesejada)
        {
            return true;
        }
        
        return false;
    }

    public async Task<List<Produto>> ObterProdutosComEstoqueBaixo(int limiteMinimo)
    {
        return await _context.Produtos.Where(p => p.QuantidadeEmEstoque <= limiteMinimo).ToListAsync();
    }
}