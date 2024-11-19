using System.Collections.Generic;
using System.Threading;
using System;

public class JUPITER
{
    static List<Produto> listaProdutos = new List<Produto>();
    static List<int> listaAtualizada = new List<int>();
    static string senha = "";

    public static void Main()
    {
        bool produtos = false;
        while (true)
        {

            Console.WriteLine("--------------------------BEM-VINDO AO--------------------------");
            Console.WriteLine("");
            Console.WriteLine(Logo());

            if (senha == "")
            {
                Console.WriteLine("INFORME A SUA SENHA DE ADMINISTRADOR!");
                senha = Console.ReadLine();
                Console.Clear();
            }
            else if (!produtos)
            {
                produtos = true;
                Console.WriteLine("----------------------ADICIONANDO OS PRODUTOS----------------------");
                Console.WriteLine(".");
                Thread.Sleep(1000);
                Console.WriteLine("..");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(1000);
                AdicionarProduto(1, "Caixa de Bolete", 10);
                AdicionarProduto(2, "Pirulitos un.", 30);
                AdicionarProduto(3, "Heineken", 6);
                AdicionarProduto(4, "Doce de leite", 20);
                AdicionarProduto(5, "Cigarro", 3);
                AdicionarProduto(6, "Paçoca", 15);
                AdicionarProduto(7, "Água 500ml", 10);
                AdicionarProduto(8, "Coca-cola 2Lt", 4);
                Console.Clear();
                Console.WriteLine("PRODUTOS ADICIONADOS!");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar......");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar...");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar..");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------PAINEL DE CONTROLE-----------");
                Console.WriteLine("");
                Console.WriteLine("[1] - Vender Produto");
                Console.WriteLine("[2] - Listar de produtos");
                Console.WriteLine("[3] - Alterar Senha");
                Console.WriteLine("[4] - Fechar Caixa");

                int decisao = int.Parse(Console.ReadLine());

                switch (decisao)
                {
                    case 1:
                        VenderProduto();
                        break;
                    case 2:
                        ExibirProdutos();
                        break;
                    case 3:
                        AlterarSenha();
                        break;
                    case 4:
                        FecharCaixa();
                        break;
                    default:
                        break;
                }

                //-------------------

                //1 - COLOCAR O ID DO PRODUTO E DIMINUIR A QUANTIDADE, SE O ID NÃO EXISTE, MOSTRAR UMA MENSAGEM DE ERRO
                //2 - LISTAR OS PRODUTOS COM A QUANTIDADE ATUALIZADA
                //3 - ALTERAR A SENHA, PARA ALTERAR DEVE PEDIR A SENHA ANTIGA, SE ESTIVER INCORRETO DAR UM AVISO
                //4 - PARA FECHAR O CAIXA DEVE SER INSERIDO A SENHA ATUAL, MOSTRAR A LISTA DE PRODUTOS
                // COM A QUANTIDADE ATUALZIADA E DEPOIS DE 20 SEGUNDOS FINALIZAR O PROGRAMA
            }

        }
    }

    public static string Logo()
    {
        string logo = "   JJJJJJJJ  U     U  PPPPPPP   II  TTTTTTTT  EEEEEEE  RRRRRRR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PPPPPPP   II     TT     EEEEE    RRRRRRR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR RR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR   RR\n";
        logo += " JJJJJJ       UUUUU   PP        II     TT     EEEEEEE  RR    RR\n";
        logo += "\n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";
        logo += "          33    33  00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          3333333   00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          33    33  00    00  00    00 00    00     \n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";

        return logo;
    }
    static void AdicionarProduto(int id, string nome, int quantidade)
    {
        Produto produto = new Produto(id, nome, quantidade);
        listaProdutos.Add(produto);
    }

    static void VenderProduto()
    {
        Console.WriteLine("Digite o código do produto: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a quantidade desejada: ");
        int quantidade = int.Parse(Console.ReadLine());

        int index = listaProdutos.FindIndex(x => x.Id == id);

        if (index == -1)
        {
            Console.WriteLine("Não existe esse produto!");
            return;
        }

        int quantidadeLista = listaProdutos[index].Quantidade;
        if (quantidadeLista >= quantidade)
        {
            listaProdutos[index].Quantidade = quantidadeLista - quantidade;
        }
        else
        {
            Console.WriteLine("Não tem em estoque a quantidade solicitado.");
        }

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    static void ExibirProdutos()
    {
        foreach (var item in listaProdutos)
        {
            Console.WriteLine($"Nome do Produto: {item.Nome} - Quantidade Atualizada: {item.Quantidade.ToString()}");
        }

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();

    }

    static void AlterarSenha()
    {
        Console.WriteLine("Digite sua senha antiga: ");
        string senha_antiga = Console.ReadLine();

        if (senha_antiga == senha)
        {
            Console.WriteLine("Inserir a nova senha: ");
            string nova_senha = Console.ReadLine();

            Console.WriteLine("Repetir a nova senha: ");
            string repetir_senha = Console.ReadLine();

            if (nova_senha == repetir_senha)
            {
                Console.WriteLine("Sua senha foi alterada com sucesso!");
            }
            else
            {
                Console.WriteLine("A senha digitada não corresponde à senha anterior. Por favor, tente novamente.");
            }

        }
        else
        {
            Console.WriteLine("A senha atual não corresponde à registrada. Por favor, tente novamente.");
        }

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();


    }

    static void FecharCaixa()
    {
        int i = 0;
        bool acesso = false;
        while (i < 3)
        {
            Console.WriteLine("Digite sua senha atual: ");
            string senha_atual = Console.ReadLine();

            if (senha == senha_atual)
            {
                acesso = true;
                break;
            }

            if (i == 2)
            {
                Console.WriteLine("Você tentou inserir a senha incorreta três vezes. Tente novamente mais tarde.");
                i++;
            }
            Console.WriteLine("Senha incorreta. Por favor, digite novamente.");
            i++;
        }

        if (acesso == true)
        {
            foreach (var list in listaProdutos)
            {
                Console.WriteLine($"Nome produto: {list.Nome} - Quantidade: {list.Quantidade}");
            }

            Console.WriteLine("\n\n Fechando o caixa aguarde...");
            Thread.Sleep(20000);

            Console.WriteLine("Caixa fechado com sucesso.");
            Environment.Exit(0);
        }

        Console.ReadLine();
    }
}
class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, int quantidade)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
    }
}