using DogWalker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogWalker.DAL
{
    public class PasseioDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static void Salvar(Passeio passeio)
        {
                context.Passeios.Add(passeio);
                context.SaveChanges();
        }

        public static void Editar(Passeio passeio)
        {
            context.Entry(passeio).State = EntityState.Modified;
            context.SaveChanges();
        }

        public static List<Passeio> Listar(int id)
        {
            return context.Passeios.Where(x => x.PasseadorId == id || x.ClienteId == id).ToList();
        }

        public static void Deletar(Passeio passeio)
        {
            context.Passeios.Remove(passeio);
            context.SaveChanges();
        }
    }
}