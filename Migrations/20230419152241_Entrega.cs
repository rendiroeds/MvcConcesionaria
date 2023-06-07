using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcConcesionaria.Migrations
{
    /// <inheritdoc />
    public partial class Entrega : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Entrega",
                table: "Cliente",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entrega",
                table: "Cliente");
        }
    }
}
