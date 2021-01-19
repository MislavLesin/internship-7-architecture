using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DUMP7Architecture.Data.Migrations
{
    public partial class FullDatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerHour",
                table: "Subscriptions",
                newName: "PricePerDay");

            migrationBuilder.RenameColumn(
                name: "PricePerHour",
                table: "SubscriptionInvoices",
                newName: "PricePerDay");

            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Employes",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "WorkHoursStart",
                table: "Employes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "LastName", "Oib" },
                values: new object[,]
                {
                    { 1, "Ante", "Antić", "123456111" },
                    { 2, "Mate", "Matic", "123456112" },
                    { 3, "Karlo", "Karlic", "123456113" },
                    { 4, "Roko", "Rokelic", "123456114" }
                });

            migrationBuilder.InsertData(
                table: "Employes",
                columns: new[] { "Id", "FirstName", "LastName", "Oib", "WorkHoursStart", "WorkShiftTime" },
                values: new object[,]
                {
                    { 1, "Mate", "Matić", "123456111", "8:00", new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, "Ivo", "Ivic", "123456112", "14:00", new TimeSpan(0, 6, 0, 0, 0) },
                    { 3, "Petar", "Petricic", "123456113", "8:00", new TimeSpan(0, 8, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Furniture" },
                    { 6, "Kids" },
                    { 5, "Entertainment" },
                    { 4, "Garden" },
                    { 3, "Home" },
                    { 2, "Car" },
                    { 1, "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ProductType", "ProductsInStock" },
                values: new object[,]
                {
                    { 10, "Professional installation on WiFi", "House Wifi Upgrade", 300m, 1, 1 },
                    { 7, "30 min", "Massage", 65m, 1, 1 },
                    { 8, "Outside and inside", "Car Detailing", 90m, 1, 1 },
                    { 6, "6L bucket Wooden", "Bucket", 160m, 0, 6 },
                    { 5, "10m", "Water Hose", 130m, 0, 6 },
                    { 4, "Kiss frisbee", "Frisbee", 30m, 0, 5 },
                    { 3, "Vanilla car shampoo, 0.5l", "Car Shampoo", 110m, 0, 12 },
                    { 2, "Silocone case Iphone 10x", "Phone Case", 60m, 0, 9 },
                    { 1, "2 amp charger", "Phone Charger", 90m, 0, 6 },
                    { 9, "Claccis bowl", "Flower Bowl", 40m, 0, 6 }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Description", "Name", "PricePerDay", "ServiceAvailable" },
                values: new object[,]
                {
                    { 3, "Daily Brekfast and Lunch", "Personal Cheff", 200m, true },
                    { 1, "Professional database maintenance", "Database maintenance", 30m, true },
                    { 2, "Cleaning lady", "Home maintenance", 50m, true },
                    { 4, "Daily Brekfast, Lunch and Dinner", "Personal Cheff +", 350m, true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "PricePerDay",
                table: "Subscriptions",
                newName: "PricePerHour");

            migrationBuilder.RenameColumn(
                name: "PricePerDay",
                table: "SubscriptionInvoices",
                newName: "PricePerHour");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Employes",
                newName: "FirsName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "FirsName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "WorkHoursStart",
                table: "Employes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
