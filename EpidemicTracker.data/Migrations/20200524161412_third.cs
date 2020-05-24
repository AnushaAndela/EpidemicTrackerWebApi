using Microsoft.EntityFrameworkCore.Migrations;

namespace EpidemicTracker.data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsAffected",
                table: "Patient",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAffected",
                table: "Patient");
        }
    }
}
