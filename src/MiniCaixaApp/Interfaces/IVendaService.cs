namespace MiniCaixaApp.Interfaces;

public interface IVendaService
{
    bool RegistrarVenda(int produtoId, int quantidade);
    void ListarVendas();
}