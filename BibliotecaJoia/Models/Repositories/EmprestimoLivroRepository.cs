﻿using BibliotecaJoia.Models.Contracts.Contexto;
using BibliotecaJoia.Models.Contracts.Repositories;
using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Repositories
{
    public class EmprestimoLivroRepository : IEmprestimoLivroRepository
    {
        private readonly IContextData _contextData;
       public EmprestimoLivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public ConsultaEmprestimoDto consultaEmprestimo(string nomeLivro, string nomeCliente, DateTime dataEmprestimo)
        {
           ConsultaEmprestimoDto result = _contextData.consultaEmprestimo(nomeLivro, nomeCliente, dataEmprestimo);
           return result;
        }

        public List<ConsultaEmprestimoDto> consultaEmprestimos()
        {
           return _contextData.consultaEmprestimos();
        }

        public void EfetuarDevolucao(int emprestimoId, string livroId)
        {
            _contextData.EfetuarDevolucao(emprestimoId, livroId);
        }

        public void EfetuarEmprestimo(EmprestimoLivro emprestimoLivro)
        {
            _contextData.EfetuarEmprestimo(emprestimoLivro);
        }
    }
}