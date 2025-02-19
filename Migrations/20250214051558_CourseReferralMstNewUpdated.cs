using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class CourseReferralMstNewUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "categoriesName",
                table: "categoriesMsts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CourseReferralMst",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creffrealpoint = table.Column<int>(type: "int", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false),
                    startingdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endingdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseReferralMst", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseReferralMst_courseDetailsMsts_courseid",
                        column: x => x.courseid,
                        principalTable: "courseDetailsMsts",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseReferralMst_courseid",
                table: "CourseReferralMst",
                column: "courseid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseReferralMst");

            migrationBuilder.AlterColumn<string>(
                name: "categoriesName",
                table: "categoriesMsts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
