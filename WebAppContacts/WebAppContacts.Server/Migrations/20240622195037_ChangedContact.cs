using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppContacts.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangedContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Subcategories_ContactSubcategoryId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactSubcategoryId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subcategory",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Subcategory",
                table: "Contacts");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactSubcategoryId",
                table: "Contacts",
                column: "ContactSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Subcategories_ContactSubcategoryId",
                table: "Contacts",
                column: "ContactSubcategoryId",
                principalTable: "Subcategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
