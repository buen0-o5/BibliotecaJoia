using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public class EmprestimoLivro
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public string LivroId { get; set; }
        public Livro Livro { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

       
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolucaoEfetiva { get; set; }
        public void RealizarEmprestimo()
        {
            ValidarEmprestimo();
            this.DataEmprestimo = DateTime.Now;
            this.DataDevolucao = DateTime.Parse(this.DataEmprestimo.AddDays(7).ToShortDateString());
        }
        public void RealizarDevolucao()
        {
            this.DataDevolucaoEfetiva = DateTime.Now;
        }

        private void ValidarEmprestimo()
        {
            if(string.IsNullOrEmpty(this.ClienteId)  || string.IsNullOrEmpty(this.LivroId) || this.UsuarioId == 0)
            {
                throw new Exception("Dados Invalidos");
            }
        }
        
    }
}
