using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeMaya.Migrations
{
    /// <inheritdoc />
    public partial class Add_client_phone_number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientPhone",
                table: "Orders");
        }
    }
}
