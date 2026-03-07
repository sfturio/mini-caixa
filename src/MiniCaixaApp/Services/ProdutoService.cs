using MiniCaixaApp.Interfaces;
using MiniCaixaApp.Models;

namespace MiniCaixaApp.Services;

public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _produtos;

    public ProdutoService(List<Produto> produtos)
    {
        _produtos = produtos;
    }

    public void ListarProdutos()
    {
        Console.WriteLine("\n--- PRODUTOS ---");

        foreach (var produto in _produtos)
        {
            Console.WriteLine(
                $"ID: {produto.Id} | Nome: {produto.Nome} | Preço: R$ {produto.Preco:F2} | Estoque: {produto.Estoque}"
            );
        }
    }

    public Produto? BuscarPorId(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }
}