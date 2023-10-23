using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBlogRatingProjectTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_CustomerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Project_ProjectId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "ProjectTechnology");

            migrationBuilder.DropIndex(
                name: "IX_Project_CustomerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Rating",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_ProjectId",
                table: "Rating",
                newName: "IX_Rating_BlogId");

            migrationBuilder.CreateTable(
                name: "ProjectORBlogTechnology",
                columns: table => new
                {
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectORBlogTechnology", x => new { x.ProjectId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_ProjectORBlogTechnology_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectORBlogTechnology_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectORBlogTechnology_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectORBlogTechnology_BlogId",
                table: "ProjectORBlogTechnology",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectORBlogTechnology_TechnologyId",
                table: "ProjectORBlogTechnology",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Blog_BlogId",
                table: "Rating",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Blog_BlogId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "ProjectORBlogTechnology");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Rating",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_BlogId",
                table: "Rating",
                newName: "IX_Rating_ProjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectTechnology",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnology", x => new { x.ProjectId, x.TechnologyId });
                    table.ForeignKey(
                        name: "FK_ProjectTechnology_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechnology_Technology_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("25d5bfcb-e10c-49a4-b936-6dd443f23e30"),
                column: "ConcurrencyStamp",
                value: "6bf60bee-33fd-47af-9157-59f1408efa71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8379b56f-7881-48ae-bf99-a29f53059332"),
                column: "ConcurrencyStamp",
                value: "691cae7c-3da2-4e87-a639-1c344462bc85");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d7f4741-2cb1-4baf-a1f9-65dd95208333"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "1458709c-5912-4147-a9b0-cae6a48be31f", new DateTime(2023, 10, 9, 13, 34, 13, 873, DateTimeKind.Local).AddTicks(6364), "AQAAAAIAAYagAAAAEGHFajodt3Zna0uKHAzC2lKc+jGcdPp0J/uUfowzRRe250as+VdxE1FAHvgyJaf0/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("24143b4c-87a7-401d-830d-26f8eeaaa43a"),
                columns: new[] { "ConcurrencyStamp", "CreatedDateTime", "PasswordHash" },
                values: new object[] { "c71430b9-f520-4d73-b933-1f976c79cc2b", new DateTime(2023, 10, 9, 13, 34, 13, 998, DateTimeKind.Local).AddTicks(7780), "AQAAAAIAAYagAAAAEIjolE9tVHIEbvugp5s5gqQqHWBVVQDGTxRBb8+3Y2uXFyCQDcKJBBpEJ6RocVaMJQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CustomerId",
                table: "Project",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnology_TechnologyId",
                table: "ProjectTechnology",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AspNetUsers_CustomerId",
                table: "Project",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Project_ProjectId",
                table: "Rating",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
