using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Solicitacao
    {
        public int SolicitacaoId { get; set; }
        public int RemetenteId { get; set; }
        public int DestinatarioId { get; set; }
    }
}