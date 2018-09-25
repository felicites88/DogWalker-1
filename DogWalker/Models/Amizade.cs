using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Amizade
    {
        public int AmizadeId { get; set; }
        public int Usuario1Id { get; set; }
        public int Usuario2Id { get; set; }
    }
}