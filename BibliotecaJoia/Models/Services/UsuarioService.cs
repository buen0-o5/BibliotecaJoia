using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Services
{
    public class UsuarioService : IUsuarioService
    {
      
       private readonly IUsuarioRepository _usuarioRepository;
       public  UsuarioService(IUsuarioRepository usuarioRepository){
            _usuarioRepository = usuarioRepository;
        }

        public void Atualizar(UsuarioDto usuario)
        {
            try
            {
                var objusuario = usuario.ConverteParaEntidade();
                _usuarioRepository.Atualizar(objusuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(UsuarioDto usuario)
        {
            try
            {
                var objusuario = usuario.ConverteParaEntidade();
                _usuarioRepository.Cadastrar(objusuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDto EfetuarLogin(UsuarioDto usuario)
        {
            try
            {
               
               var validacao = _usuarioRepository.EfetuarLogin(usuario);
                return validacao; ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                _usuarioRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UsuarioDto> Listar()
        {
            try
            {
                var usuarios = new List<UsuarioDto>();
                var lista = _usuarioRepository.Listar();
                foreach (var item in lista)
                {
                    var usuario = item.ConverteParaDTO();
                    usuarios.Add(usuario);
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UsuarioDto PesquisarPorId(int id)
        {
            try
            {
                var usuario = _usuarioRepository.PesquisarPorId(id);
                return usuario.ConverteParaDTO();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
