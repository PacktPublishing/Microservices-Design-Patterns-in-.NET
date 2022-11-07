using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Patients.Api.Migrations
{
    public partial class removednamecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Documents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
