using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Gerenciamento_Biblioteca
{
    class Livro_Servicos
    {
        public static void CadastroLivro(List<Livro> lista)
        {

            Livro novoLivro = new Livro()
            {
                NumeroTombo = lista.Count + 1,
                Isbn = VerificaExisteIsbn(lista),
                Titulo = Ler_Campos.Ler("Titulo", 50, 0),
                Genero = Ler_Campos.Ler("Genêro", 10, 0),
                DataPublicacao = Ler_Campos.Ler("Data de Publicação", 10, 1),
                Autor = Ler_Campos.Ler("Autor", 30, 0)
            };

            lista.Add(novoLivro);
            lista = lista.OrderBy(x => x.NumeroTombo).ToList();
            Console.Clear();

            using (var writer = new StreamWriter(@"C:\Arquivos\Livro.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(lista);
            }

        }

        public static string VerificaExisteIsbn(List<Livro> lista)
        {
            string isbn;
            /// LAÇO VERIFICA SE o ISBN JÁ EXISTE NA LISTA DE LIVROS
            do
            {
                Console.Write("Informe o ISBN: ");
                isbn = Console.ReadLine();

                if (lista.Where(livro => livro.Isbn == isbn).FirstOrDefault() != null)
                    Console.WriteLine("ISBN já cadastrado");

            } while (lista.Where(livro => livro.Isbn == isbn).FirstOrDefault() != null);

            return isbn;
        }

        public static List<Livro> RetornarTodos()
        {
            List<Livro> lista = new List<Livro>();
            if (File.Exists(@"C:\Arquivos\Livro.csv"))
            {
                using (var reader = new StreamReader(@"C:\Arquivos\Livro.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Livro>();
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
