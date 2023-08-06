using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.DTO
{
    public class ConsultaEmprestimoDvdDto
    {
        public int Id { get; set; }
        public int Genero { get; set; }

        public string Cliente { get; set; }
        public string CPF { get; set; }

        public string DataEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
        public string DataDevolucaoEfetiva { get; set; }

        public string StatusDvd{ get; set; }
        public string StatusEmprestimoAtual { get; set; }
        public string LoginBibliotecario { get; set; }
    }
}
