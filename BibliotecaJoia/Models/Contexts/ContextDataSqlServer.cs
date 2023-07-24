using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.DTO;
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
        // Objeto SqlConnection que representa a conexão com o banco de dados.
        private readonly SqlConnection _connection = null;

        // Construtor da classe que recebe um objeto IConnectionManager como parâmetro.
        // O IConnectionManager é utilizado para obter a conexão com o banco de dados por meio do método GetConnection().
        public ContextDataSqlServer(IConnectionManager connectionManager)
        {
            _connection = connectionManager.GetConnection();
        }

        //Metodo de atualizar dados 
        public void Atualizar(LivroDto livro)
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

        public void Cadastrar(LivroDto livro)
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

                //executa a operaçao
                command.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public void Excluir(string id)
        {
            try
            {
                _connection.Open();
                var query = SqlManager.GetSql(TSql.EXCLUIR_LIVRO);

                var command = new SqlCommand(query, _connection);

                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id ;
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

        public List<LivroDto> Listar()
        {
            var livros = new List<LivroDto>();
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
                    var livro = new LivroDto(id, nome, autor, editora);

                    // Adiciona o livro à coleção (lista) de livros
                    livros.Add(livro);
                }

                // Libera recursos, definindo os objetos como nulos para permitir a coleta de lixo
                adapter = null;
                dataset = null;

                // Retorna a lista de livros preenchida com os dados do banco de dados
                return livros;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public LivroDto PesquisarPorId(string id)
        {
            try
            {
                LivroDto livro = null;
            
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

                    livro = new LivroDto(id, nome, autor, editora);
                    
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
    }
}
