using DogWalker.DAL;
using DogWalker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalker.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            Usuario _usuario = UsuarioDAO.Autenticar(usuario);
            if (_usuario != null)
            {
                Session["usuarioId"] = _usuario.UsuarioId;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Usuario", usuario);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario, HttpPostedFileBase ImagemUri)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            if (ModelState.IsValid)
            {
                if (ImagemUri != null)
                {
                    string nomeImagem = Path.GetFileName(ImagemUri.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);
                    ImagemUri.SaveAs(caminho);
                    usuario.ImagemUri = nomeImagem;
                }
                else
                {
                    usuario.ImagemUri = "semimagem.png";
                }
                if (UsuarioDAO.Salvar(usuario))
                {
                    return RedirectToAction("Login", "Usuario");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário já cadastrado!");
                    return View(usuario);
                }
            }
            return View(usuario);
        }

        public ActionResult AdicionarAmigo(int id)
        {
            Usuario amigo = UsuarioDAO.Buscar(id);
            Solicitacao solicitacao = new Solicitacao();
            solicitacao.RemetenteId = Int32.Parse(Session["usuarioId"].ToString());
            solicitacao.DestinatarioId = id;
            if (SolicitacaoDAO.Salvar(solicitacao))
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Solicitação ja enviada");
            return RedirectToAction("PesquisarUsuarios", "Home");
        }

        public ActionResult Solicitacoes()
        {
            return View(SolicitacaoDAO.Listar(Int32.Parse(Session["usuarioId"].ToString())));
        }

        public ActionResult AceitarSolicitacao(int id)
        {
            Solicitacao solicitacao = SolicitacaoDAO.Buscar(id);
            Usuario amigo = UsuarioDAO.Buscar(solicitacao.RemetenteId);
            Usuario usuario = UsuarioDAO.Buscar(solicitacao.DestinatarioId);
            Amizade amizade = new Amizade();
            amizade.Usuario1Id = usuario.UsuarioId;
            amizade.Usuario2Id = amigo.UsuarioId;
            AmizadeDAO.Salvar(amizade);
            SolicitacaoDAO.Deletar(solicitacao);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["UsuarioId"] = null;
            return RedirectToAction("Login", "Usuario");
        }

        public ActionResult Passeios()
        {
            List<Passeio> passeios = PasseioDAO.Listar(Int32.Parse(Session["UsuarioId"].ToString()));
            return View(passeios);
        }

        public ActionResult ExcluirAmigo(int id)
        {
            AmizadeDAO.Excluir(AmizadeDAO.Buscar(id, Int32.Parse(Session["UsuarioId"].ToString())));
            return RedirectToAction("Index", "Home");
        }
    }
}