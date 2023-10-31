using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeParagraphAndPicturesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Picture",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Paragraph",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Paragraph");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "9464a322-faf7-43f3-8a81-0885991ac05c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "c94f4751-5252-4381-a848-225345bbaeb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "2aacc4f3-d5d9-4ae4-8fec-692e85488090", new DateTime(2023, 10, 29, 11, 20, 35, 283, DateTimeKind.Local).AddTicks(6143), "AQAAAAIAAYagAAAAELPSQdct3QSvHzrYEpKtN+CFK4toV0Z7KPFBNkeHs9jLzMTizaYMnPmx4fbCi9EQtQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "8fd6e6d1-cb0b-4bae-8a68-5f8ed925cfe9", new DateTime(2023, 10, 29, 11, 20, 35, 564, DateTimeKind.Local).AddTicks(8171), "AQAAAAIAAYagAAAAEGgZ+JBxuqXvr9U/5ULWUz0ULd6kT1C50/dDPsHJUyCJOE/i/HC/JBchOIhBHNZBaA==" });
        }
    }
}
