using DogWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.DAL
{
    public class AmizadeDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static void Salvar(Amizade amizade)
        {
            context.Amizades.Add(amizade);
            context.SaveChanges();
        }

        public static List<Amizade> Listar(int id)
        {
            return context.Amizades.Where(x => x.Usuario1Id.Equals(id) || x.Usuario2Id.Equals(id)).ToList();
        }

        public static void Excluir(Amizade amizade)
        {
            context.Amizades.Remove(amizade);
            context.SaveChanges();
        }

        public static Amizade Buscar(int id, int id2)
        {
            return context.Amizades.FirstOrDefault(x => (x.Usuario1Id.Equals(id) || x.Usuario2Id.Equals(id)) && (x.Usuario1Id.Equals(id2) || x.Usuario2Id.Equals(id2)));
        }
    }
}