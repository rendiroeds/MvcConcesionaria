using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcConcesionaria.Migrations
{
    /// <inheritdoc />
    public partial class IdVehiculoComprado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdVehiculoComprado",
                table: "Cliente",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdVehiculoComprado",
                table: "Cliente");
        }
    }
}
