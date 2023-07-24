using BibliotecaJoia.Models.DTO;
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
        void Cadastrar(LivroDto livro);
        List<LivroDto> Listar();

        LivroDto PesquisarPorId(string id);

        void Atualizar(LivroDto livro);
        void Excluir(string id);
    }
}
