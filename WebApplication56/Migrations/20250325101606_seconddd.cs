using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication56.Migrations
{
    /// <inheritdoc />
    public partial class seconddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsSecond",
                schema: "dbo",
                table: "ProductsSecond");

            migrationBuilder.RenameTable(
                name: "ProductsSecond",
                schema: "dbo",
                newName: "productss",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productss",
                schema: "dbo",
                table: "productss",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_productss",
                schema: "dbo",
                table: "productss");

            migrationBuilder.RenameTable(
                name: "productss",
                schema: "dbo",
                newName: "ProductsSecond",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsSecond",
                schema: "dbo",
                table: "ProductsSecond",
                column: "Id");
        }
    }
}
