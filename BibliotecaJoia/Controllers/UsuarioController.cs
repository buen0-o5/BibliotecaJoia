using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using Microsoft.AspNetCore.Http;
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
                // Criando um objeto UsuarioDto com as informações de login e senha fornecidas.
                UsuarioDto usuario = new UsuarioDto { Login = login, Senha = senha };
               
                /* Chamando o serviço de usuário (_usuarioService) para efetuar o login.
                 O método EfetuarLogin irá verificar as credenciais fornecidas e retornar
                 um resultado.*/
                UsuarioDto resultado = _usuarioService.EfetuarLogin(usuario);

                // Verificando o resultado do login
                if (resultado != null)
                {
                    /*Se as credenciais estiverem corretas, armazena informações de sessão
                    utilizando o TempData.
                    TempData é usado para armazenar temporariamente 
                    informações que serão acessadas apenas na próxima solicitação.*/
                    //dados de sessao
                    TempData["userId"] = resultado.Id; // ID do usuário logado.
                    TempData["login"] = resultado.Login;// Nome do usuário logado.

                    //Guardando valor na sessions
                    HttpContext.Session.SetString("_UserId", resultado.Id.ToString());
                    HttpContext.Session.SetString("_Login", resultado.Login);


                    TempData["loginError"] = false;// Indica que não houve erro de login.

                    // Redireciona para a página de empréstimos após o login bem-sucedido.
                    return Redirect("/Emprestimo/Consulta");
                }
                else
                {
                    /* Se as credenciais estiverem incorretas, define uma variável TempData
                      para indicar um erro de login.*/
                    TempData["loginError"] = true;
                    /* Redireciona novamente para a página de login (Index) para que o usuário
                    possa tentar novamente.*/
                    return RedirectToAction("Index");
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

                HttpContext.Session.Remove("_UserId");
                HttpContext.Session.Remove("_Login");


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
