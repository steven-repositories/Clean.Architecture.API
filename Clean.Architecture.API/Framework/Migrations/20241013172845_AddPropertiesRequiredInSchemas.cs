using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAN_10042024.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesRequiredInSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Files",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "FileContent",
                table: "Files",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Files",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Files",
                newName: "FileContent");
        }
    }
}
