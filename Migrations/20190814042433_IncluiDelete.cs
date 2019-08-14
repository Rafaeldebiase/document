using Microsoft.EntityFrameworkCore.Migrations;

namespace document.Migrations
{
    public partial class IncluiDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "delete",
                table: "Document",
                type: "bool",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delete",
                table: "Document");
        }
    }
}
