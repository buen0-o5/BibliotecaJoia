using BibliotecaJoia.Models.DTO;
using BibliotecaJoia.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public class Dvd
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string genero { get; set; }
        public int statusDvdId { get; set; }
        public StatusDvd statusDvd { get; set; }

         public Dvd()
             :base()
         {

         }

        public void Cadastrar()
        {
            this.statusDvd = StatusDvd.DISPONIVEL;
            this.statusDvdId = statusDvd.GetHashCode();
        }
        public DvdDto ConverterParaDto()
        {
            return new DvdDto
            {
                Id = this.Id,
                nome = this.nome,
                genero = this.genero,
                statusDvdId = this.statusDvd.GetHashCode(),
                Status = this.statusDvd.ToString()
            };


         

        }

    }
}
