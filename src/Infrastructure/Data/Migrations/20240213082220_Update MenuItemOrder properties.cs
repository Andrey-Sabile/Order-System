using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemOrderproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemOrders_Orders_OrdersId",
                table: "MenuItemOrders");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "MenuItemOrders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemOrders_OrdersId",
                table: "MenuItemOrders",
                newName: "IX_MenuItemOrders_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "MenuItemOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemOrders_Orders_OrderId",
                table: "MenuItemOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemOrders_Orders_OrderId",
                table: "MenuItemOrders");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "MenuItemOrders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "MenuItemOrders",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemOrders_OrderId",
                table: "MenuItemOrders",
                newName: "IX_MenuItemOrders_OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemOrders_Orders_OrdersId",
                table: "MenuItemOrders",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
