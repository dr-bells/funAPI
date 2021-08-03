using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace funAPI.Migrations
{
    public partial class AddedValidationAndMoreColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookedName",
                table: "Names",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Names",
                newName: "DateGenerated");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Names",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBooked",
                table: "Names",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Names",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBooked",
                table: "Names");

            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Names");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Names",
                newName: "BookedName");

            migrationBuilder.RenameColumn(
                name: "DateGenerated",
                table: "Names",
                newName: "DateModified");

            migrationBuilder.AlterColumn<string>(
                name: "BookedName",
                table: "Names",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
