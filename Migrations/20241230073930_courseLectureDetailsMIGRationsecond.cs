using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class courseLectureDetailsMIGRationsecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courseLectureDetailsMsts",
                columns: table => new
                {
                    courseLectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LectureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureUploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    courseModuleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseLectureDetailsMsts", x => x.courseLectureId);
                    table.ForeignKey(
                        name: "FK_courseLectureDetailsMsts_courseModuleDetailsMsts_courseModuleId",
                        column: x => x.courseModuleId,
                        principalTable: "courseModuleDetailsMsts",
                        principalColumn: "courseModuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courseLectureDetailsMsts_courseModuleId",
                table: "courseLectureDetailsMsts",
                column: "courseModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseLectureDetailsMsts");
        }
    }
}
