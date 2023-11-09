using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixOPSandPPandServiceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Design",
                table: "PeriodProgress");

            migrationBuilder.DropColumn(
                name: "Development",
                table: "PeriodProgress");

            migrationBuilder.DropColumn(
                name: "Design",
                table: "OrderProjectStatus");

            migrationBuilder.DropColumn(
                name: "Development",
                table: "OrderProjectStatus");

            migrationBuilder.DropColumn(
                name: "Security",
                table: "OrderProjectStatus");

            migrationBuilder.RenameColumn(
                name: "Security",
                table: "PeriodProgress",
                newName: "Progress");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "PeriodProgress",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "b57708fb-f0bd-4de6-a655-bd8541b28034");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "f3f6b5f1-c032-4ce8-acab-57e99865dde2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "b10b81ea-9f99-4f99-9c56-f6daaad98bcd", new DateTime(2023, 11, 4, 17, 0, 48, 762, DateTimeKind.Local).AddTicks(4847), "AQAAAAIAAYagAAAAEAEv8pSrsPHkMPl7vqZnv90MtRik/+iUzMB4O91hiJhrY9YEnIIL4f/HRnlak3Mwzw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "534fe513-f268-4a5a-8099-8b172e7ad227", new DateTime(2023, 11, 4, 17, 0, 48, 919, DateTimeKind.Local).AddTicks(3496), "AQAAAAIAAYagAAAAEG/UmZ4jHDaXGmhNRzMTGNpFbK+KrwbQNEglp59JyOlqIsd0Nf2J0ZNVyRgyfuOFzQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodProgress_ServiceId",
                table: "PeriodProgress",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodProgress_Service_ServiceId",
                table: "PeriodProgress",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodProgress_Service_ServiceId",
                table: "PeriodProgress");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropIndex(
                name: "IX_PeriodProgress_ServiceId",
                table: "PeriodProgress");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "PeriodProgress");

            migrationBuilder.RenameColumn(
                name: "Progress",
                table: "PeriodProgress",
                newName: "Security");

            migrationBuilder.AddColumn<int>(
                name: "Design",
                table: "PeriodProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Development",
                table: "PeriodProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Design",
                table: "OrderProjectStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Development",
                table: "OrderProjectStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Security",
                table: "OrderProjectStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
