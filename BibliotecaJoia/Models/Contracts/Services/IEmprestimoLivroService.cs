using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Contracts.Services
{
    public interface IEmprestimoLivroService
    {
        void EfetuarEmprestimo(EmprestimoLivroDto emprestimoLivro);
        void EfetuarDevolucao(EmprestimoLivroDto emprestimoLivro);
    }
}
