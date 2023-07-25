using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.DTO
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario ConverteParaEntidade()
        {
            return new Usuario
            {
                Id = this.Id,
                Login = this.Login,
                Senha = this.Senha
            };
        }
    }
}
