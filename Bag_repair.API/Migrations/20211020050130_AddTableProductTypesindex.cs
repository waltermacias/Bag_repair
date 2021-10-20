using Microsoft.EntityFrameworkCore.Migrations;

namespace Bag_repair.API.Migrations
{
    public partial class AddTableProductTypesindex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "DocumentTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductType_Description",
                table: "ProductTypes",
                newName: "IX_ProductTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentType_Description",
                table: "DocumentTypes",
                newName: "IX_DocumentTypes_Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameTable(
                name: "DocumentTypes",
                newName: "DocumentType");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_Description",
                table: "ProductType",
                newName: "IX_ProductType_Description");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentTypes_Description",
                table: "DocumentType",
                newName: "IX_DocumentType_Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "Id");
        }
    }
}
