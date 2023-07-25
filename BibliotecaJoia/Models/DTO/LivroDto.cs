using BibliotecaJoia.Models.Entidades;
using BibliotecaJoia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.DTO
{
    // Classe que representa um objeto LivroDto, contendo os atributos relacionados a um livro.
    // Essa classe é utilizada como uma representação de dados transferidos (DTO - Data Transfer Object)
    // para enviar informações de livros entre diferentes partes da aplicação, como a camada de apresentação e a camada de serviço.
    public class LivroDto : EntidadeBase
    {
        //Atributos do livro
        
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int StatusLivroId { get; set; }
        public string Status { get; set; }



        //Construtor padrão utilizado para fins de formulário (não recebe parâmetros).
        //Pode ser usado pelo framework de vinculação de dados para criar objetos LivroDto a partir dos dados de formulário.
        public LivroDto()
        {
            
        }

        //// Construtor que recebe o "id", "nome", "autor" e "editora" do livro como parâmetros.
        //// Esse construtor é usado quando é necessário criar um LivroDto com um "id" específico,
        //// por exemplo, ao recuperar dados do banco de dados e mapeá-los para objetos LivroDto.
        //public LivroDto(string id, string nome, string autor, string editora)
        //    :this(nome, autor,editora)
        //{
        //    this.Id = id;
        //}

        // Construtor que recebe o "nome", "autor" e "editora" do livro como parâmetros.
        // Esse construtor é usado quando um novo livro está sendo criado e ainda não possui um "id".
        //public LivroDto( string nome, string autor, string editora)
        //{
        //    this.Nome = nome;
        //    this.Autor = autor;
        //    this.Editora = editora;
       

        //}
        public Livro CoverterParaEntidade()
        {
            return new Livro
            {
                Id = this.Id,
                Nome = this.Nome,
                Autor = this.Autor,
                Editora = this.Editora,
                StatusLivro = GerenciadorDeStatus.PesquisarStatusDoLivroPeloId(this.StatusLivroId)
              //5:25
            };
        }

    }
}
