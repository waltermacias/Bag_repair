using Microsoft.EntityFrameworkCore.Migrations;

namespace Bag_repair.API.Migrations
{
    public partial class AddTableCataloguesIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogue",
                table: "Catalogue");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "Catalogue",
                newName: "Catalogues");

            migrationBuilder.RenameIndex(
                name: "IX_ProductType_Description",
                table: "ProductTypes",
                newName: "IX_ProductTypes_Description");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogue_Description",
                table: "Catalogues",
                newName: "IX_Catalogues_Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogues",
                table: "Catalogues",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogues",
                table: "Catalogues");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameTable(
                name: "Catalogues",
                newName: "Catalogue");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_Description",
                table: "ProductType",
                newName: "IX_ProductType_Description");

            migrationBuilder.RenameIndex(
                name: "IX_Catalogues_Description",
                table: "Catalogue",
                newName: "IX_Catalogue_Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogue",
                table: "Catalogue",
                column: "Id");
        }
    }
}
