using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Services
{
    public class EmprestimoDvdService : IEmprestimoDvdService
    {
        private readonly IEmprestimoDvdRepository _emprestimoDvdRepository;
        public EmprestimoDvdService(IEmprestimoDvdRepository emprestimoDvdRepository)
        {
            _emprestimoDvdRepository = emprestimoDvdRepository;
        }
        public void AtualizarStatusEmprestimosDvds()
        {
            _emprestimoDvdRepository.AtualizarStatusEmprestimosDvds();
        }

        public ConsultaEmprestimoDvdDto consultaEmprestimo(int id,string nomeDvd, string nomeCliente, DateTime dataEmprestimo)
        {
            return _emprestimoDvdRepository.consultaEmprestimo(id, nomeDvd, nomeCliente, dataEmprestimo);
        }

        public List<ConsultaEmprestimoDvdDto> consultaEmprestimos()
        {
            return _emprestimoDvdRepository.consultaEmprestimos();
        }

        public void EfetuarDevolucao(int emprestimoId, string dvdIdId)
        {
            try
            {

                _emprestimoDvdRepository.EfetuarDevolucao(emprestimoId, dvdIdId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EfetuarEmprestimo(EmprestimoDvdDto emprestimoDvd)
        {
            try
            {
                var entidade = emprestimoDvd.ConverterParaEntidade();
                entidade.RealizarEmprestimo();
                _emprestimoDvdRepository.EfetuarEmprestimo(entidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteDto PesquisarClientePorNome(string nome)
        {
            try
            {
                var cliente = _emprestimoDvdRepository.PesquisarClientePorNome(nome);
                return cliente.ConverterParaDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DvdDto PesquisarDvdPorNome(string nome)
        {
            try
            {
                var dvd = _emprestimoDvdRepository.PesquisarDvdPorNome(nome);
                return dvd.ConverterParaDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
