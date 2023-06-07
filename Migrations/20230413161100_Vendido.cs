using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcConcesionaria.Migrations
{
    /// <inheritdoc />
    public partial class Vendido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Vendido",
                table: "Vehiculo",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "Vehiculo");
        }
    }
}
