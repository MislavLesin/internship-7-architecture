using Microsoft.EntityFrameworkCore.Migrations;

namespace DUMP7Architecture.Data.Migrations
{
    public partial class RemovedCategoriesFromInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInvoiceCategories");

            migrationBuilder.DropTable(
                name: "SubscriptionInvoiceCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductInvoiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductInvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInvoiceCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInvoiceCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInvoiceCategories_ProductInvoices_ProductInvoiceId",
                        column: x => x.ProductInvoiceId,
                        principalTable: "ProductInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionInvoiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionInvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionInvoiceCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionInvoiceCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionInvoiceCategories_SubscriptionInvoices_SubscriptionInvoiceId",
                        column: x => x.SubscriptionInvoiceId,
                        principalTable: "SubscriptionInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductInvoiceCategories",
                columns: new[] { "Id", "CategoryId", "ProductInvoiceId" },
                values: new object[,]
                {
                    { 1, 6, 1 },
                    { 2, 4, 2 },
                    { 3, 4, 3 },
                    { 4, 1, 4 },
                    { 5, 4, 5 },
                    { 6, 4, 6 },
                    { 7, 2, 7 },
                    { 8, 1, 8 },
                    { 9, 1, 9 },
                    { 10, 3, 10 },
                    { 11, 2, 11 },
                    { 12, 3, 12 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionInvoiceCategories",
                columns: new[] { "Id", "CategoryId", "SubscriptionInvoiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoiceCategories_CategoryId",
                table: "ProductInvoiceCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoiceCategories_ProductInvoiceId",
                table: "ProductInvoiceCategories",
                column: "ProductInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoiceCategories_CategoryId",
                table: "SubscriptionInvoiceCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoiceCategories_SubscriptionInvoiceId",
                table: "SubscriptionInvoiceCategories",
                column: "SubscriptionInvoiceId");
        }
    }
}
