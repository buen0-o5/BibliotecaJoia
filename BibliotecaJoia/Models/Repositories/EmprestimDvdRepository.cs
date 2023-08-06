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
    public class EmprestimDvdRepository : IEmprestimoDvdRepository
    {
        private readonly IContextData _contextData;
        public EmprestimDvdRepository(IContextData contextData)
        {
            _contextData = contextData;
        }
        public void AtualizarStatusEmprestimosDvds()
        {
            _contextData.AtualizarStatusEmprestimosDvds();
        }

        public ConsultaEmprestimoDvdDto consultaEmprestimo(int id, string nomeDvd, string nomeCliente, DateTime dataEmprestimo)
        {
            ConsultaEmprestimoDvdDto result = _contextData.consultaEmprestimoDvd(id, nomeDvd, nomeCliente, dataEmprestimo);
            return result;
        }

        public List<ConsultaEmprestimoDvdDto> consultaEmprestimos()
        {
            return _contextData.consultaEmprestimosDvd();
        }

        public void EfetuarDevolucao(int emprestimoId, string dvdId)
        {
            _contextData.EfetuarDevolucaoDvd(emprestimoId, dvdId);
        }

        public void EfetuarEmprestimo(EmprestimoDvd emprestimoDvd)
        {
            _contextData.EfetuarEmprestimo(emprestimoDvd);
        }

        public Cliente PesquisarClientePorNome(string nome)
        {
            return _contextData.PesquisarClientePorNome(nome);
        }

        public Dvd PesquisarDvdPorNome(string nome)
        {
            return _contextData.PesquisarDvdPorNome(nome);
        }

    }
}
