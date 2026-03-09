using Microsoft.Extensions.DependencyInjection;
using MiniCaixaApp.Controllers;
using MiniCaixaApp.Interfaces;
using MiniCaixaApp.Models;
using MiniCaixaApp.Repositories;
using MiniCaixaApp.Services;

namespace MiniCaixaApp;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();

        services.AddSingleton(new List<Produto>
        {
            new Produto { Id = 1, Nome = "Coca 2L", Preco = 10.00m, Estoque = 10 },
            new Produto { Id = 2, Nome = "Pao", Preco = 1.50m, Estoque = 50 },
            new Produto { Id = 3, Nome = "Chocolate", Preco = 6.75m, Estoque = 20 }
        });

        services.AddSingleton<IProdutoRepository, ProdutoRepository>();
        services.AddSingleton<IVendaRepository, VendaRepository>();

        services.AddSingleton<IProdutoService, ProdutoService>();
        services.AddSingleton<IVendaService, VendaService>();

        services.AddSingleton<CaixaController>();

        using ServiceProvider provider = services.BuildServiceProvider();
        var controller = provider.GetRequiredService<CaixaController>();

        bool rodando = true;

        while (rodando)
        {
            Console.WriteLine("\n=== MINI CAIXA ===");
            Console.WriteLine("1 - Listar produtos");
            Console.WriteLine("2 - Registrar venda");
            Console.WriteLine("3 - Listar vendas");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    controller.ListarProdutos();
                    break;

                case "2":
                    controller.RegistrarVenda();
                    break;

                case "3":
                    controller.ListarVendas();
                    break;

                case "0":
                    rodando = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}