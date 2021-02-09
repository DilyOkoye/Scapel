using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Scapel.API.Migrations
{
    public partial class Answer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
