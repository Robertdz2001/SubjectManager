using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubjectManagerAPI.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningMaterials_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearningMaterials_SubjectId",
                table: "LearningMaterials",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_UserId",
                table: "Subjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_SubjectId",
                table: "Tests",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningMaterials");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
