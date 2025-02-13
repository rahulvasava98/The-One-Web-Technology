using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class updatedContactus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "contactMsts",
                newName: "subject");

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "contactMsts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lname",
                table: "contactMsts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "message",
                table: "contactMsts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fname",
                table: "contactMsts");

            migrationBuilder.DropColumn(
                name: "Lname",
                table: "contactMsts");

            migrationBuilder.DropColumn(
                name: "message",
                table: "contactMsts");

            migrationBuilder.RenameColumn(
                name: "subject",
                table: "contactMsts",
                newName: "MyProperty");
        }
    }
}
