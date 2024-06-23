using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppContacts.Server.Migrations
{
    /// <inheritdoc />
    public partial class SurnameTypoFixAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surame",
                table: "Contacts",
                newName: "Surname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Contacts",
                newName: "Surame");
        }
    }
}
