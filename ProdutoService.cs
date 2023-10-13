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
    }

    public static void Buscar(List<Produto> produtos)
    {
    }

    public static void CalcularTotalEstoque(List<Produto> produtos)
    {
    }

    public static void RelatorioValidadeProdutos(List<Produto> produtos)
    {
    }

    public static Produto ReceberDadosProduto(Produto produto)
    {
        string nome;
        string codigo;
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
            codigo = Console.ReadLine();

            if (string.IsNullOrEmpty(codigo))
            {
                Console.WriteLine("Erro: O código de barras não pode ser vazio. Por favor, insira um código válido.");
            }
        } while (string.IsNullOrEmpty(codigo));

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
        produto.Quantidade = quantidade;
        produto.PrecoUnitario = precoUnitario;
        produto.DataValidade = dataValidade;

        return produto;
    }

    public static void ImprimirListaDeProdutos(List<Produto> produtos)
    {
    }

    public static void ImprimirProduto(Produto produto)
    {
    }
}