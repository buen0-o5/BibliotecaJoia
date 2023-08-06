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
    public class EmprestimoDvdController : Controller
    {
        private readonly IEmprestimoDvdService _emprestimoDvdService;
        private readonly IClienteService  _clienteService;
        private readonly IDvdService _dvdService;

        public EmprestimoDvdController(IEmprestimoDvdService emprestimoDvdService,
           IClienteService clienteService,
           IDvdService dvdService) 
        {
            _emprestimoDvdService = emprestimoDvdService;
            _clienteService = clienteService;
            _dvdService = dvdService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EfetuarEmprestimo([Bind("Cliente, Dvd")] EmprestimoDtoDvd emprestimo)
        {
            string userId = HttpContext.Session.GetString("_UserId");
            string login = HttpContext.Session.GetString("_Login");
            EmprestimoDvdDto entidade = new EmprestimoDvdDto();

            entidade.Cliente = _emprestimoDvdService.PesquisarClientePorNome(emprestimo.Cliente);
            entidade.ClienteId = entidade.Cliente.Id.ToString();

            entidade.Dvd = _emprestimoDvdService.PesquisarDvdPorNome(emprestimo.Dvd);
            entidade.DvdId = entidade.Dvd.Id.ToString();

            entidade.UsuarioId = Int32.Parse(userId);
            entidade.Usuario = new UsuarioDto { Id = Int32.Parse(userId), Login = login };

            _emprestimoDvdService.EfetuarEmprestimo(entidade);

            return RedirectToAction("Consulta");
        }

        public IActionResult Details(int id, string nomeDvd, string nomeCliente, string dataEmprestimo)
        {
            try
            {
                DateTime dataEmprestimoFormatada = DateTime.Parse(dataEmprestimo);
                ConsultaEmprestimoDvdDto result = _emprestimoDvdService.consultaEmprestimo(id, nomeDvd, nomeCliente, dataEmprestimoFormatada);
                return View(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult EfetuarDevolucao(int emprestimoId,string dvdId) 
        {
            try
            {
                _emprestimoDvdService.EfetuarDevolucao(emprestimoId, dvdId);
                return RedirectToAction("Consulta");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public IActionResult Consulta()
        {
            try
            {
                _emprestimoDvdService.AtualizarStatusEmprestimosDvds();
                var emprestimos = _emprestimoDvdService.consultaEmprestimos();
                return View(emprestimos);
            }
            catch(Exception ex)
            {
                throw ex; 
            }
         
        }
        public IActionResult PesquisarClientes(string term)
        {
            var clientes = _clienteService.Listar();
            var clientesAtivos = clientes.Where(p => p.StatusClienteId.Equals("1")).ToList();
            var listaNomeClientes = clientesAtivos.Select(p => p.Nome).ToList();
            var filtro = listaNomeClientes.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return Json(filtro);
        }

        public IActionResult Pesquisardvds(string term)
        {
            var dvds= _dvdService.Listar();
            var dvdAtivos = dvds.Where(p => p.statusDvdId == 1).ToList();
            var listaNomeDvds = dvdAtivos.Select(p => p.nome).ToList();
            var filtro = listaNomeDvds.Where(p => p.Contains(term, StringComparison.CurrentCultureIgnoreCase)).ToList();

            return Json(filtro);
        }


    }
}
