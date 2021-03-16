using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Gerenciamento_Biblioteca
{

    class Emprestimo_Servicos
    {    
        public static void CadastroEmprestimo(List<Emprestimo> lista, List<Cliente> listaCliente, List<Livro> listaLivro)
        {

            var livroIsbn = Ler_Campos.Ler("Informe o numero ISBN do Livro", 13, 0);


            while (!listaLivro.Any(x => x.Isbn == livroIsbn))
            {
                Console.WriteLine("Livro inexistente ou indisponivel para empréstimo no momento!");
                livroIsbn = Ler_Campos.Ler("Informe o numero ISBN do Livro", 13, 0);
            }

            var verifCpf = Ler_Campos.Ler("Informe o numero do seu CPF", 11, 0);

            while (!listaCliente.Any(x => x.Cpf == verifCpf))
            {
                Console.WriteLine("Cliente não cadastrado!");
                verifCpf = Ler_Campos.Ler("Informe o numero do seu CPF", 11, 0);
            }

            Emprestimo novoEmprestimo = new Emprestimo()
           
            {

                IdCliente = listaCliente.Where(x => x.Cpf == verifCpf).FirstOrDefault().IdCliente,
                NumeroTombo = listaLivro.Where(x => x.Isbn == livroIsbn).FirstOrDefault().NumeroTombo,
                DataEmprestimo = DateTime.Now,
                DataDevolucao = Ler_Campos.Ler("Data de Devolucao", 10, 1),
                StatusEmprestimo = 1

            };

            lista.Add(novoEmprestimo);
            Console.Clear();

            using (var writer = new StreamWriter(@"C:\Arquivos\Emprestimo.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(lista);
            }

        }


        public static List<Emprestimo> RetornarTodos()
        {
            List<Emprestimo> lista = new List<Emprestimo>();
            if (File.Exists(@"C:\Arquivos\Emprestimo.csv"))
            {
                using (var reader = new StreamReader(@"C:\Arquivos\Emprestimo.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Emprestimo>();
                    foreach (var r in records)
                    {
                        lista.Add(r);
                    }
                }
            }
            return lista;
        }
    }
}
