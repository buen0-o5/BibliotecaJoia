using BibliotecaJoia.Models.Entidades;
using BibliotecaJoia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.DTO
{
    public class DvdDto
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string genero { get; set; }
        public int statusDvdId { get; set; }
        public string Status { get; set; }
        
        public DvdDto() { }
        public Dvd ConverterParaEntidade() 
        {
            return new Dvd {
            Id = this.Id,
            nome = this.nome,
            genero = this.genero,
            //statusDvd =  GerenciadorDeStatus.PesquisarStatusDvdPorId(this.statusDvdId)
            };

        }
    }
}
