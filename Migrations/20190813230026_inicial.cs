using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace document.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", nullable: false),
                    process = table.Column<string>(type: "varchar(200)", nullable: false),
                    category = table.Column<string>(type: "varchar(200)", nullable: false),
                    archive = table.Column<byte[]>(type: "binary(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");
        }
    }
}
