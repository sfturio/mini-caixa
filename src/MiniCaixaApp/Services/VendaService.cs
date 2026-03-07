using MiniCaixaApp.Interfaces;
using MiniCaixaApp.Models;

namespace MiniCaixaApp.Services;

public class VendaService : IVendaService
{
    private readonly IProdutoService _produtoService;
    private readonly List<Venda> _vendas = new();
    private int _proxIdVenda = 1;

    public VendaService(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public bool RegistrarVenda(int produtoId, int quantidade)
    {
        var produto = _produtoService.BuscarPorId(produtoId);

        if (produto == null)
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

        _vendas.Add(venda);

        Console.WriteLine("Venda registrada com sucesso.");
        return true;
    }

    public void ListarVendas()
    {
        Console.WriteLine("\n--- VENDAS ---");

        if (_vendas.Count == 0)
        {
            Console.WriteLine("Nenhuma venda registrada.");
            return;
        }

        foreach (var venda in _vendas)
        {
            Console.WriteLine(
                $"Venda #{venda.Id} | Produto: {venda.Produto.Nome} | Qtd: {venda.Quantidade} | Total: R$ {venda.Total:F2} | Data: {venda.Data:dd/MM/yyyy HH:mm}"
            );
        }
    }
}