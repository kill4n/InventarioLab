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
    public class ProveedorController : ControllerBase
    {
        private readonly IRepository<Proveedor> _repositoryProveedor;
        private readonly IRepository<Usuario> _repositoryUser;

        public ProveedorController(IRepository<Usuario> repositoryUser, IRepository<Proveedor> repositoryProveedor)
        {
            _repositoryUser = repositoryUser;
            _repositoryProveedor = repositoryProveedor;
        }

        // GET: api/Proveedores
        [HttpGet]
        [ActionName("GetAll")]

        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
            Reply reply = new Reply();
            reply.Result = -1;

            try
            {
                return new ActionResult<IEnumerable<Proveedor>>(await _repositoryProveedor.Get());
            }
            catch (Exception ex)
            {
                reply.Result = 700;
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }
        }

        // GET: api/Proveedor/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(long id)
        {
            Reply reply = new Reply();
            reply.Result = -1;

            try
            {
                Proveedor proveedor = await _repositoryProveedor.Get(id);
                if (proveedor == null)
                {
                    reply.Message = "Proveedor no encontrado.";
                    return NotFound(reply);
                }

                return proveedor;
            }
            catch (Exception ex)
            {
                reply.Result = 700;
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }
        }

        // POST: api/Proveedor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedor>> AddProveedor(Proveedor proveedor)
        {
            Reply reply = new Reply();
            reply.Result = -1;
            try
            {
                await _repositoryProveedor.Add(proveedor);
                await _repositoryProveedor.Save();

                return CreatedAtAction("GetProveedor", new { id = proveedor.Id }, proveedor);
            }
            catch (Exception ex)
            {
                reply.Result = 700;
                reply.Message = "Unexpected error";
                return BadRequest(reply);
            }
        }

        // DELETE: api/Proveedor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(long id)
        {
            Reply reply = new Reply();
            reply.Result = -1;
            try
            {
                Proveedor proveedor = await _repositoryProveedor.Get(id);
                if (proveedor == null)
                {
                    reply.Message = "Proveedor no encontrado.";
                    return NotFound(reply);
                }

                _repositoryProveedor.Delete(id);
                await _repositoryProveedor.Save();

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
