using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prueba.Migrations
{
    public partial class AddDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<long>(type: "bigint", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    published_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_products", x => x.product_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
