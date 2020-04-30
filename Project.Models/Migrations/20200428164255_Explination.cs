using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Models.Migrations
{
    public partial class Explination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explination",
                table: "Answer");

            migrationBuilder.AddColumn<string>(
                name: "Explination",
                table: "QuestionAnswer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explination",
                table: "QuestionAnswer");

            migrationBuilder.AddColumn<string>(
                name: "Explination",
                table: "Answer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
