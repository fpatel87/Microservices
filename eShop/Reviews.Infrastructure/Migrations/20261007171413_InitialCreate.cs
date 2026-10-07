using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Order_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Product_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product_Name = table.Column<string>(type: "nvarchar(253)", maxLength: 253, nullable: false),
                    Rating_Value = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Review_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Pending")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Review", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Review");
        }
    }
}
