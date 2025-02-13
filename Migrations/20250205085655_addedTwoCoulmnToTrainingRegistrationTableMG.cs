using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class addedTwoCoulmnToTrainingRegistrationTableMG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fileUrl",
                table: "trainingRegistrationmsts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tOTP",
                table: "trainingRegistrationmsts",
                type: "int",
                nullable: true);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileUrl",
                table: "trainingRegistrationmsts");

            migrationBuilder.DropColumn(
                name: "tOTP",
                table: "trainingRegistrationmsts");

            
        }
    }
}
