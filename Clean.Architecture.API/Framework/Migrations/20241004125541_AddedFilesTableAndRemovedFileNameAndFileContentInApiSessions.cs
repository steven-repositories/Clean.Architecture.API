﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Architecture.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedFilesTableAndRemovedFileNameAndFileContentInApiSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "ApiSessions");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ApiSessions");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.AddColumn<string>(
                name: "FileContent",
                table: "ApiSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ApiSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
