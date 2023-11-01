using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixPeriodPrograssTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Designer",
                table: "PeriodProgress",
                newName: "Design");

            migrationBuilder.RenameColumn(
                name: "Designer",
                table: "OrderProjectStatus",
                newName: "Design");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "9fe8e2de-7509-4aae-b128-529fdee2b2ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "c449e1e4-d389-4aae-8056-f16888aaff69");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "8a7db557-492d-4726-8bc3-5fb502372747", new DateTime(2023, 11, 1, 9, 50, 53, 726, DateTimeKind.Local).AddTicks(7001), "AQAAAAIAAYagAAAAEJ4qLgIMpGx/U8O4Nk0Nikn6v64QpCqEe0CmD7UGfsAKki8MwMBHyGg5/TtbWZq/Cg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "6b21d180-d6e8-4f34-8184-b4e3b3a5738a", new DateTime(2023, 11, 1, 9, 50, 53, 913, DateTimeKind.Local).AddTicks(5334), "AQAAAAIAAYagAAAAEOJcLjDY1zjUOZwoS3GKdOZLaN9DwQO+272Y3nxrtrxAznunraJb1Gl3j07RoxyZVw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Design",
                table: "PeriodProgress",
                newName: "Designer");

            migrationBuilder.RenameColumn(
                name: "Design",
                table: "OrderProjectStatus",
                newName: "Designer");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "11a3bd4c-326d-43a1-a43b-34dee97be00d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "9f58da7c-560b-4806-8bdf-1d79bdcb6ccf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "dbed642b-7452-471a-93bb-c97cc855eb97", new DateTime(2023, 11, 1, 9, 48, 10, 668, DateTimeKind.Local).AddTicks(3179), "AQAAAAIAAYagAAAAEMzPD11db8CUd/LyvgywFlhKoBW9x3IwxR9nJA0yT9w5XoLYQOe92t+QPkXNzqITiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "c43bb7bb-a0af-4d28-a176-50bf9a0b9277", new DateTime(2023, 11, 1, 9, 48, 10, 763, DateTimeKind.Local).AddTicks(2107), "AQAAAAIAAYagAAAAEFmtBCD9LxTlDD8YU85oGAzL+uw3SXCwsXvIykDyNNI810W4/WUEFaM1mlGWRV1opQ==" });
        }
    }
}
