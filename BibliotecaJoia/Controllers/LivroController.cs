using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
              var livros = _livroService.Listar();
                return View(livros);
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
        public IActionResult Create([Bind("Nome, Autor, Editora")]LivroDto livro)
        {

            try
            {
                _livroService.Cadastrar(livro);
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

            var livro = _livroService.PesquisarPorId(Id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Nome,Autor,Editora")] LivroDto livro)
        {
            if (string.IsNullOrEmpty(livro.Id))
                return NotFound();
            try
            {
                _livroService.Atualizar(livro);
                return RedirectToAction("List");
            }catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public IActionResult Details(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var livro = _livroService.PesquisarPorId(id);
            if (livro == null)
                return NotFound();
            
            return View(livro);
        }
        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var livro = _livroService.PesquisarPorId(id);
            if (livro == null)
                return NotFound();
            return View(livro);
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id, Nome, Autor, Editora")] LivroDto livro)
            {
                _livroService.Excluir(livro.Id);
                return RedirectToAction("List");
            }
    
    }
}
