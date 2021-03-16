using CpfLibrary;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace Gerenciamento_Biblioteca
{
    class Cliente_Servicos
    {

        public static void CadastroCliente(List<Cliente> lista)
        {

            Cliente novoCliente = new Cliente()
            {
                IdCliente = lista.Count + 1,
                Cpf = LerCpf(lista),
                Nome = Ler_Campos.Ler("Nome", 50, 0),
                DataNascimento = Ler_Campos.Ler("Data de Nascimento", 10, 1),
                Telefone = Ler_Campos.Ler("Telefone", 13, 0),
                Endereco = LerEndereco()
            };

            lista.Add(novoCliente);
            lista = lista.OrderBy(x => x.IdCliente).ToList();
            Console.Clear();

            using (var writer = new StreamWriter(@"C:\Arquivos\Cliente.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(lista);
            }

        }


        public static string LerCpf(List<Cliente> lista)
        {
            string cpf;
            do
            {
                Console.Write("Informe o CPF( Apenas números e com o dígito): ");
                cpf = Console.ReadLine();

                if (!Cpf.Check(cpf))
                    Console.WriteLine("CPF inválido");

                if (lista.Where(cliente => cliente.Cpf == cpf).FirstOrDefault() != null)
                    Console.WriteLine("CPF já cadastrado");

            } while (!(Cpf.Check(cpf)) || (lista.Where(cliente => cliente.Cpf == cpf).FirstOrDefault() != null));
            /// VERIFICA SE CPF É VALIDO      VERIFICA SE CPF JÁ EXISTE NA LISTA

            return cpf;
        }


        private static Cliente_Endereco LerEndereco()
        {
            return new Cliente_Endereco()
            {
                Logradouro = Ler_Campos.Ler("Logradouro", 20, 0),
                Bairro = Ler_Campos.Ler("Bairro", 20, 0),
                Cidade = Ler_Campos.Ler("Cidade", 20, 0),
                Estado = Ler_Campos.Ler("Estado", 15, 0),
                CEP = Ler_Campos.Ler("CEP", 8, 0)
            };
        }


        public static List<Cliente> RetornarTodos()
        {
            List<Cliente> lista = new List<Cliente>();
            if (File.Exists(@"C:\Arquivos\Cliente.csv"))
            {
                using (var reader = new StreamReader(@"C:\Arquivos\Cliente.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<Cliente>();
                        foreach (var r in records)
                        {
                            lista.Add(r);
                        }
                    }
                }
            }
            return lista;
        }

    }
}
