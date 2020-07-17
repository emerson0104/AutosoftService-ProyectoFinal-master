using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutosoftService.Model;

namespace AutosoftService.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> articulos { get; set; }
        public DbSet<EntradasArticulos> entradaArt { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Facturas> facturas { get; set; }
        public DbSet<FacturaD> facturaD { get; set; }
        public DbSet<Pedidos> pedidos { get; set; }
        public DbSet<PedidoD> pedidoD { get; set; }
        public DbSet<Proveedores> proveedores { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Vehiculos> vehiculos { get; set; }
        public DbSet<Pagos> pagos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer(@"Server= .\SQLEXPRESS; Database = AutosoftServiceDB; trusted_connection = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
