using DogWalker.Models;
using System.Data.Entity;
using System.Linq;

namespace DogWalker.DAL
{
    public class UsuarioDAO
    {
        private static Context context = SingletonContext.GetInstance();
        
        public static bool Salvar(Usuario usuario)
        {
            if (Buscar(usuario) == null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Usuario Buscar(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email));
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
    }
}