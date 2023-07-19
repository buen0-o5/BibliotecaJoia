using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly IContextData _contextData;

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
