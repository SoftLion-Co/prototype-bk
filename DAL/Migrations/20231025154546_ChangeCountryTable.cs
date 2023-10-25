using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCountryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Country",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "f107f2b3-6e95-4f0e-90f5-a3b72fbdc709");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "952ce3a0-9e5f-4d73-a056-fc6e5414050d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "9e936a3f-f6d5-4898-9ef5-a69ddce5f3ba", new DateTime(2023, 10, 25, 18, 45, 45, 108, DateTimeKind.Local).AddTicks(5420), "AQAAAAIAAYagAAAAEERnDUYJ3izLONh81pR7dNTSPzDrnczdmCiYKWou6DYrBwMHeHwAx1ucZrm+lL0TUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "65735b6b-837d-423d-a9e9-469775124f83", new DateTime(2023, 10, 25, 18, 45, 45, 491, DateTimeKind.Local).AddTicks(7718), "AQAAAAIAAYagAAAAEFSmwijP8zAOaVjG2BD+S8hnA4Wv78UXNB7niBz6jkoRwgdXE4fP/+UgWdrMVjJSYw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Country");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "08664798-92c0-4cb5-861d-598ab3e289a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "0c6e8100-5ab0-434a-9db8-f82122085bd0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "c2b8d552-1555-42b5-933f-204d250b0b7a", new DateTime(2023, 10, 21, 15, 59, 41, 826, DateTimeKind.Local).AddTicks(6496), "AQAAAAIAAYagAAAAEDRROCiD1Bp6gH57eGdbeDh/Uj73OjAoTOdiAk3VZ2jDpJAqKxTYwDtae4Iakb//nQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "9b4879fe-35be-44ec-a782-4d3a79390511", new DateTime(2023, 10, 21, 15, 59, 41, 917, DateTimeKind.Local).AddTicks(1435), "AQAAAAIAAYagAAAAEFcs8HyIqR6XmoqoZxHNvu43DCCCceJ/jQWiCjKsg0bSsN3xm2xOTllXAXYRc4PpSA==" });
        }
    }
}
