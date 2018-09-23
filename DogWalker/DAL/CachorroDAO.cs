using DogWalker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogWalker.DAL
{
    public class CachorroDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static void Salvar(Cachorro cachorro)
        {
                context.Cachorros.Add(cachorro);
                context.SaveChanges();
        }

        public static Cachorro Buscar(Cachorro cachorro)
        {
            return context.Cachorros.Find(cachorro);
        }

        public static void Deletar(Cachorro cachorro)
        {
            context.Cachorros.Remove(cachorro);
        }

        public static void Editar(Cachorro cachorro)
        {
            context.Entry(cachorro).State = EntityState.Modified;
            context.SaveChanges();
        }

        public static List<Cachorro> BuscarPorDono(int usuarioId)
        {
            return context.Cachorros.Where(x => x.UsuarioId.Equals(usuarioId)).ToList();
        }
    }
}