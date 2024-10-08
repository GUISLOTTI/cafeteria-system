namespace CafeteriaApp.Domain;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int QuantidadeEmEstoque { get; set; }
    public int PrecoUnitario { get; set; }
}