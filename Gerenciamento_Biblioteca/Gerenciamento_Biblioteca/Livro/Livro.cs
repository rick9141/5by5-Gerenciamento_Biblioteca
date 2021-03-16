using System;

namespace Gerenciamento_Biblioteca
{
    public class Livro
    {
        public int NumeroTombo { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Autor { get;  set; }
    }
}
