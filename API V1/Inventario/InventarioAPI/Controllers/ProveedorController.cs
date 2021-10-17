using InventarioAPI.Models;
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


    }
}
