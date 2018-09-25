using DogWalker.DAL;
using DogWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DogWalker.Controllers
{
    public class UsuarioApiController : ApiController
    {
        //GET: api/Usuario/Usuarios
        [Route("Produtos")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioDAO.ListarTodos();
        }
    }
}
