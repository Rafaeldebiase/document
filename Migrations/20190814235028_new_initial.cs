using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace document.Migrations
{
    public partial class new_initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", nullable: false),
                    process = table.Column<string>(type: "varchar(200)", nullable: false),
                    category = table.Column<string>(type: "varchar(200)", nullable: false),
                    archive = table.Column<byte[]>(type: "binary(16)", nullable: false),
                    delete = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");
        }
    }
}
