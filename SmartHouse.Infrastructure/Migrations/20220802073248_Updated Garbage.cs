using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHouse.Infrastructure.Migrations
{
    public partial class UpdatedGarbage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Garbages",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Garbages");
        }
    }
}
