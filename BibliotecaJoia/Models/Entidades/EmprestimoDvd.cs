using BibliotecaJoia.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public class EmprestimoDvd
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string DvdId { get; set; }
        public Dvd Dvd { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


        public string StatusEmprestimoAtual { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolucaoEfetiva { get; set; }

        public void RealizarEmprestimo()
        {
            ValidarEmprestimo();
            this.DataEmprestimo = DateTime.Now;
            this.DataDevolucao = DateTime.Parse(this.DataEmprestimo.AddDays(7).ToShortDateString());
        }

        public void RealizarDevolicao() 
        {
            this.DataDevolucaoEfetiva = DateTime.Now;
        }


        public void ValidarEmprestimo() 
        {
            if (string.IsNullOrEmpty(this.ClienteId) || string.IsNullOrEmpty(this.DvdId) || this.UsuarioId == 0)
            {
                throw new Exception("Dados Invalidos");
            }
        }
    }
}
