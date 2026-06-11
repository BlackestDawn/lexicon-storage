using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storage.API.Migrations
{
    /// <inheritdoc />
    public partial class ExtendingProducts_DiscountInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountFixed",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountFixed",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Product");
        }
    }
}
