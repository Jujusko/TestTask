using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLay.Migrations
{
    /// <inheritdoc />
    public partial class addcosttotablerowinorders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RowInOrder_Items_itemId",
                table: "RowInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RowInOrder_Orders_OrderId",
                table: "RowInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RowInOrder",
                table: "RowInOrder");

            migrationBuilder.RenameTable(
                name: "RowInOrder",
                newName: "RowsInOrder");

            migrationBuilder.RenameIndex(
                name: "IX_RowInOrder_OrderId",
                table: "RowsInOrder",
                newName: "IX_RowsInOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_RowInOrder_itemId",
                table: "RowsInOrder",
                newName: "IX_RowsInOrder_itemId");

            migrationBuilder.AddColumn<int>(
                name: "OneItemCost",
                table: "RowsInOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RowsInOrder",
                table: "RowsInOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RowsInOrder_Items_itemId",
                table: "RowsInOrder",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RowsInOrder_Orders_OrderId",
                table: "RowsInOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RowsInOrder_Items_itemId",
                table: "RowsInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_RowsInOrder_Orders_OrderId",
                table: "RowsInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RowsInOrder",
                table: "RowsInOrder");

            migrationBuilder.DropColumn(
                name: "OneItemCost",
                table: "RowsInOrder");

            migrationBuilder.RenameTable(
                name: "RowsInOrder",
                newName: "RowInOrder");

            migrationBuilder.RenameIndex(
                name: "IX_RowsInOrder_OrderId",
                table: "RowInOrder",
                newName: "IX_RowInOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_RowsInOrder_itemId",
                table: "RowInOrder",
                newName: "IX_RowInOrder_itemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RowInOrder",
                table: "RowInOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RowInOrder_Items_itemId",
                table: "RowInOrder",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RowInOrder_Orders_OrderId",
                table: "RowInOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
