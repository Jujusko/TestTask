using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBLay.Migrations
{
    /// <inheritdoc />
    public partial class removedcostfromItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
