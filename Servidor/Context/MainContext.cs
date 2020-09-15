using ApiWebNetCore.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebNetCore.Context
{
    public class MainContext : DbContext
    {
        
            public MainContext(DbContextOptions<MainContext> options) : base(options)
            {
            }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MaquinaCliente>().HasKey(i => new { i.ClienteID, i.MaquinaID});
        }

        public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Maquina> Maquinas { get; set; }
            public DbSet<MaquinaCliente> MaquinasClientes { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }

    }
}
