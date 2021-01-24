using Microsoft.EntityFrameworkCore.Migrations;

namespace DUMP7Architecture.Data.Migrations
{
    public partial class FixingSubscirpionInvoiceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SubscriptionInvoices_SubscriptionInvoiceId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubscriptionInvoiceId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubscriptionInvoiceId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionInvoiceId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubscriptionInvoiceId",
                table: "Categories",
                column: "SubscriptionInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SubscriptionInvoices_SubscriptionInvoiceId",
                table: "Categories",
                column: "SubscriptionInvoiceId",
                principalTable: "SubscriptionInvoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
