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
    public class EmprestimoLivroRepository : IEmprestimoLivroRepository
    {
        private readonly IContextData _contextData;
       public EmprestimoLivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void AtualizarStatusEmprestimosLivros()
        {
            _contextData.AtualizarStatusEmprestimosLivros();
        }

        public ConsultaEmprestimoDto consultaEmprestimo(int id,string nomeLivro, string nomeCliente, DateTime dataEmprestimo)
        {
           ConsultaEmprestimoDto result = _contextData.consultaEmprestimo(id,nomeLivro, nomeCliente, dataEmprestimo);
           return result;
        }

        public List<ConsultaEmprestimoDto> consultaEmprestimos()
        {
           return _contextData.consultaEmprestimos();
        }

        public void EfetuarDevolucao(int emprestimoId, string livroId)
        {
            _contextData.EfetuarDevolucao(emprestimoId, livroId);
        }

        public void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro)
        {
            _contextData.EfetuarEmprestimo(emprestimoLivro);
        }

        public Cliente PesquisarClientePorNome(string nome)
        {
            return _contextData.PesquisarClientePorNome(nome);
        }

        public Livro PesquisarLivroPorNome(string nome)
        {
            return _contextData.PesquisarLivroPorNome(nome);
        }
    }
}
