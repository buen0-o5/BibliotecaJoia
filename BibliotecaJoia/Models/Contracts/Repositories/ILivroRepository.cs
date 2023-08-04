using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Repositories
{
    public interface ILivroRepository : IRepository<Livro, int>
    {
        
        //Essa interface  lida com a camada de acesso aos dados
      
    }
}
