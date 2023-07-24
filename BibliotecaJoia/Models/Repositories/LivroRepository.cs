using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.DTO;
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

        public void Atualizar(LivroDto livro)
        {
            _contextData.Atualizar(livro);
        }

        public void Cadastrar(LivroDto livro)
        {
            _contextData.Cadastrar(livro);
        }

        public void Excluir(string id)
        {
            _contextData.Excluir(id);

        }

        public List<LivroDto> Listar()
        {
            return _contextData.Listar(); 
        }

        public LivroDto PesquisarPorId(string id)
        {
            return _contextData.PesquisarPorId(id);
        }
    }
}
