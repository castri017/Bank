using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Infrastructure.Data.Configurations
{
    public class TransaccionesConfiguration : IEntityTypeConfiguration<Transacciones>
    {
        public void Configure(EntityTypeBuilder<Transacciones> builder)
        {
            builder.Property(e => e.FechaTransaccion)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("(getdate())");
        }
    }
}
