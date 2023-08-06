using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
    public interface IEmprestimoLivroService
    {
        void EfetuarEmprestimo(EmprestimoLivroDto emprestimoLivro);
        void EfetuarDevolucao(int emprestimoId, string livroId);
        List<ConsultaEmprestimoDto> consultaEmprestimos();
        ConsultaEmprestimoDto consultaEmprestimo(int id,string nomeLivro, string nomeCliente, DateTime dataEmprestimo);
        void AtualizarStatusEmprestimosLivros();
        ClienteDto PesquisarClientePorNome(string nome);
        LivroDto PesquisarLivroPorNome(string nome);
    }
}
