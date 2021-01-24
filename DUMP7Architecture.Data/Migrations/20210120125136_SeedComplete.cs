using Microsoft.EntityFrameworkCore.Migrations;

namespace DUMP7Architecture.Data.Migrations
{
    public partial class SeedComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductInvoiceCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubscriptionInvoiceCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubscriptionInvoiceCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubscriptionInvoiceCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubscriptionInvoiceCategories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
