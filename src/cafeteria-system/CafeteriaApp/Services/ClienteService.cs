using CafeteriaApp.Domain;

namespace CafeteriaApp.Services;

public class ClienteService
{
    private readonly AppDbContext _context;

    public ClienteService(AppDbContext context)
    {
        _context = context;
    }

    public void AdicionarCliente(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");
        }
        
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
           
    }

    public Cliente ObterClientePorId(int id)
    {
        return _context.Clientes.Find(id);
    }

    public void AtualizarCliente(Cliente cliente)
    {
        if (cliente == null)
        {
            throw new ArgumentException(nameof(cliente), "Cliente não pode ser nulo");
        }
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }

    public void ExcluirCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("Cliente não encontrado");
        }
    }
}