using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkhilD_301057929.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseName = table.Column<string>(nullable: true),
                    courseCode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    courseDepartment = table.Column<string>(nullable: true),
                    coursePre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseCode);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    facultyId = table.Column<int>(nullable: false),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    department = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    ext = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.facultyId);
                });

            migrationBuilder.CreateTable(
                name: "AssignFaculties",
                columns: table => new
                {
                    classId = table.Column<int>(nullable: false),
                    facultyId = table.Column<int>(nullable: false),
                    courseCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignFaculties", x => x.classId);
                    table.ForeignKey(
                        name: "FK_AssignFaculties_Courses_courseCode",
                        column: x => x.courseCode,
                        principalTable: "Courses",
                        principalColumn: "courseCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignFaculties_Faculties_facultyId",
                        column: x => x.facultyId,
                        principalTable: "Faculties",
                        principalColumn: "facultyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignFaculties_courseCode",
                table: "AssignFaculties",
                column: "courseCode");

            migrationBuilder.CreateIndex(
                name: "IX_AssignFaculties_facultyId",
                table: "AssignFaculties",
                column: "facultyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignFaculties");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
