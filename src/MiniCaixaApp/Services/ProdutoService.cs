using MiniCaixaApp.Interfaces;
using MiniCaixaApp.Models;

namespace MiniCaixaApp.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public void ListarProdutos()
    {
        var produtos = _produtoRepository
            .ListarTodos()
            .OrderBy(p => p.Nome)
            .ToList();

        Console.WriteLine("\n--- PRODUTOS ---");

        foreach (var produto in produtos)
        {
            Console.WriteLine(
                $"ID: {produto.Id} | Nome: {produto.Nome} | Preço: R$ {produto.Preco:F2} | Estoque: {produto.Estoque}");
        }
    }

    public Produto? BuscarPorId(int id)
    {
        return _produtoRepository.BuscarPorId(id);
    }
}