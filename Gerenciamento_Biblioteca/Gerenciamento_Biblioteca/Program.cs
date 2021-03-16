using System;
using System.Collections.Generic;

namespace Gerenciamento_Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {

            int op;

            do
            {
                List<Cliente> listaCliente = Cliente_Servicos.RetornarTodos();
                List<Livro> listaLivro = Livro_Servicos.RetornarTodos();
                List<Emprestimo> listaEmprestimo = Emprestimo_Servicos.RetornarTodos();

                Menu();
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Cliente_Servicos.CadastroCliente(listaCliente);
                        break;
                    case 2:
                        Livro_Servicos.CadastroLivro(listaLivro);
                        break;
                    case 3:
                        Emprestimo_Servicos.CadastroEmprestimo(listaEmprestimo, listaCliente, listaLivro);
                        break;
                    case 4:
                        Devolucao_Servicos.CadastroDevolucao(listaEmprestimo, listaLivro);
                        break;
                    case 5:
                        Relatorio_Servicos.RetornarRelatorio();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            } while (op != 0);
        }

        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Gerenciamento de Bibliotecas - Rick9141");
            Console.WriteLine();
            Console.Write("=========Menu=========\n" +
                "(1) - Cadastrar Cliente\n" +
                "(2) - Cadastrar Livro\n" +
                "(3) - Cadastrar Emprestimo\n" +
                "(4) - Cadastrar Devolução\n" +
                "(5) - Relatorio de Emprestimos e Devoluções\n" +
                "(0) - Sair\n" +
                "Digite a opção desejada:");
        }
    }
}
