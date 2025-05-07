using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Examen.ApplicationCore.Domain;
namespace Examen.Infrastructure.Configurations
{
    public class BilanConfiguration : IEntityTypeConfiguration<Bilan>
    {
        public void Configure(EntityTypeBuilder<Bilan> builder)
        {
            // Clé primaire composée (InfirmierId, CodePatient, DatePrelevement)
            builder.HasKey(b => new
            {
                b.InfirmierId,
                b.CodePatient,
                b.DatePrelevement
            });
            // Relation avec Infirmier
            builder.HasOne(b => b.Infirmier)
                .WithMany(i => i.Bilans)
                .HasForeignKey(b => b.InfirmierId);
            // Relation avec Patient
            builder.HasOne(b => b.Patient)
                .WithMany(p => p.Bilans)
                .HasForeignKey(b => b.CodePatient);
        }
    }
}
public class BilanConfiguration : IEntityTypeConfiguration<Bilan>
{
    public void Configure(EntityTypeBuilder<Bilan> builder)
    {
        // Clé primaire composée (InfirmierId, CodePatient, DatePrelevement)
        builder.HasKey(b => new {
            b.InfirmierId,
            b.CodePatient,
            b.DatePrelevement
        });

        // Relation avec Infirmier
        builder.HasOne(b => b.Infirmier)
            .WithMany(i => i.Bilans)
            .HasForeignKey(b => b.InfirmierId);

        // Relation avec Patient
        builder.HasOne(b => b.Patient)
            .WithMany(p => p.Bilans)
            .HasForeignKey(b => b.CodePatient);
    }
}