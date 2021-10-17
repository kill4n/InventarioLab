using InventarioAPI.Models;
using InventarioAPI.Models.Context;
using InventarioAPI.Models.WS;
using InventarioAPI.Reposotory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _repositoryUser;

        public InventarioController(InventarioContext context, IRepository<Usuario> repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        /// <summary>
        /// Login inventory app
        /// </summary>
        /// <param name="user">Must provide email and password to connect</param>
        /// <returns>Result of operation.</returns>
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            Reply reply = new Reply();
            reply.Result = -1;
            try
            {
                IEnumerable<Usuario> lst = _repositoryUser.Get().Where(u => u.Email == user.Email && u.Password == user.Password && u.IdEstatus == 1);
                if (lst.Any())
                {
                    reply.Result = 0;
                    reply.Data = Guid.NewGuid().ToString();
                    Usuario usr = lst.FirstOrDefault();
                    usr.Token = (string)reply.Data;
                    _repositoryUser.Update(usr);
                    _repositoryUser.Save();
                    reply.Message = "Inicio de sesión exitoso";
                    return Ok(reply);
                }
                else
                {
                    reply.Message = "Datos incorrectos";
                    return Unauthorized(reply);
                }
            }
            catch (Exception ex)
            {
                reply.Result = 700;
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }
        }

    }
}
