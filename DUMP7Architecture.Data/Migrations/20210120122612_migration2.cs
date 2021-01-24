using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DUMP7Architecture.Data.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SubscriptionInvoices",
                columns: new[] { "Id", "CustomerId", "Description", "InvoiceId", "Name", "PricePerDay", "SubscriptionEndDate", "SubscriptionStartDate" },
                values: new object[] { 2, 2, "Cleaning lady", 13, "Home maintenance", 50m, new DateTime(2020, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SubscriptionInvoices",
                columns: new[] { "Id", "CustomerId", "Description", "InvoiceId", "Name", "PricePerDay", "SubscriptionEndDate", "SubscriptionStartDate" },
                values: new object[] { 3, 3, "Daily Brekfast, Lunch and Dinner", 14, "Personal Cheff +", 350m, new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubscriptionInvoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubscriptionInvoices",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
