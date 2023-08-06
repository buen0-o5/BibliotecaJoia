using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class DvdRepository : IDvdRepository
    {
        private readonly IContextData _contextData;
        public DvdRepository(IContextData contextData) 
        {
            _contextData = contextData;
        }

        public void Atualizar(Dvd entidade)
        {
            _contextData.AtualizarDvd(entidade);
        }

        public void Cadastrar(Dvd entidade)
        {
            _contextData.CadastrarDvd(entidade);
        }

        public void Excluir(int id)
        {
            _contextData.ExcluirDvd(id);
        }

        public List<Dvd> Listar()
        {
            return _contextData.ListarDvd();
        }

        public Dvd PesquisarPorId(int id)
        {
            return _contextData.PesquisarDvdPorId(id);
        }
    }
}
