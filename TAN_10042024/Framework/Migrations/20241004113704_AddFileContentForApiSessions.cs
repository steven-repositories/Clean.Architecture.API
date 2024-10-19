using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAN_10042024.Migrations
{
    /// <inheritdoc />
    public partial class AddFileContentForApiSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileContent",
                table: "ApiSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "ApiSessions");
        }
    }
}
