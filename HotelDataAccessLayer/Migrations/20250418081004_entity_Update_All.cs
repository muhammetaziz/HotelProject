using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelDataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class entity_Update_All : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CommentActivate",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CommentDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentActivate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentDate",
                table: "Comments");
        }
    }
}
