using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
              var clientes = _clienteService.Listar();
              return View(clientes);
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
        public IActionResult Create([Bind("Nome, CPF, Email, Fone")] ClienteDto cliente)
        {
            try
            {

                _clienteService.Cadastrar(cliente);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IActionResult Edit(string? Id)
        {
       
            if (string.IsNullOrEmpty(Id))
                return NotFound();

            var cliente = _clienteService.PesquisarPorId(Id);
            if (cliente == null)
                return NotFound();
            return View(cliente);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Nome, CPF, Email, Fone, StatusClienteId")] ClienteDto cliente)
        {
            if (string.IsNullOrEmpty(cliente.Id))
                return NotFound();
            try
            {

                _clienteService.Atualizar(cliente);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public IActionResult Details(string? id)
        {

            if (string.IsNullOrEmpty(id))
                return NotFound();
            var cliente = _clienteService.PesquisarPorId(id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }


        public IActionResult Delete(string? id)
        {

            if (string.IsNullOrEmpty(id))
                return NotFound();

            var cliente = _clienteService.PesquisarPorId(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }


        [HttpPost]
        public IActionResult Delete([Bind("Id, Nome, CPF, Email, Fone, StatusClienteId")] ClienteDto cliente)
        {
            _clienteService.Excluir(cliente.Id);
            return RedirectToAction("List");
        }
    }
}
