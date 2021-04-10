using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Infrastructure.Data.Configurations
{
    public class PersonasConfiguration : IEntityTypeConfiguration<Personas>
    {
        public void Configure(EntityTypeBuilder<Personas> builder)
        {
            builder.HasKey(e => e.Identificacion);

            builder.Property(e => e.Identificacion).ValueGeneratedNever();
            builder.Property(e => e.Identificacion).HasMaxLength(10);

            builder.Property(e => e.Apellido).HasMaxLength(60);

            builder.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.FechaNacimeinto).HasColumnType("datetime");

            builder.Property(e => e.Movil).HasMaxLength(10);

            builder.Property(e => e.Nombre).HasMaxLength(60);
            
        }
    }
}
