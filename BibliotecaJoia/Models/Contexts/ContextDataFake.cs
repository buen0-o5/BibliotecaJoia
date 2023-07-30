using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    public  class ContextDataFake : IContextData
    {

        private static List<Livro> livros = new List<Livro>();

        public ContextDataFake()
        {
          //  livros = new List<Livro>();
            InitializeData();
        }

        public void AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void AtualizarLivro(Livro livro)
        {
            var objPersquisa = PesquisarLivroPorId(livro.Id);
            livros.Remove(objPersquisa);

            objPersquisa.Nome = livro.Nome;
            objPersquisa.Editora = livro.Editora;
            objPersquisa.Autor = livro.Autor;

            CadastrarLivro(objPersquisa);
        }

        public void AtualizarStatusEmprestimosLivros()
        {
            throw new NotImplementedException();
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void CadastrarLivro(Livro livro)
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

        public void CadastrarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public ConsultaEmprestimoDto consultaEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo)
        {
            throw new NotImplementedException();
        }

        public List<ConsultaEmprestimoDto> consultaEmprestimos()
        {
            throw new NotImplementedException();
        }

        public void EfetuarDevolucao(int emprestimoId, string livroId)
        {
            throw new NotImplementedException();
        }

        public void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro)
        {
            throw new NotImplementedException();
        }

        public UsuarioDto EfetuarLogin(UsuarioDto usuario)
        {
            throw new NotImplementedException();
        }

        public void ExcluirCliente(string id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(id);
                livros.Remove(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarCliente()
        {
            throw new NotImplementedException();
        }

        public List<Livro> ListarLivro()
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

        public List<Usuario> ListarUsuario()
        {
            throw new NotImplementedException();
        }

        public Cliente PesquisarClientePorId(string id)
        {
            throw new NotImplementedException();
        }

        public Livro PesquisarLivroPorId(string id)
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

        public Usuario PesquisarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        private void InitializeData()
        {
            var livro = new Livro { Nome = "Implementando Domain-Drive Design", Autor = "Vaugh Vernos",Editora = "Alta Books"};
            livros.Add(livro);
           
            livro = new Livro { Nome = "Domain-Drive Design", Autor = "Eric Evans", Editora =  "Alta Books" };
            livros.Add(livro);

            livro = new Livro{ Nome = "Redes Guia Pratico", Autor = "Carlor E. Morimoto", Editora = "Sul Editores" };
            livros.Add(livro);

            livro = new Livro{ Nome = "PHP Programando com Orientaçao a Objeto", Autor = "Pablo Dall'Oglio ", Editora = "Novatec" };
            livros.Add(livro);

            livro = new Livro { Nome = "Introduçao a Programaçao com Python", Autor = "Nilo N.C mENEZAES", Editora = "Novatec" };
            livros.Add(livro);

        }
    }
}
