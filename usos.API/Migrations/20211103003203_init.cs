using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace usos.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_department", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    index_number = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    semester = table.Column<int>(type: "integer", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "degree_course",
                columns: table => new
                {
                    degree_course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    degree_course_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_degree_course", x => x.degree_course_id);
                    table.ForeignKey(
                        name: "fk_degree_course_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "department_id", "department_name" },
                values: new object[,]
                {
                    { new Guid("11d45e9e-fa19-4d4a-9cac-8045ab9631e3"), "WBiA" },
                    { new Guid("81ff6218-af8f-4e6e-b18b-1f17461e2a88"), "WeAiI" }
                });

            migrationBuilder.InsertData(
                table: "degree_course",
                columns: new[] { "degree_course_id", "degree_course_name", "department_id" },
                values: new object[,]
                {
                    { new Guid("ceef9633-26d0-484c-b4ca-5302067c7bd6"), "Architecture", new Guid("11d45e9e-fa19-4d4a-9cac-8045ab9631e3") },
                    { new Guid("de4c8442-f363-4872-988f-003840303158"), "ComputerScience", new Guid("81ff6218-af8f-4e6e-b18b-1f17461e2a88") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_degree_course_department_id",
                table: "degree_course",
                column: "department_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "degree_course");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
