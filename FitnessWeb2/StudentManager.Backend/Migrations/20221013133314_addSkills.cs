using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManager.Backend.Migrations
{
    public partial class addSkills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillsStudents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillsStudents",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsStudents", x => new { x.SkillId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_SkillsStudents_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillsStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillsStudents_StudentId",
                table: "SkillsStudents",
                column: "StudentId");
        }
    }
}
