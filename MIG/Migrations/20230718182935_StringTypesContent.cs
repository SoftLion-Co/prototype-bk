using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MIG.Migrations
{
    /// <inheritdoc />
    public partial class StringTypesContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SVG_BlogId",
                table: "SVG");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SVG_BlogId",
                table: "SVG",
                column: "BlogId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SVG_BlogId",
                table: "SVG");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Avatar",
                table: "Author",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SVG_BlogId",
                table: "SVG",
                column: "BlogId");
        }
    }
}
