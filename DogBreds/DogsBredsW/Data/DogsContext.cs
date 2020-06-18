using DogBredsModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsBredsW.Data
{
    public class DogsContext: DbContext
    {
        public DogsContext(DbContextOptions<DogsContext> options)
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RazaOrigen>()
                .HasKey(ro => new { ro.OriginId, ro.RazaId });
            modelBuilder.Entity<RazaHairType>()
                .HasKey(ro => new { ro.HairTypeId, ro.RazaId });
            modelBuilder.Entity<RazaCaracFisic>()
                .HasKey(ro => new { ro.CaracFisicId, ro.RazaId });
        }

        public DbSet<Raza> Razas { get; set; }
        public DbSet<CaracFisic> Caracteristicas { get; set; }
        public DbSet<Origin> Origenes { get; set; }
        public DbSet<HairType> HairTypes { get; set; }
        public DbSet<RazaOrigen> RazaOrigenes { get; set; }
        public DbSet<RazaHairType> RazaHairTypes { get; set; }
        public DbSet<RazaCaracFisic> RazaCaracFisics { get; set; }
    }
}
