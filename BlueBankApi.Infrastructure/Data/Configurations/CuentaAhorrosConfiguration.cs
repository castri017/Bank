using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueBankApi.Infrastructure.Data.Configurations
{
    public class CuentaAhorrosConfiguration : IEntityTypeConfiguration<CuentaAhorros>
    {
        public void Configure(EntityTypeBuilder<CuentaAhorros> builder)
        { 
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
        }
    }
}
