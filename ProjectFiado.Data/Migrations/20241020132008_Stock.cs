using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectFiado.Migrations
{
    /// <inheritdoc />
    public partial class Stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_stocks_ProductId",
                table: "stocks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_stocks_products_ProductId",
                table: "stocks",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stocks_products_ProductId",
                table: "stocks");

            migrationBuilder.DropIndex(
                name: "IX_stocks_ProductId",
                table: "stocks");
        }
    }
}
