using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManager.Backend.Migrations
{
    public partial class add3rdTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillStudent");

            migrationBuilder.CreateTable(
                name: "StudentsSkills",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSkills", x => new { x.StudentId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_StudentsSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSkills_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSkills_SkillId",
                table: "StudentsSkills",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsSkills");

            migrationBuilder.CreateTable(
                name: "SkillStudent",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillStudent", x => new { x.SkillsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_SkillStudent_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillStudent_StudentsId",
                table: "SkillStudent",
                column: "StudentsId");
        }
    }
}
