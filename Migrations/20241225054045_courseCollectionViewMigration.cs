﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class courseCollectionViewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courseCategoriesMsts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseCategoriesStatus = table.Column<bool>(type: "bit", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseCategoriesMsts", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courseCategoriesMsts");
        }
    }
}
