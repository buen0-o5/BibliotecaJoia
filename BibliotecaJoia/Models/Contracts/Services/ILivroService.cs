using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
    //Essa interface  lida com a camada de lógica de negócios. 
    public interface ILivroService : IService<LivroDto, int>
    {
    }
}
