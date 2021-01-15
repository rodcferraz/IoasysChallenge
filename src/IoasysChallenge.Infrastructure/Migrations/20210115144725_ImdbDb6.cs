using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IoasysChallenge.Infrastructure.Migrations
{
    public partial class ImdbDb6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                schema: "dbo",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                schema: "dbo",
                table: "Movie");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "dbo",
                table: "Movie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "dbo",
                table: "Movie");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                schema: "dbo",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                schema: "dbo",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                schema: "dbo",
                table: "Movie",
                type: "datetime2",
                nullable: true);
        }
    }
}
