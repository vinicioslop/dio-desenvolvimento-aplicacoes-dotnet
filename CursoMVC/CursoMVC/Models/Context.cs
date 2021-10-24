﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString:@"Server=localhost\SQLEXPRESS;Database=Cursomvc;Trusted_Connection=True;");
        }

        public void SetModified(Object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
