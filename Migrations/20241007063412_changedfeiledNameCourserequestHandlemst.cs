using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class changedfeiledNameCourserequestHandlemst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "courseActiveStatus",
                table: "courseRequestHandleMsts",
                newName: "courseAccesstatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "courseAccesstatus",
                table: "courseRequestHandleMsts",
                newName: "courseActiveStatus");
        }
    }
}
