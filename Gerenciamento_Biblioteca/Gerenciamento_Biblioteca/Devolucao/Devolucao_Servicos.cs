using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Gerenciamento_Biblioteca
{
    public class Devolucao_Servicos
    {

        public const double multaPorDia = 10;

        public static double RetornarMulta(DateTime dataDevolucao)
        {
            double resultado = 0;
            if (dataDevolucao > DateTime.Now)
            {
                resultado = dataDevolucao.Subtract(DateTime.Now).TotalDays * multaPorDia;
            }
            return resultado;
        }


        public static void CadastroDevolucao(List<Emprestimo> lista, List<Livro> listaLivro)
        {
            var livroIsbn = Ler_Campos.Ler("Informe o numero ISBN do Livro", 13, 0);


            while (!listaLivro.Any(x => x.Isbn == livroIsbn))
            {
                Console.WriteLine("Livro não encontrado para devolução");
                livroIsbn = Ler_Campos.Ler("Informe o numero ISBN do Livro", 13, 0);
            }


            var numeroTombo = listaLivro.Where(x => x.Isbn == livroIsbn).FirstOrDefault().NumeroTombo;

            double valorMulta = 0;

            foreach (var emprestimo in lista)
            {
                if (emprestimo.NumeroTombo == numeroTombo)
                {
                    emprestimo.StatusEmprestimo = 2;

                    if (emprestimo.DataDevolucao > DateTime.Now)
                    {
                        valorMulta = RetornarMulta(emprestimo.DataDevolucao);
                        break;
                    }
                }
            }

            Console.Clear();

            if (valorMulta > 0)
            {
                Console.WriteLine("Você contém uma multa de " + valorMulta + " centavos");
            }

            using (var writer = new StreamWriter(@"C:\Arquivos\Emprestimo.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(lista);
            }

        }

    }
}
