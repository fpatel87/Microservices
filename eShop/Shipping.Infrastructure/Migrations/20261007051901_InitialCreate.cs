using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Contact_Person = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipper_Region",
                columns: table => new
                {
                    Region_Id = table.Column<int>(type: "int", nullable: false),
                    Shipper_Id = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper_Region", x => new { x.Region_Id, x.Shipper_Id });
                    table.ForeignKey(
                        name: "FK_Shipper_Region_Region_Region_Id",
                        column: x => x.Region_Id,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shipper_Region_Shipper_Shipper_Id",
                        column: x => x.Shipper_Id,
                        principalTable: "Shipper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Shipper_Id = table.Column<int>(type: "int", nullable: false),
                    Shipping_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tracking_Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipping_Details_Shipper_Shipper_Id",
                        column: x => x.Shipper_Id,
                        principalTable: "Shipper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipper_Region_Shipper_Id",
                table: "Shipper_Region",
                column: "Shipper_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipping_Details_Shipper_Id",
                table: "Shipping_Details",
                column: "Shipper_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipper_Region");

            migrationBuilder.DropTable(
                name: "Shipping_Details");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Shipper");
        }
    }
}
