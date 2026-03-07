using MiniCaixaApp.Interfaces;

namespace MiniCaixaApp.Controllers;

public class CaixaController
{
    private readonly IProdutoService _produtoService;
    private readonly IVendaService _vendaService;

    public CaixaController(IProdutoService produtoService, IVendaService vendaService)
    {
        _produtoService = produtoService;
        _vendaService = vendaService;
    }

    public void ListarProdutos()
    {
        _produtoService.ListarProdutos();
    }

    public void RegistrarVenda()
    {
        Console.Write("Id do produto: ");
        bool idValido = int.TryParse(Console.ReadLine(), out int produtoId);

        Console.Write("Quantidade: ");
        bool qtdValida = int.TryParse(Console.ReadLine(), out int quantidade);

        if (!idValido || !qtdValida)
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        _vendaService.RegistrarVenda(produtoId, quantidade);
    }

    public void ListarVendas()
    {
        _vendaService.ListarVendas();
    }
}