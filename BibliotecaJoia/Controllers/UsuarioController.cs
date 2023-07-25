using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class UsuarioController : Controller
    {
        //rotiamento especifico
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {

            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha )
        {
            try
            {
                UsuarioDto usuario = new UsuarioDto { Login = login, Senha = senha };
                UsuarioDto resultado = _usuarioService.EfetuarLogin(usuario);

                if(resultado != null)
                {
                    TempData["userId"] = resultado.Id;
                    TempData["login"] = resultado.Login;
                    TempData["loginError"] = false;


                    return Redirect("/Emprestimo/Index");
                }
                else
                {
                    TempData["loginError"] = true;
                    return Redirect("Index");
                }
              

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Logout()
        {
            try
            {
                    TempData["userId"] = null;
                    TempData["login"] = null;
                    TempData["loginError"] = false;
                     return Redirect("/Home");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
