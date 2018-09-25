using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogWalker.Models
{
    public class Context : DbContext
    {
        public Context() : base("DogWalker") { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cachorro> Cachorros { get; set; }
        public DbSet<Passeio> Passeios { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Amizade> Amizades { get; set; }
    }
}