using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class courseRequestHandleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courseRequestHandleMsts",
                columns: table => new
                {
                    cRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentRequestedId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseDetailsId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseRequestedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseRequestHandleMsts", x => x.cRequestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseRequestHandleMsts");
        }
    }
}
