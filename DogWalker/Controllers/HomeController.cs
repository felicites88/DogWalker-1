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
            if (AmizadeDAO.Listar(Int32.Parse(Session["UsuarioId"].ToString())) != null)
            {
                ViewBag.Amizades = AmizadeDAO.Listar(Int32.Parse(Session["UsuarioId"].ToString()));
            }
            else
            {
                ViewBag.Amizades = null;
            }
            Usuario usuarioLogado = UsuarioDAO.Buscar(Int32.Parse(Session["UsuarioId"].ToString()));
            ViewBag.Cachorros = CachorroDAO.BuscarPorDono(Int32.Parse(Session["UsuarioId"].ToString()));
            return View(usuarioLogado);
        }

        public ActionResult PesquisarUsuarios()
        {
            return View(UsuarioDAO.Listar(Int32.Parse(Session["usuarioId"].ToString())));
        }
    }
}