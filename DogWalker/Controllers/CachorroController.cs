using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DogWalker.DAL;
using DogWalker.Models;
using System.IO;

namespace DogWalker.Controllers
{
    public class CachorroController : Controller
    {
        // GET: Cachorro
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cachorro cachorro, HttpPostedFileBase ImagemUri)
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

        public ActionResult Editar(int id)
        {
            return View(CachorroDAO.Buscar(id));
        }

        [HttpPost]
        public ActionResult Editar(Cachorro cachorroAlterado, HttpPostedFileBase ImagemUri)
        {
            Cachorro cachorroOriginal = CachorroDAO.Buscar(cachorroAlterado.CachorroId);
            if (ImagemUri != null)
            {
                string nomeImagem = Path.GetFileName(ImagemUri.FileName);
                string caminho = Path.Combine(Server.MapPath("~/Images/"), nomeImagem);
                ImagemUri.SaveAs(caminho);
                cachorroOriginal.ImagemUri = nomeImagem;
            }
            cachorroOriginal.Nome = cachorroAlterado.Nome;
            cachorroOriginal.Nascimento = cachorroAlterado.Nascimento;
            cachorroOriginal.Porte = cachorroAlterado.Porte;
            cachorroOriginal.Raca = cachorroAlterado.Raca;
            if (ModelState.IsValid)
            {
                CachorroDAO.Editar(cachorroOriginal);
            }
            else
            {
                return View(cachorroOriginal);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Remover(int id)
        {
            CachorroDAO.Deletar(CachorroDAO.Buscar(id));
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SolicitarPasseio(int id)
        {
            ViewBag.Cachorros = CachorroDAO.BuscarPorDono(id);
            return View(UsuarioDAO.Buscar(id));
        }

        public ActionResult ConfirmarPasseio(Usuario usuario, DateTime data)
        {
            Passeio passeio = new Passeio();
            passeio.Data = data;
            passeio.ClienteId = usuario.UsuarioId;
            passeio.PasseadorId = Int32.Parse(Session["UsuarioId"].ToString());
            passeio.Preco = usuario.PrecoPasseio;
            passeio.Status = false;
            PasseioDAO.Salvar(passeio);
            return RedirectToAction("Index", "Home");
        }
    }
}