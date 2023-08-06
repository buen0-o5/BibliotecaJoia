using BibliotecaJoia.Models.Contracts.Services;
using BibliotecaJoia.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BibliotecaJoia.Controllers
{

    // LivroController: Classe responsável por tratar as requisições relacionadas aos livros na aplicação.

    // ILivroService é uma interface que define as operações de negócio relacionadas aos livros,
    // como busca, criação, atualização e exclusão de livros.

    // _livroService: Dependência injetada na classe LivroController por meio do construtor.
    // Representa uma instância de uma classe que implementa a interface ILivroService,
    // fornecendo a lógica de negócio necessária para manipular os dados dos livros.

    //[Authorize] // isso serve pra usar a autenticação do cookie, o usuário só vai entrar nessa controller se estiver autenticado
    public class LivroController : Controller
    {

        // Construtor da classe LivroController.
        // Recebe uma implementação concreta de ILivroService através da injeção de dependências.
        // Essa abordagem permite que o controlador utilize as operações de negócio sem conhecer
        // a implementação específica, promovendo o desacoplamento e facilitando a manutenção e testabilidade.


        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }


        // Action responsável por retornar a view "Index".
        public IActionResult Index()
        {
            // Retorna a view "Index".
            return View();
        }

        // Action responsável por retornar a lista de livros para a view "List".
        // Essa action invoca o serviço _livroService para obter a lista de livros através do método Listar().
        // Em seguida, os livros obtidos são enviados para a view "List" para exibição no navegador.
        // Caso ocorra algum erro durante a execução da ação, uma exceção será lançada para que
        // o tratamento adequado seja realizado.
        public IActionResult List()
        {
            try
            {
                // Obtém a lista de livros do serviço de livros (_livroService).
                var livros = _livroService.Listar();
                // Retorna a view "List" passando a lista de livros como modelo.
                return View(livros);
            }
            catch (Exception ex)
            {
                // Em caso de erro, a exceção é propagada para que o tratamento adequado seja realizado.
                throw ex;
            }

        }

        // Action responsável por retornar a view "Create".
        public IActionResult Create()
        {
            return View();
        }


        // Action responsável por tratar o envio de dados do formulário para criar um novo livro.
        // Essa action é acionada quando o formulário é submetido por meio de um método HTTP POST.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome, Autor, Editora")] LivroDto livro)
        {

            try
            {
                // O parâmetro "livro" contém os dados enviados pelo formulário, como o nome, autor e editora do livro.

                // Chama o serviço _livroService para cadastrar (criar) o novo livro com base nos dados fornecidos.

                _livroService.Cadastrar(livro);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        // Action responsável por tratar a edição dos dados de um livro específico.
        // Recebe como parâmetro o "Id" do livro a ser editado.
        // Verifica se o campo "Id" não é nulo ou vazio. Caso seja, retorna uma resposta "NotFound" indicando que o livro não foi encontrado.
        // Utiliza o serviço "_livroService" para pesquisar se o "Id" está cadastrado no banco de dados.
        // Caso o "Id" seja válido e corresponda a um livro existente, a view "Edit" é retornada, contendo os dados do livro para edição.
        public IActionResult Edit(int? Id)
        {
            // Verifica se o campo "Id" não é nulo ou vazio.
            if (Id == null)
                return NotFound();

            // Chama o serviço "_livroService" para pesquisar se o "Id" está cadastrado no banco de dados.
            var livro = _livroService.PesquisarPorId(Id.Value);

            // Verifica se o "Id" corresponde a um livro válido no banco de dados.
            if (livro == null)
                return NotFound();
            // Se o "Id" for válido e corresponder a um livro existente, a view "Edit" é retornada,
            // contendo os dados do livro para edição.
            return View(livro);
        }


        // Action POST que trata a submissão dos dados alterados do livro.
        // Recebe um objeto "LivroDto" com os dados do livro editado, usando o atributo [Bind] para indicar quais campos devem ser vinculados.
        // Verifica se o campo "Id" do livro editado não é nulo ou vazio.
        // Caso seja, retorna uma resposta "NotFound" indicando que o livro não foi encontrado.
        // Utiliza o serviço "_livroService" para atualizar os dados do livro no banco de dados com base nos dados recebidos.
        // Se a atualização for bem-sucedida, redireciona o usuário para a action "List" para visualizar a lista atualizada de livros.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Nome,Autor,Editora")] LivroDto livro)
        {
            // Verifica se o campo "Id" do livro editado não é nulo ou vazio.
            if (livro.Id == null)
                return NotFound();
            try
            {
                // Chama o serviço "_livroService" para atualizar os dados do livro no banco de dados com base nos dados recebidos.
                _livroService.Atualizar(livro);
                // Se a atualização for bem-sucedida, redireciona o usuário para a action "List"
                // para visualizar a lista atualizada de livros.
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }


        // Action responsável por exibir os detalhes de um livro específico com base no seu "Id".
        // Recebe como parâmetro o "id" do livro a ser exibido.
        // Verifica se o campo "id" não é nulo ou vazio. Caso seja, retorna uma resposta "NotFound" indicando que o livro não foi encontrado.
        // Utiliza o serviço "_livroService" para pesquisar se o "id" está cadastrado no banco de dados.
        // Caso o "id" seja válido e corresponda a um livro existente, a view "Details" é retornada,
        // contendo os detalhes do livro para visualização.
        public IActionResult Details(int? id)
        {

            if (id == null)
                return NotFound();
            var livro = _livroService.PesquisarPorId(id.Value);

            if (livro == null)
                return NotFound();

            return View(livro);
        }


        // Action responsável por excluir um livro do banco de dados.
        // Recebe como parâmetro o "id" do livro a ser excluído.
        // Verifica se o campo "id" não é nulo ou vazio. Caso seja, retorna uma resposta "NotFound" indicando que o livro não foi encontrado.
        // Utiliza o serviço "_livroService" para pesquisar se o "id" está cadastrado no banco de dados.
        // Caso o "id" seja válido e corresponda a um livro existente, a view "Delete" é retornada,
        // exibindo os dados do livro a ser excluído, permitindo que o usuário confirme a exclusão.
        public IActionResult Delete(int? id)
        {

            if (id == null)
                return NotFound();

            var livro = _livroService.PesquisarPorId(id.Value);
            if (livro == null)
                return NotFound();

            return View(livro);
        }


        // Action POST responsável por excluir um livro do banco de dados.
        // Recebe um objeto "LivroDto" com os dados do livro a ser excluído, usando o atributo [Bind] para indicar quais campos devem ser vinculados.
        // Utiliza o serviço "_livroService" para excluir o livro com base no "Id" recebido.
        // Após a exclusão bem-sucedida, redireciona o usuário para a action "List" para visualizar a lista atualizada de livros.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind("Id, Nome, Autor, Editora")] LivroDto livro)
        {
            _livroService.Excluir(livro.Id);
            return RedirectToAction("List");
        }

    }
}
