using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiOrderingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerService_Travel_TravelId",
                table: "CustomerService");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerService_User_CustomerId",
                table: "CustomerService");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerService_Travel_TravelId",
                table: "CustomerService",
                column: "TravelId",
                principalTable: "Travel",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerService_User_CustomerId",
                table: "CustomerService",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerService_Travel_TravelId",
                table: "CustomerService");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerService_User_CustomerId",
                table: "CustomerService");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerService_Travel_TravelId",
                table: "CustomerService",
                column: "TravelId",
                principalTable: "Travel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerService_User_CustomerId",
                table: "CustomerService",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
