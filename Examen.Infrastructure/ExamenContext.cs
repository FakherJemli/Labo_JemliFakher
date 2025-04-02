using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Examen.Infrastructure
{
    public class ExamenContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Infirmier> Infirmiers { get; set; }
        public DbSet<Laboratoire> Laboratoires { get; set; }
        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<Bilan> Bilans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                                          Database=LaboJemliFakher;
                                          Trusted_Connection=true;
                                          MultipleActiveResultSets=true");
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration de la clé primaire pour Infirmier
            modelBuilder.Entity<Infirmier>()
                .HasKey(i => i.CodeInfirmier);

            //// Configuration sans classe de configuration
            //modelBuilder.Entity<Laboratoire>()
            //    .Property(l => l.Localisation)
            //    .HasColumnName("AdresseLabo")
            //    .HasMaxLength(50);

            // Configuration avec classe de configuration
            modelBuilder.ApplyConfiguration(new BilanConfiguration());
        }
    }
}
