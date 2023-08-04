using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public class Livro 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int StatusLivroId { get; set; }
        public StatusLivro StatusLivro { get; set; }

        public Livro()
            :base()
        {

        }

        public void Cadastrar()
        {
            this.StatusLivro = StatusLivro.DISPONIVEL;
            this.StatusLivroId = StatusLivro.GetHashCode();
        }

        public LivroDto CoverterParaDto()
        {
            return new LivroDto
            {
                Id = this.Id,
                Nome = this.Nome,
                Autor = this.Autor,
                Editora = this.Editora,
                StatusLivroId = this.StatusLivro.GetHashCode(),
                Status = this.StatusLivro.ToString()
            };
        }

    }
}
