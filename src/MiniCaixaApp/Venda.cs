namespace MiniCaixaApp;

public class Venda
{
    public int IdVenda { get; private set; }
    public int ProdutoId { get; private set; }
    public string ProdutoNome { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnit { get; private set; }
    public decimal Subtotal { get; private set; }
    public decimal Desconto { get; private set; }
    public decimal Total { get; private set; }

    public Venda(int idVenda, Produto produto, int quantidade, decimal desconto)
    {
        if (idVenda <= 0)
            throw new ArgumentException("Id da venda inválido.");

        if (produto == null)
            throw new ArgumentNullException(nameof(produto));

        if (quantidade <= 0)
            throw new ArgumentException("Quantidade inválida.");

        if (desconto < 0)
            throw new ArgumentException("Desconto inválido.");

        IdVenda = idVenda;
        ProdutoId = produto.Id;
        ProdutoNome = produto.Nome;
        Quantidade = quantidade;
        PrecoUnit = produto.Preco;
        Subtotal = produto.Preco * quantidade;
        Desconto = desconto;
        Total = Subtotal - Desconto;
    }
}