using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DUMP7Architecture.Data.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oib = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkHoursStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkShiftTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductsInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumberOfProducts = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubscriptionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionInvoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_SubscriptionInvoices_SubscriptionInvoiceId",
                        column: x => x.SubscriptionInvoiceId,
                        principalTable: "SubscriptionInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInvoiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductInvoiceId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "SubscriptionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionCategories_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionInvoiceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionInvoiceId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                table: "Categories",
                columns: new[] { "Id", "Name", "SubscriptionInvoiceId" },
                values: new object[,]
                {
                    { 1, "Electronics", null },
                    { 2, "Car", null },
                    { 3, "Home", null },
                    { 4, "Garden", null },
                    { 5, "Entertainment", null },
                    { 6, "Kids", null },
                    { 7, "Furniture", null }
                });

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
                    { 2, "Ivo", "Ivic", "123456112", "14:00", new TimeSpan(0, 6, 0, 0, 0) },
                    { 3, "Petar", "Petricic", "123456113", "8:00", new TimeSpan(0, 8, 0, 0, 0) },
                    { 1, "Mate", "Matić", "123456111", "8:00", new TimeSpan(0, 8, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ProductType", "ProductsInStock" },
                values: new object[,]
                {
                    { 1, "2 amp charger", "Phone Charger", 90m, 0, 6 },
                    { 2, "Silocone case Iphone 10x", "Phone Case", 60m, 0, 9 },
                    { 3, "Vanilla car shampoo, 0.5l", "Car Shampoo", 110m, 0, 12 },
                    { 4, "Kids frisbee", "Frisbee", 30m, 0, 5 },
                    { 5, "10m", "Water Hose", 130m, 0, 6 },
                    { 6, "6L bucket Wooden", "Bucket", 160m, 0, 6 },
                    { 7, "30 min", "Massage", 65m, 1, 1 },
                    { 8, "Outside and inside", "Car Detailing", 90m, 1, 1 },
                    { 9, "Classic bowl", "Flower Bowl", 40m, 0, 6 },
                    { 10, "Professional installation on WiFi", "House Wifi Upgrade", 300m, 1, 1 }
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

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "DateOfPurchase", "EmployeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 14, new DateTime(2020, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, new DateTime(2020, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 8, 3, 6 },
                    { 12, 5, 10 },
                    { 11, 3, 9 },
                    { 10, 2, 8 },
                    { 9, 5, 7 },
                    { 7, 4, 5 },
                    { 1, 1, 1 },
                    { 5, 6, 4 },
                    { 4, 5, 4 },
                    { 3, 2, 3 },
                    { 2, 1, 2 },
                    { 6, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionCategories",
                columns: new[] { "Id", "CategoryId", "SubscriptionId" },
                values: new object[,]
                {
                    { 3, 3, 3 },
                    { 1, 1, 1 },
                    { 2, 3, 2 },
                    { 4, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "ProductInvoices",
                columns: new[] { "Id", "Description", "InvoiceId", "Name", "NumberOfProducts", "Price", "ProductType" },
                values: new object[,]
                {
                    { 1, "Kids frisbee", 1, "Frisbee", 2, 30m, 0 },
                    { 4, "Silocone case Iphone 10x", 4, "Phone Case", 1, 60m, 0 },
                    { 8, "Silocone case Iphone 10x", 7, "Phone Case", 1, 60m, 0 },
                    { 10, "Classic bowl", 9, "Flower Bowl", 1, 40m, 0 },
                    { 11, "Outside and inside", 10, "Car Detailing", 1, 90m, 1 },
                    { 2, "Classic bowl", 2, "Flower Bowl", 1, 40m, 0 },
                    { 5, "10m", 5, "Water Hose", 1, 130m, 0 },
                    { 6, "6L bucket Wooden", 5, "Bucket", 1, 160m, 0 },
                    { 9, "2 amp charger", 8, "Phone Charger", 1, 90m, 0 },
                    { 12, "Professional installation on WiFi", 11, "House Wifi Upgrade", 1, 300m, 1 },
                    { 3, "10m", 3, "Water Hose", 1, 130m, 0 },
                    { 7, "Vanilla car shampoo, 0.5l", 6, "Car Shampoo", 1, 110m, 0 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionInvoices",
                columns: new[] { "Id", "CustomerId", "Description", "InvoiceId", "Name", "PricePerDay", "SubscriptionEndDate", "SubscriptionStartDate" },
                values: new object[] { 1, 1, "Professional database maintenance", 12, "Database maintenance", 30m, new DateTime(2020, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubscriptionInvoiceId",
                table: "Categories",
                column: "SubscriptionInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeId",
                table: "Invoices",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoiceCategories_CategoryId",
                table: "ProductInvoiceCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoiceCategories_ProductInvoiceId",
                table: "ProductInvoiceCategories",
                column: "ProductInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInvoices_InvoiceId",
                table: "ProductInvoices",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionCategories_CategoryId",
                table: "SubscriptionCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionCategories_SubscriptionId",
                table: "SubscriptionCategories",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoiceCategories_CategoryId",
                table: "SubscriptionInvoiceCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoiceCategories_SubscriptionInvoiceId",
                table: "SubscriptionInvoiceCategories",
                column: "SubscriptionInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoices_CustomerId",
                table: "SubscriptionInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoices_InvoiceId",
                table: "SubscriptionInvoices",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductInvoiceCategories");

            migrationBuilder.DropTable(
                name: "SubscriptionCategories");

            migrationBuilder.DropTable(
                name: "SubscriptionInvoiceCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductInvoices");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SubscriptionInvoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Employes");
        }
    }
}
