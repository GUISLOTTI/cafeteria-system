using CafeteriaApp.Domain;
using CafeteriaApp.Services;

namespace CafeteriaApp;

using System;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            // Criação do serviço
            var clienteService = new ClienteService(context);

            // Adicionando um novo cliente
            var novoCliente = new Cliente
            {
                Nome = "João da Silva",
                Telefone = "1234-5678",
                SaldoDevedor = 0m
            };

            clienteService.AdicionarCliente(novoCliente);
            Console.WriteLine("Cliente adicionado com sucesso!");

            // Listando todos os clientes
            var clientes = clienteService.ObterClientePorId();
            Console.WriteLine("Clientes cadastrados:");
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Telefone: {cliente.Telefone}, Saldo Devedor: {cliente.SaldoDevedor}");
            }
        }
    }
}
