﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Usuario> Ususarios { get; set; }
    }
}
