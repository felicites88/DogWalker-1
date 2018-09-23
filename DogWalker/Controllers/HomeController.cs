using DogWalker.DAL;
using DogWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DogWalker.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Usuario usuario)
        {
            return View(UsuarioDAO.Buscar(usuario));
        }
    }
}