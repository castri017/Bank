using System;
using BlueBankApi.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlueBankApi.Infrastructure.Data
{
    public partial class BlueBankContext : DbContext
    {
        public BlueBankContext()
        {
        }

        public BlueBankContext(DbContextOptions<BlueBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CuentaAhorros> CuentaAhorros { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public virtual DbSet<TipoTransacion> TipoTransacion { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CuentaAhorrosConfiguration());
            modelBuilder.ApplyConfiguration(new PersonasConfiguration());
            modelBuilder.ApplyConfiguration(new TipoIdentificacionConfiguration());
            modelBuilder.ApplyConfiguration(new TipoTransacionConfiguration());
            modelBuilder.ApplyConfiguration(new TransaccionesConfiguration());
        }
    }
}
