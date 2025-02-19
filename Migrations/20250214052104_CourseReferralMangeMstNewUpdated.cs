using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class CourseReferralMangeMstNewUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseReferralMangeMst",
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
                    table.PrimaryKey("PK_CourseReferralMangeMst", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseReferralMangeMst_CourseReferralMst_refreallid",
                        column: x => x.refreallid,
                        principalTable: "CourseReferralMst",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseReferralMangeMst_refreallid",
                table: "CourseReferralMangeMst",
                column: "refreallid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseReferralMangeMst");
        }
    }
}
