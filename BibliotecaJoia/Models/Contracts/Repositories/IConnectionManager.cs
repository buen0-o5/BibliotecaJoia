using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    //Defini um contrato que permite obter uma conexão com o banco de dados. 
    public interface IConnectionManager
    {

      //instalada a dependencia system.data.sqlclient
     
      //Método que retorna uma instância de
     //SqlConnection.Esse é o objeto de conexão do namespace
     //System.Data.SqlClient, que é usado para estabelecer uma conexão com o banco de dados SQL Server.
      SqlConnection GetConnection();
    }
}
