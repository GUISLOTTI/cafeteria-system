namespace CafeteriaApp.Domain;

public class Cliente
{
    public int Id { get; set; } 
    public string Nome { get; set; } 
    public string Telefone { get; set; } 
    public decimal SaldoDevedor { get; set; }
}
