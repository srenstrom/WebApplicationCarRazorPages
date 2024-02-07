using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCarRazorPages.Migrations
{
    /// <inheritdoc />
    public partial class addedpictureproptocarclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureLink",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureLink",
                table: "Car");
        }
    }
}
