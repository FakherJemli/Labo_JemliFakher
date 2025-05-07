using Examen.ApplicationCore.Domain;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Examen.ApplicationCore.Data
{
    public class AMContext : DbContext
    {
        public DbSet<Laboratoire> Laboratoires { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Bilan> Bilans { get; set; }
        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<Infirmier> Infirmiers { get; set; }
        //chaine de connexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LaboJemliFakher;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //avec une classe de configuration 
            modelBuilder.ApplyConfiguration(new BilanConfiguration());
            // sans une classe de configuration 
            modelBuilder.Entity<Laboratoire>()
                .Property(l => l.Localisation)
                .HasColumnName("AdresseLabo")
                .HasMaxLength(50);
        }
    }
}