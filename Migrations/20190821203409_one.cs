using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace document.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "LONGTEXT", nullable: false),
                    data = table.Column<byte[]>(type: "LONGBLOB", nullable: false),
                    content_type = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", nullable: false),
                    process = table.Column<string>(type: "varchar(200)", nullable: false),
                    category = table.Column<string>(type: "varchar(200)", nullable: false),
                    delete = table.Column<bool>(type: "bool", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.code);
                    table.ForeignKey(
                        name: "FK_Document_File_code",
                        column: x => x.code,
                        principalTable: "File",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "File");
        }
    }
}
