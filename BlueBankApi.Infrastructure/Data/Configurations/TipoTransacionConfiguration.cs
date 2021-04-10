using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Infrastructure.Data.Configurations
{
    public class TipoTransacionConfiguration : IEntityTypeConfiguration<TipoTransacion>
    {
        public void Configure(EntityTypeBuilder<TipoTransacion> builder)
        {
            builder.Property(e => e.Descripcion).HasMaxLength(50);
        }
    }
}
