using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMaya.Migrations
{
    /// <inheritdoc />
    public partial class Added_Couriers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDelivery_Orders_OrderId",
                table: "OrderDelivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDelivery",
                table: "OrderDelivery");

            migrationBuilder.RenameTable(
                name: "OrderDelivery",
                newName: "OrderDeliveries");

            migrationBuilder.AddColumn<int>(
                name: "CourierId",
                table: "OrderDeliveries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDeliveries",
                table: "OrderDeliveries",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDeliveries_CourierId",
                table: "OrderDeliveries",
                column: "CourierId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDeliveries_Couriers_CourierId",
                table: "OrderDeliveries",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDeliveries_Orders_OrderId",
                table: "OrderDeliveries",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDeliveries_Couriers_CourierId",
                table: "OrderDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDeliveries_Orders_OrderId",
                table: "OrderDeliveries");

            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDeliveries",
                table: "OrderDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_OrderDeliveries_CourierId",
                table: "OrderDeliveries");

            migrationBuilder.DropColumn(
                name: "CourierId",
                table: "OrderDeliveries");

            migrationBuilder.RenameTable(
                name: "OrderDeliveries",
                newName: "OrderDelivery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDelivery",
                table: "OrderDelivery",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDelivery_Orders_OrderId",
                table: "OrderDelivery",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
