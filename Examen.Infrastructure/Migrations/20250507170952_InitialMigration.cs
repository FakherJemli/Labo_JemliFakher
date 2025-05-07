using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laboratoires",
                columns: table => new
                {
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseLabo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratoires", x => x.LaboratoireId);
                });

            migrationBuilder.CreateTable(
                name: "Infirmiers",
                columns: table => new
                {
                    InfirmierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomComplet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialite = table.Column<int>(type: "int", nullable: false),
                    LaboratoireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infirmiers", x => x.InfirmierId);
                    table.ForeignKey(
                        name: "FK_Infirmiers_Laboratoires_LaboratoireId",
                        column: x => x.LaboratoireId,
                        principalTable: "Laboratoires",
                        principalColumn: "LaboratoireId");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    CodePatient = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Informations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InfirmierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.CodePatient);
                    table.ForeignKey(
                        name: "FK_Patients_Infirmiers_InfirmierId",
                        column: x => x.InfirmierId,
                        principalTable: "Infirmiers",
                        principalColumn: "InfirmierId");
                });

            migrationBuilder.CreateTable(
                name: "Bilans",
                columns: table => new
                {
                    DatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InfirmierId = table.Column<int>(type: "int", nullable: false),
                    CodePatient = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    EmailMedecin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paye = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilans", x => new { x.InfirmierId, x.CodePatient, x.DatePrelevement });
                    table.ForeignKey(
                        name: "FK_Bilans_Infirmiers_InfirmierId",
                        column: x => x.InfirmierId,
                        principalTable: "Infirmiers",
                        principalColumn: "InfirmierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilans_Patients_CodePatient",
                        column: x => x.CodePatient,
                        principalTable: "Patients",
                        principalColumn: "CodePatient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    AnalyseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuréeResultat = table.Column<int>(type: "int", nullable: false),
                    PrixAnalyse = table.Column<double>(type: "float", nullable: false),
                    TypeAnalyse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValeurAnalyse = table.Column<float>(type: "real", nullable: false),
                    ValeurMaxNormale = table.Column<float>(type: "real", nullable: false),
                    ValeurMinNormale = table.Column<float>(type: "real", nullable: false),
                    BilanInfirmierId = table.Column<int>(type: "int", nullable: false),
                    BilanCodePatient = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    BilanDatePrelevement = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.AnalyseId);
                    table.ForeignKey(
                        name: "FK_Analyses_Bilans_BilanInfirmierId_BilanCodePatient_BilanDatePrelevement",
                        columns: x => new { x.BilanInfirmierId, x.BilanCodePatient, x.BilanDatePrelevement },
                        principalTable: "Bilans",
                        principalColumns: new[] { "InfirmierId", "CodePatient", "DatePrelevement" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_BilanInfirmierId_BilanCodePatient_BilanDatePrelevement",
                table: "Analyses",
                columns: new[] { "BilanInfirmierId", "BilanCodePatient", "BilanDatePrelevement" });

            migrationBuilder.CreateIndex(
                name: "IX_Bilans_CodePatient",
                table: "Bilans",
                column: "CodePatient");

            migrationBuilder.CreateIndex(
                name: "IX_Infirmiers_LaboratoireId",
                table: "Infirmiers",
                column: "LaboratoireId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InfirmierId",
                table: "Patients",
                column: "InfirmierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "Bilans");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Infirmiers");

            migrationBuilder.DropTable(
                name: "Laboratoires");
        }
    }
}
