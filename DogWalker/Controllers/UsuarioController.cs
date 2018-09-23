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
            if(_usuario != null)
            {
                Session["usuarioId"] = usuario.UsuarioId;
                return RedirectToAction("Index", "Home", usuario);
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
    }
}