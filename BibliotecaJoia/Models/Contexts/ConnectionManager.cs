using BibliotecaJoia.Models.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contexts
{
    // Classe que implementa a interface IConnectionManager, responsável por gerenciar a conexão com o banco de dados.
    public class ConnectionManager : IConnectionManager
    {
        // Nome da string de conexão configurada no arquivo de configuração (appsettings.json).
        private static string _connectionNmae = "biblioteca";

        // Objeto SqlConnection que representa a conexão com o banco de dados.
        // É utilizado o modificador "static" para garantir que a mesma conexão seja compartilhada
        // entre todas as instâncias dessa classe.
        private static SqlConnection connection = null;

        // Construtor da classe que recebe a configuração da aplicação por meio de um objeto IConfiguration.
        public ConnectionManager(IConfiguration configuration)
        {
            // Obtém a string de conexão configurada no arquivo de configuração (appsettings.json) com
            // base no nome definido em _connectionName.
            var connStr = configuration.GetConnectionString(_connectionNmae);

            // Verifica se a conexão ainda não foi inicializada.
            if (connection == null)
                // Cria uma nova instância de SqlConnection utilizando a string de conexão obtida.
                connection = new SqlConnection(connStr);
        }

        // Método que retorna a conexão com o banco de dados.
        // Esse método é chamado sempre que é necessário obter uma conexão para realizar operações no banco de dados.
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
