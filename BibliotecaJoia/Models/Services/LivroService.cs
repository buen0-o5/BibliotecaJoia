using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void Atualizar(LivroDto livro)
        {
            try
            {
                var objLivro = livro.CoverterParaEntidade();
                _livroRepository.Atualizar(objLivro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(LivroDto livro)
        {
            try
            {
                var objLivro = livro.CoverterParaEntidade();
                objLivro.Cadastrar();
               _livroRepository.Cadastrar(objLivro);
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
                 _livroRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDto> Listar()
        {
            try
            {
                var livroDtos = new List<LivroDto>();
                var livros =_livroRepository.Listar();
                foreach(var item in livros)
                {
                    livroDtos.Add(item.CoverterParaDto());
                }
                return livroDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public LivroDto PesquisarPorId(int id)
        {
            try
            {
                var livro = _livroRepository.PesquisarPorId(id);
                return livro.CoverterParaDto();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
