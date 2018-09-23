using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Solicitacao
    {
        public int SolicitacaoId { get; set; }
        public Usuario Remetente { get; set; }
        public Usuario Destinatario { get; set; }
        public string Mensagem { get; set; }
    }
}