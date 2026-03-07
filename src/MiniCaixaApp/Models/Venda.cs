namespace MiniCaixaApp.Models;

public class Venda
{
    public int Id { get; set; }
    public Produto Produto { get; set; } = new Produto();
    public int Quantidade { get; set; }
    public decimal Total { get; set; }
    public DateTime Data { get; set; }
}