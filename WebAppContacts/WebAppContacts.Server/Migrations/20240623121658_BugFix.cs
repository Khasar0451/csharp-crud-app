using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppContacts.Server.Migrations
{
    /// <inheritdoc />
    public partial class BugFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subcategory",
                table: "Contacts",
                newName: "ContactSubcategory");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Contacts",
                newName: "ContactCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactSubcategory",
                table: "Contacts",
                newName: "Subcategory");

            migrationBuilder.RenameColumn(
                name: "ContactCategory",
                table: "Contacts",
                newName: "Category");
        }
    }
}
