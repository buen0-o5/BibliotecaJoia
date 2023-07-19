using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public  class ContextDataFake : IContextData
    {

        private static List<LivroDto> livros;

        public ContextDataFake()
        {
            livros = new List<LivroDto>();
            InitializeData();
        }

        public void Atualizar(LivroDto livro)
        {
            var objPersquisa = PesquisarPorId(livro.Id);
            livros.Remove(objPersquisa);

            objPersquisa.Nome = livro.Nome;
            objPersquisa.Editora = livro.Editora;
            objPersquisa.Autor = livro.Autor;

            Cadastrar(objPersquisa);
        }

        public void Cadastrar(LivroDto livro)
        {
            try
            {
               livros.Add(livro);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(string id)
        {
            try
            {
                var objPesquisa = PesquisarPorId(id);
                livros.Remove(objPesquisa);
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
                return livros
               .OrderBy(p => p.Nome)
               .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public LivroDto PesquisarPorId(string id)
        {
            try
            {
                return livros.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeData()
        {
            var livro = new LivroDto("Implementando Domain-Drive Design", "Vaugh Vernos", "Alta Books");
            livros.Add(livro);
           
            livro = new LivroDto("Domain-Drive Design", "Eric Evans", "Alta Books");
            livros.Add(livro);

            livro = new LivroDto("Redes Guia Pratico", "Carlor E. Morimoto", "Sul Editores");
            livros.Add(livro);

            livro = new LivroDto("PHP Programando com Orientaçao a Objeto", "Pablo Dall'Oglio ", "Novatec");
            livros.Add(livro);

            livro = new LivroDto("Introduçao a Programaçao com Python", "Nilo N.C mENEZAES", "Novatec");
            livros.Add(livro);

        }
    }
}
