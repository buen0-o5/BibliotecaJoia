using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
   public interface IConnectionManager
    {

        
        //instalada a dependencia system.data.sqlclient
        SqlConnection GetConnection();
    }
}
