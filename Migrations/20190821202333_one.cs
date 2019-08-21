using System;
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
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "LONGTEXT", nullable: false),
                    Data = table.Column<byte[]>(nullable: true),
                    content_type = table.Column<string>(type: "varchar(300)", nullable: true),
                    DocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.code);
                    table.UniqueConstraint("AK_File_DocumentId", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "varchar(200)", nullable: false),
                    process = table.Column<string>(type: "varchar(200)", nullable: false),
                    category = table.Column<string>(type: "varchar(200)", nullable: false),
                    delete = table.Column<bool>(type: "bool", nullable: false),
                    FileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.code);
                    table.UniqueConstraint("AK_Document_FileId", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Document_File_code",
                        column: x => x.code,
                        principalTable: "File",
                        principalColumn: "DocumentId",
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
