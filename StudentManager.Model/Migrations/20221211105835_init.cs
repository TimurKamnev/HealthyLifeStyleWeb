using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManager.Backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitnessType",
                columns: table => new
                {
                    FitnessProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessType", x => x.FitnessProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthdayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FitnessTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessProgram_FitnessType_FitnessTypeId",
                        column: x => x.FitnessTypeId,
                        principalTable: "FitnessType",
                        principalColumn: "FitnessProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonFitnessProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FitnessTypeId = table.Column<int>(type: "int", nullable: false),
                    IsCurrent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonFitnessProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonFitnessProgram_FitnessType_FitnessTypeId",
                        column: x => x.FitnessTypeId,
                        principalTable: "FitnessType",
                        principalColumn: "FitnessProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonFitnessProgram_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FitnessTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FitnessProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FitnessTip_FitnessProgram_FitnessProgramId",
                        column: x => x.FitnessProgramId,
                        principalTable: "FitnessProgram",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    FitnessProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_FitnessProgram_FitnessProgramId",
                        column: x => x.FitnessProgramId,
                        principalTable: "FitnessProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountOfRepeats = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TrainingId",
                table: "Exercise",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessProgram_FitnessTypeId",
                table: "FitnessProgram",
                column: "FitnessTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessTip_FitnessProgramId",
                table: "FitnessTip",
                column: "FitnessProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFitnessProgram_FitnessTypeId",
                table: "PersonFitnessProgram",
                column: "FitnessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonFitnessProgram_PersonId",
                table: "PersonFitnessProgram",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_FitnessProgramId",
                table: "Training",
                column: "FitnessProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "FitnessTip");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "PersonFitnessProgram");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "FitnessProgram");

            migrationBuilder.DropTable(
                name: "FitnessType");
        }
    }
}
