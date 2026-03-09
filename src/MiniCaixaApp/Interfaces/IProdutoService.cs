using MiniCaixaApp.Models;

namespace MiniCaixaApp.Interfaces;

public interface IProdutoService
{
    void ListarProdutos();
    Produto? BuscarPorId(int id);
}