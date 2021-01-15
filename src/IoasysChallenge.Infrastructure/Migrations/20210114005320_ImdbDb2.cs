using Microsoft.EntityFrameworkCore.Migrations;

namespace IoasysChallenge.Infrastructure.Migrations
{
    public partial class ImdbDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actors",
                schema: "dbo",
                table: "Movie",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                schema: "dbo",
                table: "Movie",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                schema: "dbo",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Genre",
                schema: "dbo",
                table: "Movie");
        }
    }
}
