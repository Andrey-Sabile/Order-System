using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetCompositekeyforjointable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemOrders",
                table: "MenuItemOrders");

            migrationBuilder.DropIndex(
                name: "IX_MenuItemOrders_OrderId",
                table: "MenuItemOrders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MenuItemOrders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemOrders",
                table: "MenuItemOrders",
                columns: new[] { "OrderId", "MenuItemId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItemOrders",
                table: "MenuItemOrders");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MenuItemOrders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItemOrders",
                table: "MenuItemOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemOrders_OrderId",
                table: "MenuItemOrders",
                column: "OrderId");
        }
    }
}
