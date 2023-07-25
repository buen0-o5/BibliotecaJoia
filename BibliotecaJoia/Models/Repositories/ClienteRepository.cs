using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IContextData _contextData;
        public ClienteRepository (IContextData contextData)
        {
            _contextData = contextData;
        }


        public void Atualizar(Cliente cliente)
        {
            _contextData.AtualizarCliente(cliente);
        }

        public void Cadastrar(Cliente cliente)
        {
            _contextData.CadastrarCliente(cliente);
        }

        public void Excluir(string id)
        {
            _contextData.ExcluirCliente(id);
        }

        public List<Cliente> Listar()
        {
            return _contextData.ListarCliente();
        }

        public Cliente PesquisarPorId(string id)
        {
            return _contextData.PesquisarClientePorId(id);
        }
    }
}
