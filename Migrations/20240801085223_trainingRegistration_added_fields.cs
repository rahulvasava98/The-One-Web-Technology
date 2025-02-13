using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class trainingRegistration_added_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "referenceCode",
                table: "trainingRegistrationmsts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "referenceId",
                table: "trainingRegistrationmsts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "trainingRegistrationPassword",
                table: "trainingRegistrationmsts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "referenceCode",
                table: "trainingRegistrationmsts");

            migrationBuilder.DropColumn(
                name: "referenceId",
                table: "trainingRegistrationmsts");

            migrationBuilder.DropColumn(
                name: "trainingRegistrationPassword",
                table: "trainingRegistrationmsts");
        }
    }
}
