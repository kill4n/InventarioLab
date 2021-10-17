using InventarioAPI.Models;
using InventarioAPI.Models.Context;
using InventarioAPI.Models.WS;
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
        private readonly InventarioContext _context;

        public InventarioController(InventarioContext context)
        {
            _context = context;
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
                IQueryable<Usuario> lst = _context.Usuarios.Where(u => u.Email == user.Email && u.Password == user.Password && u.IdEstatus == 1);
                if (lst.Any())
                {
                    reply.Result = 0;
                    reply.Data = Guid.NewGuid().ToString();
                    Usuario usr = lst.FirstOrDefault();
                    usr.Token = (string)reply.Data;
                    _context.Entry(usr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
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
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }

        }
    }
}
