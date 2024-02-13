using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenuItemOrderproperties2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemOrders_MenuItems_ItemsId",
                table: "MenuItemOrders");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "MenuItemOrders");

            migrationBuilder.RenameColumn(
                name: "ItemsId",
                table: "MenuItemOrders",
                newName: "MenuItemId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemOrders_ItemsId",
                table: "MenuItemOrders",
                newName: "IX_MenuItemOrders_MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemOrders_MenuItems_MenuItemId",
                table: "MenuItemOrders",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItemOrders_MenuItems_MenuItemId",
                table: "MenuItemOrders");

            migrationBuilder.RenameColumn(
                name: "MenuItemId",
                table: "MenuItemOrders",
                newName: "ItemsId");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItemOrders_MenuItemId",
                table: "MenuItemOrders",
                newName: "IX_MenuItemOrders_ItemsId");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "MenuItemOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItemOrders_MenuItems_ItemsId",
                table: "MenuItemOrders",
                column: "ItemsId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
