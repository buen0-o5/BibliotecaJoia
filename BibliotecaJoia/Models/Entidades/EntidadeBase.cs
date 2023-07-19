using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaJoia.Models.Entidades
{
    public abstract class EntidadeBase
    {
        public string Id { get; set; }

        public EntidadeBase()
        {
            //criando Id
            Id = Guid.NewGuid().ToString();
        }


    }
}
