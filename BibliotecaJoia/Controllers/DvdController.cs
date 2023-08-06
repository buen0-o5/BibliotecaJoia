using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class DvdController : Controller
    {
        private readonly IDvdService _dvdService;
        public DvdController(IDvdService dvdService)
        {
            _dvdService = dvdService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
               var dvds = _dvdService.Listar();
                return View(dvds);
            }
            catch(Exception ex)
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
        public IActionResult Create([Bind("nome, genero")] DvdDto dvdDto)
        {
            try
            {
                _dvdService.Cadastrar(dvdDto);
                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Edit(int? Id)
        {
            try
            {

                if (Id == null)
                    return NotFound();
                var dvd = _dvdService.PesquisarPorId(Id.Value);
                if (dvd == null)
                    return NotFound();
                return View(dvd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,nome, genero")] DvdDto dvdDto)
        {
            try
            {
                if (dvdDto.Id == null)
                    return NotFound();

                _dvdService.Atualizar(dvdDto);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Details(int? id)
        {

            if (id == null)
                return NotFound();
            var dvd = _dvdService.PesquisarPorId(id.Value);

            if (dvd == null)
                return NotFound();

            return View(dvd);
        }

        public IActionResult Delete(int? id)
        {

            if (id == null)
                return NotFound();

            var dvd = _dvdService.PesquisarPorId(id.Value);
            if (dvd == null)
                return NotFound();

            return View(dvd);
        }
        [HttpPost]
        public IActionResult Delete([Bind("Id,nome, genero")] DvdDto dvdDto)
        {
            _dvdService.Excluir(dvdDto.Id);
            return RedirectToAction("List");
        }
    }
}
