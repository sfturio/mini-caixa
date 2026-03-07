using System.Collections.Generic;

namespace MiniCaixaApp;
public class Produto
{
    public int Id { get; private set;}
    public string Nome { get; private set;}
    public decimal Preco {get; private set;}
    public int Estoque {get; private set;}
    public Produto(int id, string nome, decimall preco, int estoque)
    {
        if (id <= 0)
        throw new ArgumentException ("id inválido.");
        if (string.IsNullOrWhiteSpace(nome))
        throw new ArgumentException("Nome inválido.");
        if (preco < 0)
        throw new ArgumentException("Preço não pode ser negativo.");
        if (estoque < 0)
        throw new ArgumentException("Estoque não pode ser negativo.");
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }
    public void BaixarEstoque(int quantidade)
    {
        if (quantidade <= 0)
        throw new ArgumentException("Quantidade inválida.");
        if (quantidade > Estoque)
        throw new InvalidOperationException("Estoque insuficiente.");
        Estoque -= quantidade;
    }
    public void AdicionarEstoque(int quantidade)
    {
        if (quantidade <= 0)
        throw new ArgumentException("Quantidade inválida.");
        Estoque += quantidade;
    }
    public void AlterarPreco (decimal novoPreco)
    {
        if (novoPreco < 0)
        throw new ArgumentException("Preço inválido.");
        Preco = novoPreco;
    }
}