using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PolizaSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Infrastructure.Data.Configurations
{
    public class PolizaConfiguration : IEntityTypeConfiguration<Poliza>
    {
        public void Configure(EntityTypeBuilder<Poliza> builder)
        {
            builder.HasKey(e => e.IdPoliza)
                    .HasName("PK__Polizas__B78BC452EDAB8D05");

            builder.Property(e => e.IdPoliza).HasColumnName("Id_poliza");

            builder.Property(e => e.Activa).HasColumnName("activa");

            builder.Property(e => e.Cobertura)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("cobertura");

            builder.Property(e => e.NombrePoliza)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_poliza");

            builder.Property(e => e.ValorMaximo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_maximo");
        }
    }
}
