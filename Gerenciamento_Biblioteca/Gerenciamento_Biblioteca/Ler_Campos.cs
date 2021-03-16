using System;
using System.Globalization;

namespace Gerenciamento_Biblioteca
{
    public class Ler_Campos
    {
        public static dynamic Ler(string campo, int tamanho, int tipo)
        {

            if (tipo == 0)
            {
                string resultado;
                do
                {
                    Console.Write("Informe o " + campo + ": ");
                    resultado = Console.ReadLine();
                    if (resultado.Length > tamanho)
                        Console.WriteLine(campo + " tem que ser menor que " + tamanho + " caracteres");

                } while (resultado == "" || resultado.Length > tamanho);
                return resultado;
            }

            if (tipo == 1)
            {
                DateTime data;
                CultureInfo CultureBr = new CultureInfo(name: "pt-BR");

                do
                {
                    Console.Write("Informe sua " + campo + ": ");
                    data = DateTime.ParseExact(Console.ReadLine(), "d", CultureBr);
                } while (data <= DateTime.MinValue);

                return data;
            }

            return null;
        }
    }
}
