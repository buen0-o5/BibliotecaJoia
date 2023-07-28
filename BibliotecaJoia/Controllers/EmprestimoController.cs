using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoLivroService _emprestimo;
        private readonly IClienteService _clienteService;
        private readonly ILivroService _livroService;
       public EmprestimoController(
           IEmprestimoLivroService emprestimo,
           IClienteService clienteService,
           ILivroService livroService)
        {
            _emprestimo = emprestimo;
            _clienteService = clienteService;
            _livroService = livroService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EfetuarEmprestimo([Bind("Cliente, Livro")] EmprestimoDto emprestimo)
        {
            string login = HttpContext.Session.GetString("_Login");
            return null;
        }

        public IActionResult PesquisarClientes(string term)
        {
          var clientes =  _clienteService.Listar();
          var clientesAtivos = clientes.Where(p => p.StatusClienteId.Equals("1")).ToList();
          var listaNomeClientes = clientesAtivos.Select(p => p.Nome).ToList();
          var filtro = listaNomeClientes.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();
          
          return Json(filtro);
        }

        public IActionResult PesquisarLivros(string term)
        {
            var livros = _livroService.Listar();
            var livrosAtivos = livros.Where(p => p.StatusLivroId.Equals("1")).ToList();
            var listaNomeLivros = livrosAtivos.Select(p => p.Nome).ToList();
            var filtro = listaNomeLivros.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return Json(filtro);
        }






    }
}
