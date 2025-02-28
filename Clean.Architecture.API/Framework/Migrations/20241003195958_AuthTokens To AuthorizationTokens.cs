using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Architecture.API.Migrations
{
    /// <inheritdoc />
    public partial class AuthTokensToAuthorizationTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthTokens",
                table: "AuthTokens");

            migrationBuilder.RenameTable(
                name: "AuthTokens",
                newName: "AuthorizationTokens");

            migrationBuilder.RenameIndex(
                name: "IX_AuthTokens_Token",
                table: "AuthorizationTokens",
                newName: "IX_AuthorizationTokens_Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorizationTokens",
                table: "AuthorizationTokens",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorizationTokens",
                table: "AuthorizationTokens");

            migrationBuilder.RenameTable(
                name: "AuthorizationTokens",
                newName: "AuthTokens");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorizationTokens_Token",
                table: "AuthTokens",
                newName: "IX_AuthTokens_Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthTokens",
                table: "AuthTokens",
                column: "Id");
        }
    }
}
