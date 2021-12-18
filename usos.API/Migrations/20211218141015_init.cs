using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace usos.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deanery_worker",
                columns: table => new
                {
                    deanery_worker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_id = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_deanery_worker", x => x.deanery_worker_id);
                });

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
                name: "rector",
                columns: table => new
                {
                    rector_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_id = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rector", x => x.rector_id);
                });

            migrationBuilder.CreateTable(
                name: "advert",
                columns: table => new
                {
                    advert_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deanery_worker_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_advert", x => x.advert_id);
                    table.ForeignKey(
                        name: "fk_advert_deanery_worker_deanery_worker_id",
                        column: x => x.deanery_worker_id,
                        principalTable: "deanery_worker",
                        principalColumn: "deanery_worker_id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    degree_course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    term = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group", x => x.group_id);
                    table.ForeignKey(
                        name: "fk_group_degree_course_degree_course_id",
                        column: x => x.degree_course_id,
                        principalTable: "degree_course",
                        principalColumn: "degree_course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_name = table.Column<string>(type: "text", nullable: true),
                    degree_course_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subject", x => x.subject_id);
                    table.ForeignKey(
                        name: "fk_subject_degree_course_degree_course_id",
                        column: x => x.degree_course_id,
                        principalTable: "degree_course",
                        principalColumn: "degree_course_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lecturer",
                columns: table => new
                {
                    lecturer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_id = table.Column<string>(type: "text", nullable: true),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    surname = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    group_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lecturer", x => x.lecturer_id);
                    table.ForeignKey(
                        name: "fk_lecturer_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lecturer_group_group_id",
                        column: x => x.group_id,
                        principalTable: "group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "fk_student_group_group_id",
                        column: x => x.group_id,
                        principalTable: "group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lecturer_group",
                columns: table => new
                {
                    lecturer_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lecturer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lecturer_group", x => x.lecturer_group_id);
                    table.ForeignKey(
                        name: "fk_lecturer_group_group_group_id",
                        column: x => x.group_id,
                        principalTable: "group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lecturer_group_lecturer_lecturer_id",
                        column: x => x.lecturer_id,
                        principalTable: "lecturer",
                        principalColumn: "lecturer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lecturer_group_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "application",
                columns: table => new
                {
                    application_id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    recipent = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    note = table.Column<string>(type: "text", nullable: true),
                    is_accepted = table.Column<bool>(type: "boolean", nullable: false),
                    deanery_worker_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application", x => x.application_id);
                    table.ForeignKey(
                        name: "fk_application_deanery_worker_deanery_worker_id",
                        column: x => x.deanery_worker_id,
                        principalTable: "deanery_worker",
                        principalColumn: "deanery_worker_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_application_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionnaire",
                columns: table => new
                {
                    questionnaire_id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    lecturer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    note = table.Column<string>(type: "text", nullable: true),
                    rating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_questionnaire", x => x.questionnaire_id);
                    table.ForeignKey(
                        name: "fk_questionnaire_lecturer_lecturer_id",
                        column: x => x.lecturer_id,
                        principalTable: "lecturer",
                        principalColumn: "lecturer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_questionnaire_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_subject",
                columns: table => new
                {
                    student_subject_id = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_id = table.Column<Guid>(type: "uuid", nullable: false),
                    marks = table.Column<double[]>(type: "double precision[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_student_subject", x => x.student_subject_id);
                    table.ForeignKey(
                        name: "fk_student_subject_student_student_id",
                        column: x => x.student_id,
                        principalTable: "student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_student_subject_subject_subject_id",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "department_id", "department_name" },
                values: new object[,]
                {
                    { new Guid("74591e57-1aca-4ea0-bcc3-6332a66c007e"), "WBiA" },
                    { new Guid("e1511aea-18aa-43c1-a1ca-723159c57fae"), "WeAiI" }
                });

            migrationBuilder.InsertData(
                table: "degree_course",
                columns: new[] { "degree_course_id", "degree_course_name", "department_id" },
                values: new object[,]
                {
                    { new Guid("e70a16db-e990-4440-b826-964932fc1fe2"), "Architecture", new Guid("74591e57-1aca-4ea0-bcc3-6332a66c007e") },
                    { new Guid("0c5807a6-4bd5-4d9d-a00c-24711ca983c1"), "ComputerScience", new Guid("e1511aea-18aa-43c1-a1ca-723159c57fae") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_advert_deanery_worker_id",
                table: "advert",
                column: "deanery_worker_id");

            migrationBuilder.CreateIndex(
                name: "ix_application_deanery_worker_id",
                table: "application",
                column: "deanery_worker_id");

            migrationBuilder.CreateIndex(
                name: "ix_application_student_id",
                table: "application",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_degree_course_department_id",
                table: "degree_course",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_group_degree_course_id",
                table: "group",
                column: "degree_course_id");

            migrationBuilder.CreateIndex(
                name: "ix_lecturer_department_id",
                table: "lecturer",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_lecturer_group_id",
                table: "lecturer",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "ix_lecturer_group_group_id",
                table: "lecturer_group",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "ix_lecturer_group_lecturer_id",
                table: "lecturer_group",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_lecturer_group_subject_id",
                table: "lecturer_group",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_questionnaire_lecturer_id",
                table: "questionnaire",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_questionnaire_student_id",
                table: "questionnaire",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_group_id",
                table: "student",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_subject_student_id",
                table: "student_subject",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "ix_student_subject_subject_id",
                table: "student_subject",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "ix_subject_degree_course_id",
                table: "subject",
                column: "degree_course_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advert");

            migrationBuilder.DropTable(
                name: "application");

            migrationBuilder.DropTable(
                name: "lecturer_group");

            migrationBuilder.DropTable(
                name: "questionnaire");

            migrationBuilder.DropTable(
                name: "rector");

            migrationBuilder.DropTable(
                name: "student_subject");

            migrationBuilder.DropTable(
                name: "deanery_worker");

            migrationBuilder.DropTable(
                name: "lecturer");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "degree_course");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
