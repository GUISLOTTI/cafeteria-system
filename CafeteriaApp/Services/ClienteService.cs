using CafeteriaApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaApp.Services;

public class ClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Cliente?>> ObterTodosClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task AdicionarCliente(Cliente? cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");
        }
        
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
           
    }

    public async Task<Cliente?> ObterClientePorId(int id)
    {
        if (id > 0)
        {
            return await _context.Clientes.FindAsync(id);
        }
        else
        {
            throw new ArgumentNullException("Id não pode ser 0");
        }
    }
    

    public async Task<Cliente?> ObterClientePorNome(string? nome)
    {
        if (nome != null)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Nome == nome);
        }
        else
        {
            throw new ArgumentNullException("Nome não pode estar vazio");
        }
        
        
    }

    public async void AtualizarCliente(Cliente? cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentException(nameof(cliente), "Cliente não pode ser nulo");
        }
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Cliente não encontrado");
        }
    }
}