using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace funAPI.Migrations
{
    public partial class OverrideOnModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Names",
                columns: new[] { "Id", "DateBooked", "DateGenerated", "IsBooked", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 7, 27, 6, 52, 45, 717, DateTimeKind.Utc).AddTicks(7944), new DateTime(2021, 7, 20, 16, 23, 40, 0, DateTimeKind.Unspecified), false, "Tsitsi" },
                    { 2, new DateTime(2021, 7, 21, 9, 24, 40, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 20, 9, 24, 40, 0, DateTimeKind.Unspecified), true, "Anorld" },
                    { 3, new DateTime(2021, 7, 27, 6, 52, 45, 718, DateTimeKind.Utc).AddTicks(2883), new DateTime(2021, 7, 20, 9, 24, 40, 0, DateTimeKind.Unspecified), false, "Abjksabdflksdkfbiugbausdigbkjsdbgfui" },
                    { 4, new DateTime(2021, 7, 27, 6, 52, 45, 718, DateTimeKind.Utc).AddTicks(2890), new DateTime(2021, 7, 26, 9, 24, 40, 0, DateTimeKind.Unspecified), false, "Panashe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Names",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Names",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Names",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Names",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
