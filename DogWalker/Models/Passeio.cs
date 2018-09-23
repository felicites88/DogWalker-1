using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Passeio
    {
        public int PasseioId { get; set; }
        public Usuario Passeador { get; set; }
        public Cachorro Cachorro { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }

    }
}