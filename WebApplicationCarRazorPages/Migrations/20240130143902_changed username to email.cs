using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCarRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class changedusernametoemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Admins",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Customers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Admins",
                newName: "UserName");
        }
    }
}
