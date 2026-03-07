using MiniCaixaApp.Interfaces;
using MiniCaixaApp.Models;

namespace MiniCaixaApp.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produtos;

    public ProdutoRepository(List<Produto> produtos)
    {
        _produtos = produtos;
    }

    public List<Produto> ListarTodos()
    {
        return _produtos;
    }

    public Produto? BuscarPorId(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }
}