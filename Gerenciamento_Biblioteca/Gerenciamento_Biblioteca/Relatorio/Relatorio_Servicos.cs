using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Gerenciamento_Biblioteca
{
    class Relatorio_Servicos
    {
        public static List<Emprestimo> RetornarRelatorio()
        {
            var clientes = Cliente_Servicos.RetornarTodos();
            var livros = Livro_Servicos.RetornarTodos();

            List<Emprestimo> lista = new List<Emprestimo>();
            if (File.Exists(@"C:\Arquivos\Emprestimo.csv"))
            {
                using (var reader = new StreamReader(@"C:\Arquivos\Emprestimo.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Emprestimo>();
                    foreach (var r in records)
                    {
                        var cliente = clientes.Where(x => x.IdCliente == r.IdCliente).FirstOrDefault();
                        var livro = livros.Where(x => x.NumeroTombo == r.NumeroTombo).FirstOrDefault();
                        var status = r.StatusEmprestimo == 1 ? "Emprestado" : "Devolvido";
                        Console.Clear();
                        Console.WriteLine("\nRelatorio de Emprestimos e Devolucoes\n\n" +
                                          "\nCPF:" + cliente.Cpf +
                                          "\nTítulo Livro:" + livro.Titulo +
                                          "\nStatus do Empréstimo:" + status +
                                          "\nData Empréstimo:" + r.DataEmprestimo +
                                          "\nData Devolução:" + r.DataDevolucao + "\n\n");
                        Console.Write("Pressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            return lista;
        }
    }
}
