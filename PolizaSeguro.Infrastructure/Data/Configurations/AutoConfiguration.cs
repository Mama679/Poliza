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
    public class AutoConfiguration : IEntityTypeConfiguration<Auto>
    {
        public void Configure(EntityTypeBuilder<Auto> builder)
        {
            builder.HasKey(e => e.IdAuto)
                    .HasName("PK__Autos__E699E34804A9FF0C");

            builder.Property(e => e.IdAuto).HasColumnName("Id_auto");

            builder.Property(e => e.CiudadPlaca)
                .HasMaxLength(50)
                .HasColumnName("ciudad_placa");

            builder.Property(e => e.ClienteId).HasColumnName("cliente_id");

            builder.Property(e => e.Inspeccion).HasColumnName("inspeccion");

            builder.Property(e => e.Modelo)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnName("modelo");

            builder.Property(e => e.Placa)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("placa");

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Autos)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_Autos_ToCliente");
        }
    }
}
