using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface IEmprestimoLivroRepository
    {
        void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro);
        void EfetuarDevolucao(int emprestimoId, string livroId);
        List<ConsultaEmprestimoDto> consultaEmprestimos();
        ConsultaEmprestimoDto consultaEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo);
        void AtualizarStatusEmprestimosLivros();
        Cliente PesquisarClientePorNome(string nome);
        Livro PesquisarLivroPorNome(string nome);

    }
}
