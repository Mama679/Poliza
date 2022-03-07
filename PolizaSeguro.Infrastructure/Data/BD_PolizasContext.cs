using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PolizaSeguro.Core.Entities;
using PolizaSeguro.Infrastructure.Data.Configurations;

#nullable disable

namespace PolizaSeguro.Infrastructure.Data
{
    public partial class BD_PolizasContext : DbContext
    {
        public BD_PolizasContext()
        {
        }

        public BD_PolizasContext(DbContextOptions<BD_PolizasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auto> Autos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Poliza> Polizas { get; set; }
        public virtual DbSet<Radicado> Radicados { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new AutoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new PolizaConfiguration());
            modelBuilder.ApplyConfiguration(new RadicadoConfiguration());

        }
    }
}
