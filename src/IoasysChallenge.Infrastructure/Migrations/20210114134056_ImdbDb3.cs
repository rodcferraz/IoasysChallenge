using Microsoft.EntityFrameworkCore.Migrations;

namespace IoasysChallenge.Infrastructure.Migrations
{
    public partial class ImdbDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieScore",
                schema: "dbo",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MovieScore",
                schema: "dbo",
                table: "Movie",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
