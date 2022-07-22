using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartHouse.Infrastructure.Migrations
{
    public partial class added_water_bill_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterBills",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Arrears = table.Column<decimal>(nullable: false),
                    BillDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterBills_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterBills_UserId",
                table: "WaterBills",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterBills");
        }
    }
}
