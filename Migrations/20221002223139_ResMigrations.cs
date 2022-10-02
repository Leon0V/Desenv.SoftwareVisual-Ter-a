using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations
{
    public partial class ResMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    roomType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    roomType = table.Column<int>(type: "INTEGER", nullable: false),
                    roomid = table.Column<int>(type: "INTEGER", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    guestName = table.Column<string>(type: "TEXT", nullable: false),
                    guestNo = table.Column<int>(type: "INTEGER", nullable: false),
                    dateIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dateOut = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_roomid",
                        column: x => x.roomid,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_roomid",
                table: "Reservations",
                column: "roomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
