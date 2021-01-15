using Microsoft.EntityFrameworkCore.Migrations;

namespace IoasysChallenge.Infrastructure.Migrations
{
    public partial class ImdbDb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Director",
                schema: "dbo",
                table: "Movie",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                schema: "dbo",
                table: "Movie");
        }
    }
}
