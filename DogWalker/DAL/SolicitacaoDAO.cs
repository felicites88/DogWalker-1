using DogWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalker.DAL
{
    public class SolicitacaoDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static bool Salvar(Solicitacao solicitacao)
        {
            foreach (Solicitacao s in context.Solicitacoes)
            {
                if (s.RemetenteId == solicitacao.RemetenteId && s.DestinatarioId == solicitacao.DestinatarioId)
                {
                    return false;
                }
            }
            context.Solicitacoes.Add(solicitacao);
            context.SaveChanges();
            return true;
        }

        public static Solicitacao Buscar(int id)
        {
            return context.Solicitacoes.Find(id);
        }

        public static void Deletar(Solicitacao solicitacao)
        {
            context.Solicitacoes.Remove(solicitacao);
        }

        public static List<Solicitacao> Listar(int id)
        {
            return context.Solicitacoes.Where(x => x.DestinatarioId == id).ToList();
        }
    }
}