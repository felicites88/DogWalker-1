using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Passeio
    {
        public int PasseioId { get; set; }
        public int PasseadorId { get; set; }
        public int ClienteId { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public bool Status { get; set; }
    }
}