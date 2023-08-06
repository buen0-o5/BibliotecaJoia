using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Contexto
{
    //Interface que estabelece um conjunto de
    //operações básicas para interagir com a fonte de dados que armazena informações sobre livros
    //contexto de dados independente
    public interface IContextData
    {
       
        #region Livro
        void CadastrarLivro(Livro livro);
        List<Livro> ListarLivro();

        Livro PesquisarLivroPorId(int id);

        void AtualizarLivro(Livro livro);
        void ExcluirLivro(int id);
        #endregion

        #region Cliente
        void CadastrarCliente(Cliente cliente);
        List<Cliente> ListarCliente();
        Cliente PesquisarClientePorId(int id);
        void AtualizarCliente(Cliente cliente);
        void ExcluirCliente(int id);
        #endregion

        #region Usuario
        void CadastrarUsuario(Usuario usuario);
        List<Usuario> ListarUsuario();
        Usuario PesquisarUsuarioPorId(int id);
        void AtualizarUsuario(Usuario usuario);
        void ExcluirUsuario(int id);
        public UsuarioDto EfetuarLogin(UsuarioDto usuario);
        #endregion

        #region Emprestimo Livro
        void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro);
        void EfetuarDevolucao(int emprestimoId, string livroId);

        List<ConsultaEmprestimoDto> consultaEmprestimos();
        ConsultaEmprestimoDto consultaEmprestimo(int id,string nomeLivro, string nomeCliente, DateTime dataEmprestimo);
        void AtualizarStatusEmprestimosLivros();

        #endregion

        #region Pesquisa Nome 
        Cliente PesquisarClientePorNome(string nome);
        Livro PesquisarLivroPorNome(string nome);
        Dvd PesquisarDvdPorNome(string nome);
        #endregion

        #region Dvd
        void CadastrarDvd(Dvd dvd);
        List<Dvd> ListarDvd();
        Dvd PesquisarDvdPorId(int id);
        void AtualizarDvd(Dvd livro);
        void ExcluirDvd(int id);
        #endregion

        #region Emprestimo Livro
        void EfetuarEmprestimo(EmprestimoDvd emprestimoDvd);
        void EfetuarDevolucaoDvd(int emprestimoId, string dvdId);

        List<ConsultaEmprestimoDvdDto> consultaEmprestimosDvd();
        ConsultaEmprestimoDvdDto consultaEmprestimoDvd(int id,string nomeDvd, string nomeCliente, DateTime dataEmprestimo);
        void AtualizarStatusEmprestimosDvds();
        #endregion

    }
}
