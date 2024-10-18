using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiOrderingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Farm_FarmId",
                table: "TravelFarm");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Travel_TravelId",
                table: "TravelFarm");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelFarm_Farm_FarmId",
                table: "TravelFarm",
                column: "FarmId",
                principalTable: "Farm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelFarm_Travel_TravelId",
                table: "TravelFarm",
                column: "TravelId",
                principalTable: "Travel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Farm_FarmId",
                table: "TravelFarm");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Travel_TravelId",
                table: "TravelFarm");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelFarm_Farm_FarmId",
                table: "TravelFarm",
                column: "FarmId",
                principalTable: "Farm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelFarm_Travel_TravelId",
                table: "TravelFarm",
                column: "TravelId",
                principalTable: "Travel",
                principalColumn: "Id");
        }
    }
}
