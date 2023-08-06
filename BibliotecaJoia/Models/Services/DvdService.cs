using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Services
{
    public class DvdService : IDvdService
    {
        private readonly IDvdRepository _dvdRepository;

        public DvdService(IDvdRepository dvdRepository) 
        {
            _dvdRepository = dvdRepository;
        }

        public void Atualizar(DvdDto entidade)
        {
            try
            {
                var objDvd = entidade.ConverterParaEntidade();
                _dvdRepository.Atualizar(objDvd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(DvdDto entidade)
        {
            try
            {
                var objDvd = entidade.ConverterParaEntidade();
                objDvd.Cadastrar();
                _dvdRepository.Cadastrar(objDvd);
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
                _dvdRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DvdDto> Listar()
        {
            try
            {
                var dvdDtos = new List<DvdDto>();
                var dvds = _dvdRepository.Listar();
                foreach (var item in dvds)
                {
                    dvdDtos.Add(item.ConverterParaDto());
                }
                return dvdDtos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DvdDto PesquisarPorId(int id)
        {
            try
            {
                var dvd = _dvdRepository.PesquisarPorId(id);
                return dvd.ConverterParaDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
