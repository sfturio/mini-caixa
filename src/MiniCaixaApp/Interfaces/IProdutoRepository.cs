using MiniCaixaApp.Models;

namespace MiniCaixaApp.Interfaces;

public interface IProdutoRepository
{
    List<Produto> ListarTodos();
    Produto? BuscarPorId(int id);
}