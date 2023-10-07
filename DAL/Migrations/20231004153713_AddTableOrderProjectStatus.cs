using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOrderProjectStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderProjectStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProjectStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProjectStatus_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeriodProgress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberWeek = table.Column<int>(type: "int", nullable: false),
                    Designer = table.Column<int>(type: "int", nullable: false),
                    Development = table.Column<int>(type: "int", nullable: false),
                    Epset = table.Column<int>(type: "int", nullable: false),
                    Security = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodProgress_OrderProjectStatus_ProjectStatusId",
                        column: x => x.ProjectStatusId,
                        principalTable: "OrderProjectStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "132c50c6-c743-4b9d-826e-6c96a8b1dbfe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "621b4f3e-4738-4bbb-b571-ac833531ff82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "600d9080-a01a-4b3b-bfd5-fc44a04ba2e2", new DateTime(2023, 10, 4, 18, 37, 12, 82, DateTimeKind.Local).AddTicks(6845), "AQAAAAIAAYagAAAAEMQe8E4YsLP/UFRT+RqCuJEnWd2s/JGiXzCMyp+EI2VTWUjAxL47vLns+MYP/lJ1Ig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "2332d6ea-de06-472e-b042-d6c6641e4849", new DateTime(2023, 10, 4, 18, 37, 12, 348, DateTimeKind.Local).AddTicks(2541), "AQAAAAIAAYagAAAAEFRK4MnYk2LtHPwLdq/Z9/o74iQQ0JcMDZb7k+qmleq9z9MuQfI5GF95jF3yEL2GKA==" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProjectStatus_CustomerId",
                table: "OrderProjectStatus",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodProgress_ProjectStatusId",
                table: "PeriodProgress",
                column: "ProjectStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodProgress");

            migrationBuilder.DropTable(
                name: "OrderProjectStatus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "0ddc911d-880a-4915-90f6-b8f556450c17");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "9de5c485-aec3-47ed-bb21-ef896cb07402");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "6795b238-bcf9-4043-837a-67976a447150", new DateTime(2023, 9, 22, 11, 59, 33, 155, DateTimeKind.Local).AddTicks(4160), "AQAAAAIAAYagAAAAEGbbtYeuk3jyMM5wh9YxAXGhgG8OSxindzDXPYVex8fGirwfrXv+k5JCEYJ4yv65zg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "622324fe-0193-440c-b56e-a4a70f3da7e2", new DateTime(2023, 9, 22, 11, 59, 33, 295, DateTimeKind.Local).AddTicks(3674), "AQAAAAIAAYagAAAAEBB1t7rScBp1pTH1kyt4vOVbZgh/7WIYk2V9Enf4JL1vtyPKm5kZphcPo4bcM0xNGA==" });
        }
    }
}
