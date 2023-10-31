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
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "78707a65-b39d-4577-ad9f-ef3b887bdfc3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "7f523e8f-e8fd-4753-9356-6ac3fe2296c2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "304f334a-90a4-4112-993f-e63c89ea4e4a", new DateTime(2023, 10, 31, 14, 8, 8, 617, DateTimeKind.Local).AddTicks(7792), "AQAAAAIAAYagAAAAEFkJLQA502YiSwwWonnAyekrGng0rmT5JjnABsNXm1EYhMBrEOJQJqVuTGiOAgNS7A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "4e4744a4-886e-4946-8cef-bf192ffe54e2", new DateTime(2023, 10, 31, 14, 8, 8, 783, DateTimeKind.Local).AddTicks(8129), "AQAAAAIAAYagAAAAEPbvLUV/KF9PrpHJBLCU+Z/Dr1C4f144ipGF5h/y/uKqOPrP1EzO9ILuVQ3ZN6sBOA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "37c3b1c5-1d87-4367-8ec1-d0ae7807bf34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "6821cad9-0e1b-49ae-9b09-e4eeb404fe8b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "b38a9507-461c-4085-b2ae-fddcb22454db", new DateTime(2023, 10, 29, 12, 57, 42, 501, DateTimeKind.Local).AddTicks(744), "AQAAAAIAAYagAAAAEJlGmq14fYptUwukwrS0K6wAxADRDqFoyTT5Mc0QNlW39H+gAohOtwW0OPukp7cscQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "0a79b700-2512-4db3-8c37-ff0f4be79d74", new DateTime(2023, 10, 29, 12, 57, 42, 722, DateTimeKind.Local).AddTicks(7714), "AQAAAAIAAYagAAAAEGjXblWfS5txNdhI/LDDJfymVhXu6JpL71wQX6h7rJb22vp2mv43mgt2pzWzeZTdPw==" });
        }
    }
}
