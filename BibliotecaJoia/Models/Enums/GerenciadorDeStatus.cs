using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Enums
{
    public class GerenciadorDeStatus
    {
        //É uma lista que contém todos os valores da enumeração 
        private static List<StatusLivro> statusLivrosList = new List<StatusLivro>
        {
            StatusLivro.DISPONIVEL,
            StatusLivro.EMPRESTADO,
            StatusLivro.ATRASO_DEVOLUCAO,
            StatusLivro.USO_LOCAL
        };


        //Esse método recebe um valor inteiro id como parâmetro e retorna o status do livro
        //correspondente ao valor do id. Ele faz isso filtrando a lista statusLivrosList usando
        //o método FirstOrDefault. Esse método procura o primeiro elemento na lista que atenda
        //à condição especificada. Nesse caso, a condição é que o valor hashcode do status seja
        //igual ao valor do id. Se for encontrado um status com o mesmo hashcode, esse status é
        //retornado. Caso contrário, será retornado null.
        public static StatusLivro PesquisarStatusDoLivroPeloId(int id)
        {
            //Flitro que retorna o codigo igual o ID
            var status = statusLivrosList.FirstOrDefault(p => p.GetHashCode().Equals(id));
            return status;
        }

        //Esse método recebe uma string nome como parâmetro e retorna o status do livro
        //correspondente ao nome. Ele faz isso convertendo o nome para letras maiúsculas e
        //substituindo espaços por underscores, para garantir que a comparação seja feita de
        //forma insensível a maiúsculas/minúsculas e espaços. Em seguida, ele pesquisa na lista
        //statusLivrosList usando o método FirstOrDefault para encontrar o primeiro status cujo
        //nome corresponde ao nomePesquisa. Se for encontrado um status com o mesmo nome, esse
        //status é retornado. Caso contrário, será retornado null.
        public static StatusLivro PesquisarStatusDoLivroPeloNome(string nome)
        {
            var nomePesquisa = nome.ToUpper().Replace(" ", "_");
            var status = statusLivrosList.FirstOrDefault(p => p.ToString().Equals(nomePesquisa));
            return status;
        }

        private static List<StatusCliente> statusClientesList = new List<StatusCliente>
        {
            StatusCliente.ATIVO,
            StatusCliente.INATIVO,
            StatusCliente.SUSPENSO
        };

        public static StatusCliente PesquisarStatusClientePeloId(int id)
        {
            var status = statusClientesList.FirstOrDefault(p => p.GetHashCode().Equals(id));
            return status;
        }

        public static StatusCliente PesquisarStatusDoClientePeloNome(string nome)
        {
            var nomePesquisa = nome.ToUpper().Replace(" ", "_");
            var status = statusClientesList.FirstOrDefault(p => p.ToString().Equals(nomePesquisa));
            return status;
        }
    }
}
