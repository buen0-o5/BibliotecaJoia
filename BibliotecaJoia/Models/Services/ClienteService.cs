using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepositorio;

        public ClienteService(IClienteRepository clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Atualizar(ClienteDto cliente)
        {
            try
            {
                var objcliente = cliente.ConverterParaEntidade(); //necessario a conversao para ter acesso ao repository
                _clienteRepositorio.Atualizar(objcliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(ClienteDto cliente)
        {
            try
            {
                var objcliente = cliente.ConverterParaEntidade();
                objcliente.Cadastrar();
                _clienteRepositorio.Cadastrar(objcliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                _clienteRepositorio.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteDto> Listar()
        {
            try
            {
                var clienteDto = new List<ClienteDto>();
                var cliente = _clienteRepositorio.Listar();
                foreach (var item in cliente)
                {
                    clienteDto.Add(item.ConverterParaDto());
                }
                return clienteDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteDto PesquisarPorId(int id)
        {
            try
            {
                var cliente = _clienteRepositorio.PesquisarPorId(id);
                return cliente.ConverterParaDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
