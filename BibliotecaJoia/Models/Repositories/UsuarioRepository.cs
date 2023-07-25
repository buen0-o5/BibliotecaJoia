using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IContextData _contextData;
        public UsuarioRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(Usuario entidade)
        {
            _contextData.AtualizarUsuario(entidade);
        }

        public void Cadastrar(Usuario entidade)
        {
            _contextData.CadastrarUsuario(entidade);
        }

        public UsuarioDto EfetuarLogin(UsuarioDto usuario)
        {
          return _contextData.EfetuarLogin(usuario);
        }

        public void Excluir(int id)
        {
            _contextData.ExcluirUsuario(id);
        }

        public List<Usuario> Listar()
        {
            return _contextData.ListarUsuario();
        }

        public Usuario PesquisarPorId(int id)
        {
            return _contextData.PesquisarUsuarioPorId(id);
        }
    }
}
