using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIG.Migrations
{
    /// <inheritdoc />
    public partial class AuthorNamingFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedDateTime",
                table: "description",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "createdDateTime",
                table: "description",
                newName: "CreatedDateTime");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "description",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Employment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Avatar = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "description",
                newName: "updatedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreatedDateTime",
                table: "description",
                newName: "createdDateTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "description",
                newName: "id");
        }
    }
}
