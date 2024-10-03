using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TAN_10042024.Migrations
{
    /// <inheritdoc />
    public partial class AuthorizationTokensEnhancement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationTokens_ClientId",
                table: "AuthorizationTokens",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorizationTokens_Clients_ClientId",
                table: "AuthorizationTokens",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizationTokens_Clients_ClientId",
                table: "AuthorizationTokens");

            migrationBuilder.DropIndex(
                name: "IX_AuthorizationTokens_ClientId",
                table: "AuthorizationTokens");
        }
    }
}
