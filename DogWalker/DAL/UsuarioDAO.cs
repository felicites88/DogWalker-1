using DogWalker.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DogWalker.DAL
{
    public class UsuarioDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static bool Salvar(Usuario usuario)
        {
            if (BuscarPorEmail(usuario.Email) == null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Usuario Buscar(int id)
        {
            return context.Usuarios.Find(id);
        }

        public static Usuario Autenticar(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Senha.Equals(usuario.Senha));
        }

        public static void Deletar(Usuario usuario)
        {
            context.Usuarios.Remove(usuario);
        }

        public static void Editar(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified;
            context.SaveChanges();
        }
        public static Usuario BuscarPorEmail(string email)
        {
            return context.Usuarios.FirstOrDefault(x => x.Email.Equals(email, System.StringComparison.CurrentCultureIgnoreCase));
        }

        public static List<Usuario> Listar(int id)
        {
            return context.Usuarios.Where(x => x.UsuarioId != id).ToList();
        }
    }
}