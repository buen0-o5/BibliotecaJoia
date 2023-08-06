using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
   public interface IEmprestimoDvdService
    {
        void EfetuarEmprestimo(EmprestimoDvdDto emprestimoDvd);
        void EfetuarDevolucao(int emprestimoId, string dvdId);
        List<ConsultaEmprestimoDvdDto> consultaEmprestimos();
        ConsultaEmprestimoDvdDto consultaEmprestimo(int id, string nomeDvd, string nomeCliente, DateTime dataEmprestimo);
        void AtualizarStatusEmprestimosDvds();
        ClienteDto PesquisarClientePorNome(string nome);
        DvdDto PesquisarDvdPorNome(string nome);
    }
}
