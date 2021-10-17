using InventarioAPI.Models;
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
    public class ReactivoController : ControllerBase
    {

        private readonly IRepository<Reactivo> _repositoryReactivo;
        private readonly IRepository<Usuario> _repositoryUser;

        public ReactivoController(IRepository<Usuario> repositoryUser, IRepository<Reactivo> repositoryReactivo)
        {
            _repositoryUser = repositoryUser;
            _repositoryReactivo = repositoryReactivo;
        }



        // GET: api/Reactivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reactivo>>> GetReactivos()
        {
            Reply reply = new Reply();
            reply.Result = -1;

            try
            {
                return new ActionResult<IEnumerable<Reactivo>>(await _repositoryReactivo.Get());
            }
            catch (Exception ex)
            {
                reply.Result = 700;
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }
        }

        // GET: api/Reactivo/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Reactivo>> GetReactivo(long id)
        {
            Reply reply = new Reply();
            reply.Result = -1;

            try
            {
                Reactivo reactivo = await _repositoryReactivo.Get(id);
                if (reactivo == null)
                {
                    reply.Message = "Reactivo no encontrado.";
                    return NotFound(reply);
                }

                return reactivo;
            }
            catch (Exception ex)
            {
                reply.Result = 700;
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }
        }

        // POST: api/Reactivo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reactivo>> AddReactivo(Reactivo reactivo)
        {
            Reply reply = new Reply();
            reply.Result = -1;
            try
            {
                await _repositoryReactivo.Add(reactivo);
                await _repositoryReactivo.Save();

                return CreatedAtAction("GetReactivo", new { id = reactivo.Id }, reactivo);
            }
            catch (Exception ex)
            {
                reply.Result = 700;
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }
        }

        // DELETE: api/Reactivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReactivo(long id)
        {
            Reply reply = new Reply();
            reply.Result = -1;
            try
            {
                Reactivo reactivo = await _repositoryReactivo.Get(id);
                if (reactivo == null)
                {
                    reply.Message = "Reactivo no encontrado.";
                    return NotFound(reply);
                }

                _repositoryReactivo.Delete(id);
                await _repositoryReactivo.Save();

                return NoContent();
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
