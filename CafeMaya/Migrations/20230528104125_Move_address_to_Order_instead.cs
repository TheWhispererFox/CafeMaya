using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMaya.Migrations
{
    /// <inheritdoc />
    public partial class Move_address_to_Order_instead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDeliveries",
                table: "OrderDeliveries");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "OrderDeliveries");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDeliveries",
                table: "OrderDeliveries",
                columns: new[] { "OrderId", "CourierId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDeliveries_OrderId",
                table: "OrderDeliveries",
                column: "OrderId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDeliveries",
                table: "OrderDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_OrderDeliveries_OrderId",
                table: "OrderDeliveries");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "OrderDeliveries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDeliveries",
                table: "OrderDeliveries",
                column: "OrderId");
        }
    }
}
