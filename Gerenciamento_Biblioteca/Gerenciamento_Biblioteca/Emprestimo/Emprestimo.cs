using System;

namespace Gerenciamento_Biblioteca
{
    public class Emprestimo
    {
        public int IdCliente { get; set; }
        public int NumeroTombo { get; set; }
       //public string Titulo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int StatusEmprestimo { get; set; }
        public string Cpf { get; internal set; }    }
}
