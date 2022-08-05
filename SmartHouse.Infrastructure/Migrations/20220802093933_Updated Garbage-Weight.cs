using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHouse.Infrastructure.Migrations
{
    public partial class UpdatedGarbageWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Garbages",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Garbages",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
