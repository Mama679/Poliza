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
    public class RadicadoConfiguration : IEntityTypeConfiguration<Radicado>
    {
        public void Configure(EntityTypeBuilder<Radicado> builder)
        {
            builder.HasKey(e => e.IdRadicado)
                   .HasName("PK__Radicado__729CB09FAACA705B");

            builder.Property(e => e.IdRadicado).HasColumnName("Id_Radicado");

            builder.Property(e => e.AutoId).HasColumnName("auto_id");

            builder.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("fecha_fin");

            builder.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fecha_inicio");

            builder.Property(e => e.FechaRad)
                .HasColumnType("date")
                .HasColumnName("fecha_rad");

            builder.Property(e => e.NumPoliza)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("num_poliza");

            builder.Property(e => e.PolizaId).HasColumnName("poliza_id");

            builder.HasOne(d => d.Auto)
                .WithMany(p => p.Radicados)
                .HasForeignKey(d => d.AutoId)
                .HasConstraintName("FK_Radicados_RAuto");

            builder.HasOne(d => d.Poliza)
                .WithMany(p => p.Radicados)
                .HasForeignKey(d => d.PolizaId)
                .HasConstraintName("FK_Radicados_RPoliza");
        }
    }
}
