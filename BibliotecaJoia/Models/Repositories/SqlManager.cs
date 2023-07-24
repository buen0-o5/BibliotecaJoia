using BibliotecaJoia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    // Classe que fornece consultas SQL pré-definidas para operações CRUD relacionadas aos livros.
   // Essa classe utiliza a enumeração TSql para identificar e retornar a consulta SQL apropriada de acordo com a operação desejada.
    public class SqlManager
    {
        

        // Método estático que retorna a consulta SQL pré-definida de acordo com a enumeração TSql informada.
        public static string GetSql(TSql tsql)
        {
            var sql = "";
            switch (tsql) 
            {
                case TSql.CADASTRAR_LIVRO:
                    sql = "insert into livro ( id, nome, autor, editora ) values (@id, @nome, @autor, @editora)";
                    break;

                case TSql.LISTAR_LIVRO:
                    sql = "select id, nome, autor, editora from livro order by nome";
                    break;
               
                case TSql.PESQUISAR_LIVRO:
                    sql = "select id, nome, autor, editora from livro where id = @id";
                    break;

                case TSql.ATUALIZAR_LIVRO:
                    sql = "update livro set nome = @nome, autor = @autor, editora = @editora from livro where id = @id ";
                    break;

                case TSql.EXCLUIR_LIVRO:
                    sql = "delete from livro where id = @id";
                    break;
            }


            return sql;
        }
    }
}
