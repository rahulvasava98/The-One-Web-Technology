using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class updatedLikeMst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "courseliked",
                table: "courseLikeMsts");

            migrationBuilder.AddColumn<DateTime>(
                name: "courseLikeTime",
                table: "courseLikeMsts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "courseLikeTime",
                table: "courseLikeMsts");

            migrationBuilder.AddColumn<bool>(
                name: "courseliked",
                table: "courseLikeMsts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
