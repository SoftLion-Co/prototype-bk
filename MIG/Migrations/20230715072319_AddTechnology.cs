using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIG.Migrations
{
    /// <inheritdoc />
    public partial class AddTechnology : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TechnologyId",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Technology",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technology", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Technology_CountryId",
                table: "Project",
                column: "CountryId",
                principalTable: "Technology",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Technology_CountryId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Technology");

            migrationBuilder.DropColumn(
                name: "TechnologyId",
                table: "Project");
        }
    }
}
