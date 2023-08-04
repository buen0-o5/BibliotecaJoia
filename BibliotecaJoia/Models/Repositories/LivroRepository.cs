using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    // Classe que implementa a interface ILivroRepository e representa o repositório de dados dos livros.
    // Essa classe é responsável por interagir com o contexto de acesso aos dados (IContextData) para realizar operações CRUD com os livros.
    public class LivroRepository : ILivroRepository
    {
        // Objeto que representa o contexto de acesso aos dados dos livros (IContextData).
        private readonly IContextData _contextData;

        // Construtor da classe que recebe um objeto IContextData como parâmetro.
        // O IContextData é injetado para que seja possível interagir com o contexto de acesso aos dados (por exemplo, um contexto de banco de dados).
        public LivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(Livro livro)
        {
            _contextData.AtualizarLivro(livro);
        }

        public void Cadastrar(Livro livro)
        {
            _contextData.CadastrarLivro(livro);
        }

        public void Excluir(int id)
        {
            _contextData.ExcluirLivro(id);

        }

        public List<Livro> Listar()
        {
            return _contextData.ListarLivro(); 
        }

        public Livro PesquisarPorId(int id)
        {
            return _contextData.PesquisarLivroPorId(id);
        }
    }
}
