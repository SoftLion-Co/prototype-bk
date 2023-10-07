using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SmallChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodProgress_OrderProjectStatus_ProjectStatusId",
                table: "PeriodProgress");

            migrationBuilder.DropColumn(
                name: "Epset",
                table: "PeriodProgress");

            migrationBuilder.RenameColumn(
                name: "ProjectStatusId",
                table: "PeriodProgress",
                newName: "OrderProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PeriodProgress_ProjectStatusId",
                table: "PeriodProgress",
                newName: "IX_PeriodProgress_OrderProjectStatusId");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "OrderProjectStatus",
                newName: "Title");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "e437f1c8-3e38-4941-82e5-c6b991c1cfc3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "0c202716-2503-41e9-a2ea-0f0c80f48d7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "21d3a789-2ba8-40e4-a75a-33e66de551bb", new DateTime(2023, 10, 7, 8, 1, 4, 84, DateTimeKind.Local).AddTicks(3223), "AQAAAAIAAYagAAAAEA6sriFFaq3fkY9El32m4ugXKh628txeKARkh+7ES+gQl7RhS6Yqg3Ikdo5l0h6DGw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "075f1230-bdd4-4e29-a5c3-048ed71e42d4", new DateTime(2023, 10, 7, 8, 1, 4, 298, DateTimeKind.Local).AddTicks(3695), "AQAAAAIAAYagAAAAED32euKLdMqy4eiKZKpij5w7ea8um+cK4Rnj5Slr5FD89E8lvvg5YEMWzB7kJgu5yw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodProgress_OrderProjectStatus_OrderProjectStatusId",
                table: "PeriodProgress",
                column: "OrderProjectStatusId",
                principalTable: "OrderProjectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeriodProgress_OrderProjectStatus_OrderProjectStatusId",
                table: "PeriodProgress");

            migrationBuilder.RenameColumn(
                name: "OrderProjectStatusId",
                table: "PeriodProgress",
                newName: "ProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PeriodProgress_OrderProjectStatusId",
                table: "PeriodProgress",
                newName: "IX_PeriodProgress_ProjectStatusId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "OrderProjectStatus",
                newName: "CustomerName");

            migrationBuilder.AddColumn<int>(
                name: "Epset",
                table: "PeriodProgress",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PeriodProgress_OrderProjectStatus_ProjectStatusId",
                table: "PeriodProgress",
                column: "ProjectStatusId",
                principalTable: "OrderProjectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
