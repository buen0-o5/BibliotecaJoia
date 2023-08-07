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
                #region Livro
                case TSql.CADASTRAR_LIVRO:
                    sql = "insert into livro (nome, autor, editora, statusLivroId ) values (@nome, @autor, @editora, @statusLivroId)";
                    break;

                case TSql.LISTAR_LIVRO:
                    sql = "select id, nome, autor, editora, statusLivroId  from livro order by nome";
                    break;
               
                case TSql.PESQUISAR_LIVRO:
                    sql = "select  id, nome, autor, editora from livro where id = @id";
                    break;

                case TSql.PESQUISAR_LIVRO_NOME:
                    sql = "select id, nome, autor, editora, statusLivroId from livro where nome like @nome + '%'";
                  //  SELECT convert(varchar(36), id) 'id', nome, autor, editora, statusLivroId FROM livro WHERE nome like  'TESTaa%';
                    break;

                case TSql.ATUALIZAR_LIVRO:
                    sql = "update livro set nome = @nome, autor = @autor, editora = @editora from livro where id = @id ";
                    break;

                case TSql.EXCLUIR_LIVRO:
                    sql = "delete from livro where id = @id";
                    break;
                #endregion

                #region Cliente
                //Cliente 7:59

                case TSql.CADASTRAR_CLIENTE:
                    sql = "insert into cliente(  nome, cpf, email,fone, statusClienteId ) values ( @nome, @cpf, @email, @fone, @statusClienteId)";
                    break;

                case TSql.LISTAR_CLIENTE:
                    sql = "select id, nome, cpf, email,fone, statusClienteId  from cliente order by nome";
                    break;
                case TSql.PESQUISAR_CLIENTE_NOME:
                    sql = "select  id, nome, cpf, email, fone, statusClienteId from cliente where nome like @nome + '%'";
                    //SELECT convert(varchar(36), id) 'id', nome, cpf, email, fone, statusClienteId  FROM cliente WHERE nome like  'Maria Agui%';
                   
                    break;

                case TSql.PESQUISAR_CLIENTE:
                    sql = "select  id, nome, cpf, email,fone, statusClienteId  from cliente where id = @id";
                    break;

                case TSql.ATUALIZAR_CLIENTE:
                    sql = "update cliente set nome = @nome, cpf = @cpf, email = @email, fone = @fone where  id = @id";
                    break;

                case TSql.EXCLUIR_CLIENTE:
                    sql = "delete from cliente where id = @id";
                    break;
                #endregion

                #region Usuario
                //Usuario 13:38

                case TSql.CADASTRAR_USUARIO:
                    sql = "insert into usuario (login, senha ) values (@login, @senha)";
                    break;
                case TSql.PESQUISAR_USUARIO_NOME:
                    sql = "select  id, login from usuario where login like @login + '%'";
                    break;
            
                case TSql.LISTAR_USUARIO:
                    sql = "select id, login, senha from usuario";
                    break;

                case TSql.PESQUISAR_USUARIO:
                    sql = "select id, login, senha from usuario where id = @id";
                    break;

                case TSql.ATUALIZAR_USUARIO:
                    sql = "update usuario set senha = @senha where id = @id ";
                    break;

                case TSql.EXCLUIR_USUARIO:
                    sql = "delete from usuario where id = @id";
                    break;
                case TSql.EFETUAR_LOGIN:
                    sql = "select id, login from usuario where login = @login and senha = @senha";
                    break;

                #endregion

                #region Emprestimo Livro
                case TSql.EFETUAR_EMPRESTIMO_LIVRO:
                    sql = "insert into emprestimoLivro(clienteId, usuarioId, livroId,statusEmprestimoAtual,dataEmprestimo, dataDevolucao) values(@clienteId, @usuarioId,@livroId,@statusEmprestimoAtual, @dataEmprestimo, @dataDevolucao)";
                                                                                                                    
                    break;
                case TSql.EFETUAR_DEVOLUCAO_LIVRO:
                    sql = "update emprestimoLivro set dataDevolucaoEfetiva = @dataDevolucaoEfetiva, statusEmprestimoAtual = @statusEmprestimoAtual  where id = @id";
                    break;
                case TSql.ATUALIZAR_STATUS_LIVRO:
                    sql = "update livro set statusLivroId = @statusLivroId where id = @id";
                    break;
                #endregion

                #region Consulta Emprestimo
                case TSql.CONSULTAR_EMPRESTIMOS_LIVROS:
                    sql = @"select 
                                 l.nome 'livro', l.autor, l.editora,
                                 c.nome 'cliente', c.cpf, 
                                 el.dataEmprestimo, el.dataDevolucao, el.dataDevolucaoEfetiva, 
                                 sl.status 'status do livro', 
                                 u.login 'biblioteca',
                                 el.id, l.id 'livroId'
                             from 
                                 livro l inner join
                                 emprestimoLivro el on el.livroId = l.id inner join
                                 cliente c on el.clienteId = c.id inner join
                                 statusLivro sl on el.statusEmprestimoAtual = sl.id inner join
                                 usuario u on el.usuarioId = u.id";
                    break;
                case TSql.PESQUISAR_EMPRESTIMOS_LIVROS:
                    sql = @"select 
                                 l.nome 'livro', l.autor, l.editora,
                                 c.nome 'cliente', c.cpf, 
                                 el.dataEmprestimo, el.dataDevolucao, el.dataDevolucaoEfetiva, 
                                 sl.status 'status do livro', 
                                 u.login 'bibliotecario',
                                 el.id, l.id 'livroId'
                             from 
                                 livro l inner join
                                 emprestimoLivro el on el.livroId = l.id inner join
                                 cliente c on el.clienteId = c.id inner join
                                 statusLivro sl on el.statusEmprestimoAtual = sl.id inner join
                                 usuario u on el.usuarioId = u.id
                             where
                                el.id = @id and l.nome = @nomeLivro and  c.nome = @nomeCliente and dateadd(dd, 0, datediff(dd, 0, el.dataEmprestimo)) = @dataEmprestimo
                              order by
                                   el.dataEmprestimo desc
                             ";
                    break;
                case TSql.ATUALIZAR_STATUS_EMPRESTIMOS_LIVROS:
                    sql = "SP_ATUALIZA_STATUS_EMPRESTIMO_LIVRO";
                    break;
                #endregion

                #region DVD
                case TSql.CADASTRAR_DVD:
                    sql = "insert into dvd (nome, genero, statusDvdId ) values (@nome, @genero, @statusDvdId  )";
                    break;

                case TSql.LISTAR_DVD:
                    sql = "select id, nome, genero, statusDvdId from dvd order by nome";
                    break;

                case TSql.PESQUISAR_DVD:
                    sql = "select  id, nome, genero from dvd where id = @id";
                    break;

                case TSql.PESQUISAR_DVD_NOME:
                    sql = "select id, nome, genero, statusDvdId from dvd where nome like @nome + '%'";
                    //  SELECT convert(varchar(36), id) 'id', nome, autor, editora, statusLivroId FROM livro WHERE nome like  'TESTaa%';
                    break;

                case TSql.ATUALIZAR_DVD:
                    sql = "update dvd set nome = @nome, genero = @genero  from dvd where id = @id ";
                    break;

                case TSql.EXCLUIR_DVD:
                    sql = "delete from dvd where id = @id";
                    break;
                #endregion

                #region Emprestimo Dvd
                case TSql.EFETUAR_EMPRESTIMO_DVD:
                    sql = "insert into emprestimoDvd(clienteId, usuarioId, dvdId,statusEmprestimoAtual,dataEmprestimo, dataDevolucao) values(@clienteId, @usuarioId,@dvdId,@statusEmprestimoAtual, @dataEmprestimo, @dataDevolucao)";
                    break;
                case TSql.EFETUAR_DEVOLUCAO_DVD:
                    sql = "update emprestimoDvd set dataDevolucaoEfetiva = @dataDevolucaoEfetiva, statusEmprestimoAtual = @statusEmprestimoAtual  where id = @id";
                    break;
                case TSql.ATUALIZAR_STATUS_DVD:
                    sql = "update dvd set statusDvdId = @statusDvdId where id = @id";
                    break;
                #endregion

                #region Consulta Emprestimo
                case TSql.CONSULTAR_EMPRESTIMOS_DVD:
                    sql = @"select 
                                 d.nome 'dvd', d.genero,
                                 c.nome 'cliente', c.cpf, 
                                 el.dataEmprestimo, el.dataDevolucao, el.dataDevolucaoEfetiva, 
                                 sl.status 'status do livro', 
                                 u.login 'biblioteca',
                                 el.id, d.id 'dvdId'
                             from 
                                 dvd d inner join
                                 emprestimoDvd el on el.dvdId = d.id inner join
                                 cliente c on el.clienteId = c.id inner join
                                 statusDvd sl on el.statusEmprestimoAtual = sl.id inner join
                                 usuario u on el.usuarioId = u.id";
                    break;
                case TSql.PESQUISAR_EMPRESTIMOS_DVD:
                    sql = @"select 
                                 d.nome 'dvd', d.genero,
                                 c.nome 'cliente', c.cpf, 
                                 el.dataEmprestimo, el.dataDevolucao, el.dataDevolucaoEfetiva, 
                                 sl.status 'status do dvd', 
                                 u.login 'bibliotecario',
                                 el.id, d.id 'dvdId'
                             from 
                                 dvd d inner join
                                 emprestimoDvd el on el.dvdId = d.id inner join
                                 cliente c on el.clienteId = c.id inner join
                                 statusLivro sl on el.statusEmprestimoAtual = sl.id inner join
                                 usuario u on el.usuarioId = u.id
                             where
                                el.id = @id and d.nome = @nomedvd and  c.nome = @nomeCliente and dateadd(dd, 0, datediff(dd, 0, el.dataEmprestimo)) = @dataEmprestimo
                              order by
                                   el.dataEmprestimo desc
                             ";
                    break;
                case TSql.ATUALIZAR_STATUS_EMPRESTIMOS_DVD:
                    sql = "SP_ATUALIZA_STATUS_EMPRESTIMO_DVD";
                    break;
                    #endregion
            }

            return sql;
        }
    }
}
