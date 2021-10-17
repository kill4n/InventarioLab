using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Models.Context
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Proveedor> Proveedors { get; set; }
        public DbSet<Reactivo> Reactivos { get; set; }
    }
}
