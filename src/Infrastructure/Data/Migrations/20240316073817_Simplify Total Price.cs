using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyTotalPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "MenuItemOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "MenuItemOrders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
