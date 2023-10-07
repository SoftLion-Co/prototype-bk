using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangesNamesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "edd75872-df73-4ac3-aa02-95350c05ac03");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "06014346-bdf7-4da0-af47-f0b0beafd4ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "878d96c2-cfad-4915-9598-701b94db7a3b", new DateTime(2023, 10, 5, 10, 33, 33, 40, DateTimeKind.Local).AddTicks(1885), "AQAAAAIAAYagAAAAEIkEZHjz+NAHw5ohLSqzUrgz5ARpLapLOXgz+3rIVBjR5u0fjJsAwe7PAs1g/+SVIQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "a4f507e9-302b-428e-ba1b-baa71c8aca9c", new DateTime(2023, 10, 5, 10, 33, 33, 122, DateTimeKind.Local).AddTicks(5538), "AQAAAAIAAYagAAAAEI8EgApRODa473pOWjjXG0svtwE/IOVL6ruLuqNK1CjuFPPilqW7et/Ue3bWCPb/RA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "153d7ebc-8b72-4043-9f9b-17aa01a9ccdc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "c3ad349d-2456-44f2-af1c-dc79c9ce2d2c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "57846f33-bef0-4061-88b6-8ae2b4e7fac9", new DateTime(2023, 10, 5, 7, 40, 48, 475, DateTimeKind.Local).AddTicks(5187), "AQAAAAIAAYagAAAAEEZY6WvCoYG8NRaCiOkezvkvvOpoxM8WKM44uIypjtCVExVnHGRX606Z85yF8/KUdQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "8cefbd9e-4710-4a2b-a118-39b94b42d6b6", new DateTime(2023, 10, 5, 7, 40, 48, 565, DateTimeKind.Local).AddTicks(1665), "AQAAAAIAAYagAAAAEBOEHwzEgWsKQq1BgDIQTcw6OpbXsEAdGEfN3hRwChUysq2Ys/wegXKNKPkplDuINA==" });
        }
    }
}
