using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication56.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ProductsSecond",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsSecond",
                schema: "dbo",
                table: "ProductsSecond",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsSecond",
                schema: "dbo",
                table: "ProductsSecond");

            migrationBuilder.RenameTable(
                name: "ProductsSecond",
                schema: "dbo",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
