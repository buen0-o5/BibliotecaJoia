using BibliotecaJoia.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.DTO
{
    public class EmprestimoDvdDto
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }

        public string DvdId { get; set; }
        public DvdDto Dvd { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioDto Usuario { get; set; }


        public string StatusEmprestimoAtual { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataDevolucaoEfetiva { get; set; }

        public EmprestimoDvd ConverterParaEntidade()
        {
            return new EmprestimoDvd
            { 
              ClienteId = this.ClienteId,
              Cliente = this.Cliente.ConverterParaEntidade(),
              DvdId = this.DvdId,
              Dvd = this.Dvd.ConverterParaEntidade(),
              UsuarioId = this.UsuarioId,
              Usuario = this.Usuario.ConverteParaEntidade(),
              StatusEmprestimoAtual = this.StatusEmprestimoAtual,
              DataEmprestimo = this.DataEmprestimo,
              DataDevolucao = this.DataDevolucao,
              DataDevolucaoEfetiva = this.DataDevolucaoEfetiva
            };
        }
    }
}
