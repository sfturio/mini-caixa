using System;

class Program
{
    static void Main()
    {
        Produto p1 = new Produto();
        p1.Id = 1;
        p1.Nome = "Coca 2L";
        p1.Preco = 10.00m;
        p1.Estoque = 10;

        Produto p2 = new Produto();
        p2.Id = 2;
        p2.Nome = "Pao";
        p2.Preco = 1.50m;
        p2.Estoque = 50;

        Produto p3 = new Produto();
        p3.Id = 3;
        p3.Nome = "Chocolate";
        p3.Preco = 6.75m;
        p3.Estoque = 20;

        // “Banco de dados” simples: no máximo 50 vendas
        Venda[] vendas = new Venda[50];
        int vendasCount = 0;
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

            string op = Console.ReadLine();

            if (op == "1")
            {
                MostrarProduto(p1);
                MostrarProduto(p2);
                MostrarProduto(p3);
            }
            else if (op == "2")
            {
                Console.Write("Id do produto (1/2/3): ");
                string sId = Console.ReadLine();

                int idProd = 0;
                bool okId = int.TryParse(sId, out idProd);
                if (!okId)
                {
                    Console.WriteLine("Id invalido.");
                    continue;
                }

                Produto prodEscolhido = null;

                if (idProd == 1) prodEscolhido = p1;
                if (idProd == 2) prodEscolhido = p2;
                if (idProd == 3) prodEscolhido = p3;

                if (prodEscolhido == null)
                {
                    Console.WriteLine("Produto nao existe.");
                    continue;
                }

                Console.Write("Quantidade: ");
                string sQtd = Console.ReadLine();
                int qtd = 0;
                bool okQtd = int.TryParse(sQtd, out qtd);

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

                // regra simples e feia de desconto
                decimal desconto = 0m;
                if (subtotal >= 50m)
                {
                    desconto = subtotal * 0.10m; // 10%
                }
                else if (subtotal >= 20m)
                {
                    desconto = subtotal * 0.05m; // 5%
                }
                else
                {
                    desconto = 0m;
                }

                decimal total = subtotal - desconto;

                // baixa estoque
                prodEscolhido.Estoque = prodEscolhido.Estoque - qtd;

                // salva venda no array
                if (vendasCount >= vendas.Length)
                {
                    Console.WriteLine("Limite de vendas atingido (array cheio).");
                    continue;
                }

                Venda v = new Venda();
                v.IdVenda = proxIdVenda;
                v.ProdutoId = prodEscolhido.Id;
                v.ProdutoNome = prodEscolhido.Nome;
                v.Quantidade = qtd;
                v.PrecoUnit = prodEscolhido.Preco;
                v.Subtotal = subtotal;
                v.Desconto = desconto;
                v.Total = total;

                vendas[vendasCount] = v;
                vendasCount = vendasCount + 1;
                proxIdVenda = proxIdVenda + 1;

                Console.WriteLine("Venda feita! Total: R$ " + total);
            }
            else if (op == "3")
            {
                Console.WriteLine("\n=== RELATORIO FEIO ===");

                decimal somaTotal = 0m;
                decimal somaDescontos = 0m;
                int somaItens = 0;

                int i = 0;
                while (i < vendasCount)
                {
                    Venda v = vendas[i];
                    if (v != null)
                    {
                        Console.WriteLine(
                            "Venda #" + v.IdVenda +
                            " | " + v.ProdutoNome +
                            " | qtd " + v.Quantidade +
                            " | total R$ " + v.Total
                        );

                        somaTotal = somaTotal + v.Total;
                        somaDescontos = somaDescontos + v.Desconto;
                        somaItens = somaItens + v.Quantidade;
                    }
                    i = i + 1;
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