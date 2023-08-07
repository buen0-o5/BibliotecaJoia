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

        public IActionResult List()
        {
            try
            {
                var usuarios = _usuarioService.Listar();
                return View(usuarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Login,Senha")] UsuarioDto usuario)
        {
            try
            {

                _usuarioService.Cadastrar(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public IActionResult Edit(int? Id)
        {

            if (Id == null)
                return NotFound();

            var usuario = _usuarioService.PesquisarPorId(Id.Value);
            if (usuario == null)
                return NotFound();
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("login,senha")] UsuarioDto usuario)
        {
            if (usuario.Id == null)
                return NotFound();
            try
            {

                _usuarioService.Atualizar(usuario);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        public IActionResult Details(int? id)
        {

            if (id == null)
                return NotFound();
            var cliente = _usuarioService.PesquisarPorId(id.Value);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }
        public IActionResult Delete(int? id)
        {

            if (id == null)
                return NotFound();

            var usuario = _usuarioService.PesquisarPorId(id.Value);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Delete([Bind("login,senha")] UsuarioDto usuario)
        {
            _usuarioService.Excluir(usuario.Id);
            return RedirectToAction("List");
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
                    return Redirect("/Home");
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
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
