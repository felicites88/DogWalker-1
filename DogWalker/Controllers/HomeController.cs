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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Cachorros = CachorroDAO.BuscarPorDono(Int32.Parse(Session["UsuarioId"].ToString()));
            return View(UsuarioDAO.Buscar(Int32.Parse(Session["UsuarioId"].ToString())));
        }

        public ActionResult CadastrarCachorro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCachorro(Cachorro cachorro, HttpPostedFileBase ImagemUri)
        {
            if (ModelState.IsValid)
            {
                if (ImagemUri != null)
                {
                    string nomeImagem = Path.GetFileName(ImagemUri.FileName);
                    string caminho = Path.Combine(Server.MapPath("~/Imagens/"), nomeImagem);
                    ImagemUri.SaveAs(caminho);
                    cachorro.ImagemUri = nomeImagem;
                }
                else
                {
                    cachorro.ImagemUri = "CachorroSemImagem.png";
                }
                cachorro.UsuarioId = Int32.Parse(Session["UsuarioId"].ToString());
                CachorroDAO.Salvar(cachorro);
                return RedirectToAction("Index", "Home");
            }
            return View(cachorro);
        }
    }
}