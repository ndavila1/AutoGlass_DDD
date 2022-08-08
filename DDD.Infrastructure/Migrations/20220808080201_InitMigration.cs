using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    manufacturing_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    validity_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    provider_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion_provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number_provider = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
