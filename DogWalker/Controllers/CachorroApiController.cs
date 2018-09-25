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
    public class CachorroApiController : ApiController
    {
        //GET: api/Cachorro/Cachorros
        [Route("Cachorros/{ usuarioId }")]
        public List<Cachorro> GetUsuarios(int usuarioId)
        {
            return CachorroDAO.BuscarPorDono(usuarioId);
        }
    }
}
