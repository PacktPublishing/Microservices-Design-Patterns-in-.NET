using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Documents.Api.Migrations
{
    public partial class AddednameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");
        }
    }
}
