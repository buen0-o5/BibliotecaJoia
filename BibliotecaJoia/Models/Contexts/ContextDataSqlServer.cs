using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using BibliotecaJoia.Models.Enums;
using BibliotecaJoia.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    // Classe que implementa a interface IContextData e representa o contexto de acesso aos dados no banco de dados SQL Server.
    // Essa classe é responsável por fornecer métodos para realizar operações relacionadas aos livros no banco de dados.

    public class ContextDataSqlServer : IContextData
    {
        #region Injeçao de dependencia
        // Objeto SqlConnection que representa a conexão com o banco de dados.
        private readonly SqlConnection _connection = null;

        // Construtor da classe que recebe um objeto IConnectionManager como parâmetro.
        // O IConnectionManager é utilizado para obter a conexão com o banco de dados por meio do método GetConnection().
        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }
        #endregion

        #region Cliente
        public void AtualizarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open(); //abre a conexao
                var query = SqlManager.GetSql(TSql.ATUALIZAR_CLIENTE);

                var command = new SqlCommand(query, _connection);
               
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.CPF;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void CadastrarCliente(Cliente cliente)
        {
            try
            {
                _connection.Open();//abrindo conexao


                //declaramos uma variavel que recebe a consulta sql pre-definida de acordo com a enumeração TSql Cadastrar_livros.
                var query = SqlManager.GetSql(TSql.CADASTRAR_CLIENTE);

                //Criando comando sql, passando a consulta que sera realizada e o conexao
                var command = new SqlCommand(query, _connection);

                //definindo parametros para indicar os valores a consulta
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = cliente.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.Email;
                command.Parameters.Add("@fone", SqlDbType.VarChar).Value = cliente.Fone;
                command.Parameters.Add("@cpf", SqlDbType.VarChar).Value = cliente.CPF;
                command.Parameters.Add("@statusClienteId", SqlDbType.Int).Value = cliente.StatusCliente.GetHashCode();



                //executa a operaçao
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void ExcluirCliente(string id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_CLIENTE);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public List<Cliente> ListarCliente()
        {
            var clientes = new List<Cliente>();
            try
            {
                // Obtém a consulta SQL para listar os livros
                var query = SqlManager.GetSql(TSql.LISTAR_CLIENTE);

                // Cria um novo comando SQL com a consulta e a conexão do banco de dados
                var command = new SqlCommand(query, _connection);

                // Cria um novo DataSet para armazenar os dados do banco de dados em memória
                var dataset = new DataSet();

                // Cria um adaptador SQL para executar comandos e obter os dados do banco de dados
                var adapter = new SqlDataAdapter(command);


                //Preenche o DataSet com os dados obtidos pela execução do comando SQL
                adapter.Fill(dataset);

                // Obtém a tabela de dados do DataSet
                var rows = dataset.Tables[0].Rows;

                // Itera através de cada linha (registro) na tabela de dados
                foreach (DataRow item in rows)
                {
                    // Obtém um array com as colunas (campos) da linha atual
                    var colunas = item.ItemArray;

                    // Extrai os valores das colunas para criar um objeto LivroDto
                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusClienteId = colunas[5].ToString();


                    // Cria um novo objeto LivroDto com os valores extraídos das colunas
                    var cliente = new Cliente { Id = id, Nome = nome, CPF = cpf, Email = email, Fone = fone, StatusClienteId = Int32.Parse(statusClienteId) };
                    cliente.StatusCliente = GerenciadorDeStatus.PesquisarStatusClientePeloId(cliente.StatusClienteId);
                    // Adiciona o livro à coleção (lista) de livros
                    clientes.Add(cliente);
                }

                // Libera recursos, definindo os objetos como nulos para permitir a coleta de lixo
                adapter = null;
                dataset = null;

                // Retorna a lista de livros preenchida com os dados do banco de dados
                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente PesquisarClientePorId(string id)
        {
            try
            {
                Cliente cliente = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_CLIENTE);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;


                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var cpf = colunas[2].ToString();
                    var email = colunas[3].ToString();
                    var fone = colunas[4].ToString();
                    var statusClienteId = colunas[5].ToString();

                    cliente = new Cliente { Id = codigo, Nome = nome, CPF = cpf, Email = email, Fone = fone, StatusClienteId = Int32.Parse(statusClienteId) };
                    cliente.StatusCliente = GerenciadorDeStatus.PesquisarStatusClientePeloId(cliente.StatusClienteId);
                }
                adapter = null;
                dataset = null;

                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Livro
        public void AtualizarLivro(Livro livro)
        {
            try
            {
                _connection.Open(); //abre a conexao
                var query = SqlManager.GetSql(TSql.ATUALIZAR_LIVRO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;

                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void CadastrarLivro(Livro livro)
        {
            try
            {
                _connection.Open();//abrindo conexao




                //declaramos uma variavel que recebe a consulta sql pre-definida de acordo com a enumeração TSql Cadastrar_livros.
                var query = SqlManager.GetSql(TSql.CADASTRAR_LIVRO);

                //Criando comando sql, passando a consulta que sera realizada e o conexao
                var command = new SqlCommand(query, _connection);

                //definindo parametros para indicar os valores a consulta
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = livro.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = livro.Nome;
                command.Parameters.Add("@autor", SqlDbType.VarChar).Value = livro.Autor;
                command.Parameters.Add("@editora", SqlDbType.VarChar).Value = livro.Editora;
                command.Parameters.Add("@statusLivroId", SqlDbType.Int).Value = livro.StatusLivro.GetHashCode();

                //executa a operaçao
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void ExcluirLivro(string id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_LIVRO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public List<Livro> ListarLivro()
        {
            var livros = new List<Livro>();
            try
            {
                // Obtém a consulta SQL para listar os livros
                var query = SqlManager.GetSql(TSql.LISTAR_LIVRO);

                // Cria um novo comando SQL com a consulta e a conexão do banco de dados
                var command = new SqlCommand(query, _connection);

                // Cria um novo DataSet para armazenar os dados do banco de dados em memória
                var dataset = new DataSet();

                // Cria um adaptador SQL para executar comandos e obter os dados do banco de dados
                var adapter = new SqlDataAdapter(command);


                //Preenche o DataSet com os dados obtidos pela execução do comando SQL
                adapter.Fill(dataset);

                // Obtém a tabela de dados do DataSet
                var rows = dataset.Tables[0].Rows;

                // Itera através de cada linha (registro) na tabela de dados
                foreach (DataRow item in rows)
                {
                    // Obtém um array com as colunas (campos) da linha atual
                    var colunas = item.ItemArray;

                    // Extrai os valores das colunas para criar um objeto LivroDto
                    var id = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();

                    // Cria um novo objeto LivroDto com os valores extraídos das colunas
                    var livro = new Livro { Id = id, Nome = nome, Autor = autor, Editora = editora };

                    // Adiciona o livro à coleção (lista) de livros
                    livros.Add(livro);
                }

                // Libera recursos, definindo os objetos como nulos para permitir a coleta de lixo
                adapter = null;
                dataset = null;

                // Retorna a lista de livros preenchida com os dados do banco de dados
                return livros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Livro PesquisarLivroPorId(string id)
        {
            try
            {
                Livro livro = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_LIVRO);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;


                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;

                    var codigo = colunas[0].ToString();
                    var nome = colunas[1].ToString();
                    var autor = colunas[2].ToString();
                    var editora = colunas[3].ToString();

                    livro = new Livro { Id = codigo, Nome = nome, Autor = autor, Editora = editora };

                }
                adapter = null;
                dataset = null;

                return livro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Usuario
        public void AtualizarUsuario(Usuario usuario)
        {
            try
            {
                _connection.Open(); //abre a conexao
                var query = SqlManager.GetSql(TSql.ATUALIZAR_USUARIO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                _connection.Open();//abrindo conexao


                var query = SqlManager.GetSql(TSql.CADASTRAR_USUARIO);
             
                var command = new SqlCommand(query, _connection);
               
                command.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

      
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public void ExcluirUsuario(int id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_USUARIO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public List<Usuario> ListarUsuario()
        {
            var Usuarios = new List<Usuario>();
            try
            {
                // Obtém a consulta SQL para listar os livros
                var query = SqlManager.GetSql(TSql.LISTAR_USUARIO);

                // Cria um novo comando SQL com a consulta e a conexão do banco de dados
                var command = new SqlCommand(query, _connection);

                // Cria um novo DataSet para armazenar os dados do banco de dados em memória
                var dataset = new DataSet();

                // Cria um adaptador SQL para executar comandos e obter os dados do banco de dados
                var adapter = new SqlDataAdapter(command);


                //Preenche o DataSet com os dados obtidos pela execução do comando SQL
                adapter.Fill(dataset);

                // Obtém a tabela de dados do DataSet
                var rows = dataset.Tables[0].Rows;

                // Itera através de cada linha (registro) na tabela de dados
                foreach (DataRow item in rows)
                {
                    // Obtém um array com as colunas (campos) da linha atual
                    var colunas = item.ItemArray;

                    // Extrai os valores das colunas para criar um objeto LivroDto
                    var id = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                    var senha = colunas[2].ToString();
             
              


                    // Cria um novo objeto LivroDto com os valores extraídos das colunas
                    var usuario = new Usuario { Id = id, Login = login, Senha = senha };
                    // Adiciona o livro à coleção (lista) de livros
                    Usuarios.Add(usuario);
                }

                // Libera recursos, definindo os objetos como nulos para permitir a coleta de lixo
                adapter = null;
                dataset = null;

                // Retorna a lista de livros preenchida com os dados do banco de dados
                return Usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario PesquisarUsuarioPorId(int id)
        {
            try
            {
                Usuario usuario = null;

                var query = SqlManager.GetSql(TSql.PESQUISAR_USUARIO);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;


                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;
                    var codigo = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                    var senha = colunas[2].ToString();

                    usuario = new Usuario { Id = codigo, Login = login, Senha = senha };
                }
                adapter = null;
                dataset = null;

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public  UsuarioDto EfetuarLogin(UsuarioDto usuario)
        {
            try
            {
                UsuarioDto result = null;
       
                var query = SqlManager.GetSql(TSql.EFETUAR_LOGIN);

                var command = new SqlCommand(query, _connection);
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = usuario.Login;
                command.Parameters.Add("@senha", SqlDbType.VarChar).Value = usuario.Senha;

                var dataset = new DataSet();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataset);

                var rows = dataset.Tables[0].Rows;

                foreach (DataRow item in rows)
                {
                    var colunas = item.ItemArray;
                   
                    var codigo = Int32.Parse(colunas[0].ToString());
                    var login = colunas[1].ToString();
                

                 result =  new UsuarioDto { Id = codigo, Login = login };
                }
                adapter = null;
                dataset = null;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
