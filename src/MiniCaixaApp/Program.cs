using System;
using System.Collections.Generic;

namespace MiniCaixaApp;

class Program
{
    static void Main()
    {
        Produto p1 = new Produto(1, "Coca 2L", 10.00m, 10);
        Produto p2 = new Produto(2, "Pao", 1.50m, 50);
        Produto p3 = new Produto(3, "Chocolate", 6.75m, 20);

        List<Venda> vendas = new List<Venda>();
        int proxIdVenda = 1;

        bool rodando = true;

        while (rodando)
        {
            Console.WriteLine("\n=== MINI CAIXA FEIO ===");
            Console.WriteLine("1 - Ver produtos");
            Console.WriteLine("2 - Vender");
            Console.WriteLine("3 - Relatorio");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            string? op = Console.ReadLine();

            if (op == "1")
            {
                MostrarProduto(p1);
                MostrarProduto(p2);
                MostrarProduto(p3);
            }
            else if (op == "2")
            {
                Console.Write("Id do produto (1/2/3): ");
                string? sId = Console.ReadLine();

                bool okId = int.TryParse(sId, out int idProd);
                if (!okId)
                {
                    Console.WriteLine("Id invalido.");
                    continue;
                }

                Produto? prodEscolhido = null;

                if (idProd == 1) prodEscolhido = p1;
                if (idProd == 2) prodEscolhido = p2;
                if (idProd == 3) prodEscolhido = p3;

                if (prodEscolhido == null)
                {
                    Console.WriteLine("Produto nao existe.");
                    continue;
                }

                Console.Write("Quantidade: ");
                string? sQtd = Console.ReadLine();

                bool okQtd = int.TryParse(sQtd, out int qtd);
                if (!okQtd || qtd <= 0)
                {
                    Console.WriteLine("Quantidade invalida.");
                    continue;
                }

                if (qtd > prodEscolhido.Estoque)
                {
                    Console.WriteLine("Sem estoque suficiente. Estoque atual: " + prodEscolhido.Estoque);
                    continue;
                }

                decimal subtotal = prodEscolhido.Preco * qtd;

                decimal desconto = 0m;
                if (subtotal >= 50m)
                {
                    desconto = subtotal * 0.10m;
                }
                else if (subtotal >= 20m)
                {
                    desconto = subtotal * 0.05m;
                }

                prodEscolhido.BaixarEstoque(qtd);

                Venda v = new Venda(proxIdVenda, prodEscolhido, qtd, desconto);

                vendas.Add(v);
                proxIdVenda++;

                Console.WriteLine("Venda feita! Total: R$ " + v.Total);
            }
            else if (op == "3")
            {
                Console.WriteLine("\n=== RELATORIO FEIO ===");

                decimal somaTotal = 0m;
                decimal somaDescontos = 0m;
                int somaItens = 0;

                foreach (Venda v in vendas)
                {
                    Console.WriteLine(
                        "Venda #" + v.IdVenda +
                        " | " + v.ProdutoNome +
                        " | qtd " + v.Quantidade +
                        " | total R$ " + v.Total
                    );

                    somaTotal += v.Total;
                    somaDescontos += v.Desconto;
                    somaItens += v.Quantidade;
                }

                Console.WriteLine("Itens vendidos: " + somaItens);
                Console.WriteLine("Descontos dados: R$ " + somaDescontos);
                Console.WriteLine("Faturamento: R$ " + somaTotal);

                Console.WriteLine("\nEstoque atual:");
                MostrarProduto(p1);
                MostrarProduto(p2);
                MostrarProduto(p3);
            }
            else if (op == "0")
            {
                rodando = false;
            }
            else
            {
                Console.WriteLine("Opcao invalida.");
            }
        }

        Console.WriteLine("Fim.");
    }

    static void MostrarProduto(Produto p)
    {
        Console.WriteLine(
            "Id: " + p.Id +
            " | " + p.Nome +
            " | R$ " + p.Preco +
            " | estoque: " + p.Estoque
        );
    }
}