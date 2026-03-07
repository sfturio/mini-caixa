using MiniCaixaApp.Models;

namespace MiniCaixaApp.Interfaces;

public interface IVendaRepository
{
    void Adicionar(Venda venda);
    List<Venda> ListarTodas();
}