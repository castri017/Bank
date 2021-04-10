using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Infrastructure.Data.Configurations
{
    public class TipoIdentificacionConfiguration : IEntityTypeConfiguration<TipoIdentificacion>
    {
        public void Configure(EntityTypeBuilder<TipoIdentificacion> builder)
        {
            builder.Property(e => e.Descripcion).HasMaxLength(50);
        }
    }
}
