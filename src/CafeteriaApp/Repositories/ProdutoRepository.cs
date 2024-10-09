using CafeteriaApp.Models.Entities;
using Npgsql;

namespace CafeteriaApp.Repositories;

public class ProdutoRepository
{
    private readonly string _connectionString = "Host=postgres;Username=Guislotti;Password=504030;Database=cafeteria";

    public void AdicionarProduto(Produto produto)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            string query = "INSERT INTO produtos (nome, quantidadeestoque) VALUES (@nome, @QuantidadeEstoque)";
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("Nome", produto.Nome);
                cmd.Parameters.AddWithValue("QuantidadeEstoque", produto.QuantidadeEmEstoque);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Produto BuscarProdutoPorId(int id)
    {
        Produto produto = null;
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM produtos WHERE id = @id";
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        produto = new Produto
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            QuantidadeEmEstoque = reader.GetInt32(2)
                        };
                    }
                }
            }
        }
        return produto;
    }
}
