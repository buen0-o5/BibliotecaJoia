using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
   public interface IEmprestimoDvdRepository
    {
        void EfetuarEmprestimo(EmprestimoDvd emprestimoDvd);
        void EfetuarDevolucao(int emprestimoId, string dvdId);
        List<ConsultaEmprestimoDvdDto> consultaEmprestimos();
        ConsultaEmprestimoDvdDto consultaEmprestimo(int id, string nomeDvd, string nomeCliente, DateTime dataEmprestimo);
        void AtualizarStatusEmprestimosDvds();
        Cliente PesquisarClientePorNome(string nome);
        Dvd PesquisarDvdPorNome(string nome);
    }
}
