using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parent_Category_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category_variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Variation_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_variation_Product_category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Product_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Product_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Product_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Product_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variation_value",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variation_Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variation_value", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variation_value_Category_variation_Variation_Id",
                        column: x => x.Variation_Id,
                        principalTable: "Category_variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_variation_value",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Variation_Value_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_variation_value", x => new { x.Product_Id, x.Variation_Value_Id });
                    table.ForeignKey(
                        name: "FK_Product_variation_value_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_variation_value_Variation_value_Variation_Value_Id",
                        column: x => x.Variation_Value_Id,
                        principalTable: "Variation_value",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_variation_Category_Id",
                table: "Category_variation",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_variation_value_Variation_Value_Id",
                table: "Product_variation_value",
                column: "Variation_Value_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Variation_value_Variation_Id",
                table: "Variation_value",
                column: "Variation_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_variation_value");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Variation_value");

            migrationBuilder.DropTable(
                name: "Category_variation");

            migrationBuilder.DropTable(
                name: "Product_category");
        }
    }
}
