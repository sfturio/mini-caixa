using MiniCaixaApp.Interfaces;
using MiniCaixaApp.Models;

namespace MiniCaixaApp.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly List<Venda> _vendas = new();

    public void Adicionar(Venda venda)
    {
        _vendas.Add(venda);
    }

    public List<Venda> ListarTodas()
    {
        return _vendas;
    }
}