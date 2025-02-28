using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Architecture.API.Migrations
{
    /// <inheritdoc />
    public partial class AuthTokensToAuthKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizationTokens");

            migrationBuilder.CreateTable(
                name: "AuthenticationSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthenticationSessions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationSessions_ClientId",
                table: "AuthenticationSessions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationSessions_Key",
                table: "AuthenticationSessions",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthenticationSessions");

            migrationBuilder.CreateTable(
                name: "AuthorizationTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorizationTokens_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationTokens_ClientId",
                table: "AuthorizationTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationTokens_Token",
                table: "AuthorizationTokens",
                column: "Token",
                unique: true);
        }
    }
}
