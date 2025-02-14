using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class CourseRefreallManageMst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courseRefreallMangeMsts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usershareid = table.Column<int>(type: "int", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    refreallid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseRefreallMangeMsts", x => x.id);
                    table.ForeignKey(
                        name: "FK_courseRefreallMangeMsts_courseReffrealMsts_refreallid",
                        column: x => x.refreallid,
                        principalTable: "courseReffrealMsts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courseRefreallMangeMsts_refreallid",
                table: "courseRefreallMangeMsts",
                column: "refreallid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseRefreallMangeMsts");
        }
    }
}
