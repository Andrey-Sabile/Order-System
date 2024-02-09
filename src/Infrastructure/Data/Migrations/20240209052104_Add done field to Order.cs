using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdddonefieldtoOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "MenuItems");

            migrationBuilder.RenameColumn(
                name: "tableNumber",
                table: "Orders",
                newName: "TableNumber");

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Orders",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TableNumber",
                table: "Orders",
                newName: "tableNumber");

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "MenuItems",
                type: "INTEGER",
                nullable: true);
        }
    }
}
