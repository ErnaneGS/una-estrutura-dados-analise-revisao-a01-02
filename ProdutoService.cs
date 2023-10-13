using System;
using System.Globalization;

class ProdutoService
{

    public static void Adicionar(List<Produto> produtos)
    {
        Produto produto = new Produto();
        produto = ReceberDadosProduto(produto);
        produtos.Add(produto);
        Console.WriteLine("PRODUTO CADASTRADO COM SUCESSO!");
    }

    public static void Atualizar(List<Produto> produtos)
    {
        Console.WriteLine(" - Informe o código de barras do produto que deseja atualizar:");
        int codigo;
        int.TryParse(Console.ReadLine(), out codigo);

        Produto produtoParaAtualizar = produtos.FirstOrDefault(p => p.Codigo == codigo);

        if (produtoParaAtualizar == null)
        {
            Console.WriteLine("Produto não encontrado com este código.");
        }
        else
        {
            Console.WriteLine("Atualize as informações do produto:");
            produtoParaAtualizar = ReceberDadosProduto(produtoParaAtualizar);

            Console.WriteLine("PRODUTO ATUALIZADO COM SUCESSO!");
        }
    }

    public static void Buscar(List<Produto> produtos)
    {
        Console.WriteLine("Escolha uma opção de busca:");
        Console.WriteLine("1 - Buscar por nome");
        Console.WriteLine("2 - Buscar por código de barras");
        Console.WriteLine("3 - Buscar por data de validade");
        string opcaoBusca = Console.ReadLine();

        switch (opcaoBusca)
        {
            case "1":
                Console.WriteLine(" - Informe o nome do produto a ser pesquisado:");
                string nomeBusca = Console.ReadLine();
                List<Produto> produtosEncontradosNome = produtos.Where(p => p.Nome.Contains(nomeBusca)).ToList();
                ImprimirListaDeProdutos(produtosEncontradosNome);
                break;
            case "2":
                Console.WriteLine(" - Informe o código de barras do produto a ser pesquisado:");
                int codigoBusca;
                int.TryParse(Console.ReadLine(), out codigoBusca);
                Produto produtoEncontradoCodigo = produtos.FirstOrDefault(p => p.Codigo == codigoBusca);
                if (produtoEncontradoCodigo != null)
                {
                    Console.WriteLine("Produto encontrado:");
                    ImprimirProduto(produtoEncontradoCodigo);
                }
                else
                {
                    Console.WriteLine("Produto não encontrado com este código.");
                }
                break;
            case "3":
                Console.WriteLine("Informe a data de validade (no formato dd/mm/aaaa) para pesquisar produtos:");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataBusca))
                {
                    List<Produto> produtosEncontradosData = produtos.Where(p => p.DataValidade <= dataBusca).ToList();
                    ImprimirListaDeProdutos(produtosEncontradosData);
                }
                else
                {
                    Console.WriteLine("Data de pesquisa inválida. Use o formato dd/mm/aaaa.");
                }
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    public static void CalcularTotalEstoque(List<Produto> produtos)
    {
        Console.WriteLine("\nTest:");
    }

    public static void RelatorioValidadeProdutos(List<Produto> produtos)
    {
        Console.WriteLine("\nTest:");
    }

    public static Produto ReceberDadosProduto(Produto produto)
    {
        string nome;
        int codigo;
        int quantidade;
        decimal precoUnitario;
        DateTime dataValidade;

        do
        {
            Console.WriteLine(" - Informe o nome do produto a ser adicionado ao estoque:");
            nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Erro: O nome do produto não pode ser vazio. Por favor, insira um nome válido.");
            }
        } while (string.IsNullOrEmpty(nome));

        do
        {
            Console.WriteLine(" - Informe o código de barras do produto:");
            if (!int.TryParse(Console.ReadLine(), out codigo))
            {
                Console.WriteLine("Erro: O código deve ser um número inteiro.");
            }
        } while (codigo <= 0);

        do
        {
            Console.WriteLine(" - Informe a quantidade disponível:");
            if (!int.TryParse(Console.ReadLine(), out quantidade))
            {
                Console.WriteLine("Erro: A quantidade disponível deve ser um número inteiro.");
            }
        } while (quantidade <= 0);

        do
        {
            Console.WriteLine(" - Informe o preço unitário:");
            if (!decimal.TryParse(Console.ReadLine(), out precoUnitario))
            {
                Console.WriteLine("Erro: O preço unitário deve ser um número decimal.");
            }
        } while (precoUnitario <= 0);

        do
        {
            Console.WriteLine(" - Informe a data de validade (no formato dd/mm/aaaa):");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataValidade))
            {
                Console.WriteLine("Erro: Data de validade inválida. Use o formato dd/mm/aaaa.");
            }
        } while (dataValidade <= DateTime.Now);

        produto.Nome = nome;
        produto.Codigo = codigo;
        produto.Quantidade = quantidade;
        produto.PrecoUnitario = precoUnitario;
        produto.DataValidade = dataValidade;

        return produto;
    }

    public static void ImprimirListaDeProdutos(List<Produto> produtos)
    {
        if (produtos.Count == 0)
        {
            Console.WriteLine("Não foi encontrado produtos com estas infomações.");
            return;
        }

        Console.WriteLine("Produtos encontrados:");
        foreach (var produto in produtos)
        {
            ImprimirProduto(produto);
        }
    }

    public static void ImprimirProduto(Produto produto)
    {
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("-- Nome: " + produto.Nome);
        Console.WriteLine("-- Código de Barras: " + produto.Codigo);
        Console.WriteLine("-- Quantidade Disponível: " + produto.Quantidade);
        Console.WriteLine("-- Preço Unitário: R$" + produto.PrecoUnitario.ToString("F2"));
        Console.WriteLine("-- Data de Validade: " + produto.DataValidade.ToString("dd/MM/yyyy"));
        Console.WriteLine("--------------------------------------------------------------------");
    }
}