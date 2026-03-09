using MiniCaixaApp.Interfaces;
using MiniCaixaApp.Models;

namespace MiniCaixaApp.Services;

public class VendaService : IVendaService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IVendaRepository _vendaRepository;
    private int _proxIdVenda = 1;

    public VendaService(IProdutoRepository produtoRepository, IVendaRepository vendaRepository)
    {
        _produtoRepository = produtoRepository;
        _vendaRepository = vendaRepository;
    }

    public bool RegistrarVenda(int produtoId, int quantidade)
    {
        var produto = _produtoRepository.BuscarPorId(produtoId);

        if (produto is null)
        {
            Console.WriteLine("Produto não encontrado.");
            return false;
        }

        if (quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida.");
            return false;
        }

        if (produto.Estoque < quantidade)
        {
            Console.WriteLine("Estoque insuficiente.");
            return false;
        }

        produto.Estoque -= quantidade;

        var venda = new Venda
        {
            Id = _proxIdVenda++,
            Produto = produto,
            Quantidade = quantidade,
            Total = produto.Preco * quantidade,
            Data = DateTime.Now
        };

        _vendaRepository.Adicionar(venda);

        Console.WriteLine("Venda registrada com sucesso.");
        return true;
    }

    public void ListarVendas()
    {
        var vendas = _vendaRepository
            .ListarTodas()
            .OrderByDescending(v => v.Data)
            .ToList();

        Console.WriteLine("\n--- VENDAS ---");

        if (!vendas.Any())
        {
            Console.WriteLine("Nenhuma venda registrada.");
            return;
        }

        foreach (var venda in vendas)
        {
            Console.WriteLine(
                $"Venda #{venda.Id} | Produto: {venda.Produto.Nome} | Qtd: {venda.Quantidade} | Total: R$ {venda.Total:F2} | Data: {venda.Data:dd/MM/yyyy HH:mm}");
        }

        Console.WriteLine($"\nTotal de vendas: {vendas.Count}");
        Console.WriteLine($"Faturamento total: R$ {vendas.Sum(v => v.Total):F2}");
        Console.WriteLine($"Produto mais vendido: {vendas.GroupBy(v => v.Produto.Nome).OrderByDescending(g => g.Sum(v => v.Quantidade)).Select(g => g.Key).FirstOrDefault()}");
    }
}