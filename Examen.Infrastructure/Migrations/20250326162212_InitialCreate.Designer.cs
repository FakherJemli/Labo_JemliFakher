﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamenContext))]
    [Migration("20250326162212_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Analyse", b =>
                {
                    b.Property<int>("AnalyseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnalyseId"));

                    b.Property<int>("DureeResultat")
                        .HasColumnType("int");

                    b.Property<int>("LaboratoireId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValeurAnalyse")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValeurMaxNormale")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValeurMinNormale")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AnalyseId");

                    b.HasIndex("LaboratoireId");

                    b.ToTable("Analyses");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Bilan", b =>
                {
                    b.Property<string>("CodeInfirmier")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CodePatient")
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("DatePrelevement")
                        .HasColumnType("datetime2");

                    b.Property<int>("AnalyseId")
                        .HasColumnType("int");

                    b.HasKey("CodeInfirmier", "CodePatient", "DatePrelevement");

                    b.HasIndex("AnalyseId");

                    b.HasIndex("CodePatient");

                    b.ToTable("Bilans");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Infirmier", b =>
                {
                    b.Property<string>("CodeInfirmier")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodeInfirmier");

                    b.ToTable("Infirmiers");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Laboratoire", b =>
                {
                    b.Property<int>("LaboratoireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaboratoireId"));

                    b.Property<string>("Localisation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("AdresseLabo");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LaboratoireId");

                    b.ToTable("Laboratoires");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Patient", b =>
                {
                    b.Property<string>("CodePatient")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Informations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodePatient");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Analyse", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Laboratoire", "Laboratoire")
                        .WithMany("Analyses")
                        .HasForeignKey("LaboratoireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laboratoire");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Bilan", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Analyse", "Analyse")
                        .WithMany("Bilans")
                        .HasForeignKey("AnalyseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Infirmier", "Infirmier")
                        .WithMany("Bilans")
                        .HasForeignKey("CodeInfirmier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Patient", "Patient")
                        .WithMany("Bilans")
                        .HasForeignKey("CodePatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analyse");

                    b.Navigation("Infirmier");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Analyse", b =>
                {
                    b.Navigation("Bilans");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Infirmier", b =>
                {
                    b.Navigation("Bilans");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Laboratoire", b =>
                {
                    b.Navigation("Analyses");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Patient", b =>
                {
                    b.Navigation("Bilans");
                });
#pragma warning restore 612, 618
        }
    }
}
