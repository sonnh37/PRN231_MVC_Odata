using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiOrderingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_CustomerService_CustomerServiceId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_CustomerService_CustomerServiceId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Farm_FarmId",
                table: "TravelFarm");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Travel_TravelId",
                table: "TravelFarm");

            migrationBuilder.DropTable(
                name: "ServiceXCustomerService");

            migrationBuilder.DropTable(
                name: "CustomerService");

            migrationBuilder.DropIndex(
                name: "IX_Size_KoiFishId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrder_InvoiceId",
                table: "ServiceOrder");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerServiceId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_KoiOrder_InvoiceId",
                table: "KoiOrder");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_KoiOrderId",
                table: "Delivery");

            migrationBuilder.RenameColumn(
                name: "CustomerServiceId",
                table: "ServiceOrder",
                newName: "BookingRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_CustomerServiceId",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_BookingRequestId");

            migrationBuilder.RenameColumn(
                name: "CustomerServiceId",
                table: "Sales",
                newName: "BookingRequestId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SizeInGram",
                table: "Size",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SizeInCm",
                table: "Size",
                type: "decimal(10,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "KoiFish",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "KoiFish",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSold",
                table: "KoiFish",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "KoiFish",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookingRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TravelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuantityService = table.Column<int>(type: "int", nullable: true),
                    NumberOfPerson = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingRequest_Travel_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingRequest_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceXBookingRequest",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceXBookingRequest", x => new { x.ServiceId, x.BookingRequestId });
                    table.ForeignKey(
                        name: "FK_ServiceXBookingRequest_BookingRequest_BookingRequestId",
                        column: x => x.BookingRequestId,
                        principalTable: "BookingRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceXBookingRequest_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Size_KoiFishId",
                table: "Size",
                column: "KoiFishId",
                unique: true,
                filter: "([KoiFishId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_InvoiceId",
                table: "ServiceOrder",
                column: "InvoiceId",
                unique: true,
                filter: "([InvoiceId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BookingRequestId",
                table: "Sales",
                column: "BookingRequestId",
                unique: true,
                filter: "([BookingRequestId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_KoiOrder_InvoiceId",
                table: "KoiOrder",
                column: "InvoiceId",
                unique: true,
                filter: "([InvoiceId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_KoiOrderId",
                table: "Delivery",
                column: "KoiOrderId",
                unique: true,
                filter: "([KoiOrderId] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_CustomerId",
                table: "BookingRequest",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRequest_TravelId",
                table: "BookingRequest",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceXBookingRequest_BookingRequestId",
                table: "ServiceXBookingRequest",
                column: "BookingRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_BookingRequest_BookingRequestId",
                table: "Sales",
                column: "BookingRequestId",
                principalTable: "BookingRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_BookingRequest_BookingRequestId",
                table: "ServiceOrder",
                column: "BookingRequestId",
                principalTable: "BookingRequest",
                principalColumn: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_BookingRequest_BookingRequestId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_BookingRequest_BookingRequestId",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Farm_FarmId",
                table: "TravelFarm");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelFarm_Travel_TravelId",
                table: "TravelFarm");

            migrationBuilder.DropTable(
                name: "ServiceXBookingRequest");

            migrationBuilder.DropTable(
                name: "BookingRequest");

            migrationBuilder.DropIndex(
                name: "IX_Size_KoiFishId",
                table: "Size");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrder_InvoiceId",
                table: "ServiceOrder");

            migrationBuilder.DropIndex(
                name: "IX_Sales_BookingRequestId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_KoiOrder_InvoiceId",
                table: "KoiOrder");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_KoiOrderId",
                table: "Delivery");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "KoiFish");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "BookingRequestId",
                table: "ServiceOrder",
                newName: "CustomerServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_BookingRequestId",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_CustomerServiceId");

            migrationBuilder.RenameColumn(
                name: "BookingRequestId",
                table: "Sales",
                newName: "CustomerServiceId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SizeInGram",
                table: "Size",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SizeInCm",
                table: "Size",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "KoiFish",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "KoiFish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateSold",
                table: "KoiFish",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TravelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPerson = table.Column<int>(type: "int", nullable: true),
                    QuantityService = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerService_Travel_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CustomerService_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ServiceXCustomerService",
                columns: table => new
                {
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceXCustomerService", x => new { x.ServiceId, x.CustomerServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceXCustomerService_CustomerService_CustomerServiceId",
                        column: x => x.CustomerServiceId,
                        principalTable: "CustomerService",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceXCustomerService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Size_KoiFishId",
                table: "Size",
                column: "KoiFishId",
                unique: true,
                filter: "[KoiFishId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_InvoiceId",
                table: "ServiceOrder",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerServiceId",
                table: "Sales",
                column: "CustomerServiceId",
                unique: true,
                filter: "[CustomerServiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KoiOrder_InvoiceId",
                table: "KoiOrder",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_KoiOrderId",
                table: "Delivery",
                column: "KoiOrderId",
                unique: true,
                filter: "[KoiOrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_CustomerId",
                table: "CustomerService",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerService_TravelId",
                table: "CustomerService",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceXCustomerService_CustomerServiceId",
                table: "ServiceXCustomerService",
                column: "CustomerServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_CustomerService_CustomerServiceId",
                table: "Sales",
                column: "CustomerServiceId",
                principalTable: "CustomerService",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_CustomerService_CustomerServiceId",
                table: "ServiceOrder",
                column: "CustomerServiceId",
                principalTable: "CustomerService",
                principalColumn: "Id");

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
    }
}
