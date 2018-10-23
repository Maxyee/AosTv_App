using Microsoft.EntityFrameworkCore.Migrations;

namespace AosTv.Migrations
{
    public partial class Added_LinkName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkName",
                table: "Links",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkName",
                table: "Links");
        }
    }
}
