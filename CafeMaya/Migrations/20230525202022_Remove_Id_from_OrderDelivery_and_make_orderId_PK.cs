using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMaya.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Id_from_OrderDelivery_and_make_orderId_PK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDelivery",
                table: "OrderDelivery");

            migrationBuilder.DropIndex(
                name: "IX_OrderDelivery_OrderId",
                table: "OrderDelivery");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDelivery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDelivery",
                table: "OrderDelivery",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDelivery",
                table: "OrderDelivery");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderDelivery",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDelivery",
                table: "OrderDelivery",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDelivery_OrderId",
                table: "OrderDelivery",
                column: "OrderId",
                unique: true);
        }
    }
}
