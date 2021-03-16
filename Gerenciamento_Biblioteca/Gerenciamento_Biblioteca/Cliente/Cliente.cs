using System;

namespace Gerenciamento_Biblioteca
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Cliente_Endereco Endereco { get; set; }
    }

}
