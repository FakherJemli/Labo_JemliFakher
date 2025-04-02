using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NouvelleInitialisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdresseLabo",
                table: "Laboratoires",
                newName: "Localisation");

            migrationBuilder.AlterColumn<string>(
                name: "Localisation",
                table: "Laboratoires",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localisation",
                table: "Laboratoires",
                newName: "AdresseLabo");

            migrationBuilder.AlterColumn<string>(
                name: "AdresseLabo",
                table: "Laboratoires",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
