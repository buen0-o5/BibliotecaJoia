using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
   public interface IUsuarioService: IService<UsuarioDto, int>
    {
        UsuarioDto EfetuarLogin(UsuarioDto usuario);
        UsuarioDto PesquisarUsarioPorNome(string login);
    }
}
