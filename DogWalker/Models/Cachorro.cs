using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Cachorro
    {
        public int CachorroId { get; set; }
        public string Nome { get; set; }
        public string Raca { get; set; }
        public string Porte { get; set; }
        public DateTime Nascimento { get; set; }
        public string ImagemUri { get; set; }
    }
}