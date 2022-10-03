using Microsoft.EntityFrameworkCore.Migrations;

namespace Booking.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_roomid",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "roomType",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "roomid",
                table: "Reservations",
                newName: "roomId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_roomid",
                table: "Reservations",
                newName: "IX_Reservations_roomId");

            migrationBuilder.AddColumn<string>(
                name: "roomName",
                table: "Rooms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "roomId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "guestName",
                table: "Reservations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Reservations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 11);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_roomId",
                table: "Reservations",
                column: "roomId",
                principalTable: "Rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_roomId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "roomName",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "roomId",
                table: "Reservations",
                newName: "roomid");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_roomId",
                table: "Reservations",
                newName: "IX_Reservations_roomid");

            migrationBuilder.AlterColumn<int>(
                name: "roomid",
                table: "Reservations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "guestName",
                table: "Reservations",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Reservations",
                type: "TEXT",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "roomType",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_roomid",
                table: "Reservations",
                column: "roomid",
                principalTable: "Rooms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
