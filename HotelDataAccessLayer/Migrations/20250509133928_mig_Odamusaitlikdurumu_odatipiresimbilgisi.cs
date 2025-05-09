using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelDataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_Odamusaitlikdurumu_odatipiresimbilgisi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoomAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailableForSale = table.Column<bool>(type: "bit", nullable: false),
                    RemainingQuota = table.Column<int>(type: "int", nullable: false),
                    SoldQuota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAvailabilities_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAvailabilities_RoomTypeId",
                table: "RoomAvailabilities",
                column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAvailabilities");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "RoomTypes");
        }
    }
}
