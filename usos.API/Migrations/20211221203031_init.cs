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
                    card_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
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
                    card_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
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
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
                name: "lecturer",
                columns: table => new
                {
                    lecturer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    department_id = table.Column<Guid>(type: "uuid", nullable: false),
                    card_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    degree_course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    term = table.Column<int>(type: "integer", maxLength: 2, nullable: false)
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
                    degree_course_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject_name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
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
                    recipent = table.Column<Guid>(type: "uuid", maxLength: 50, nullable: false),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    note = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_accepted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_application", x => x.application_id);
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
                    note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    rating = table.Column<int>(type: "integer", maxLength: 10, nullable: false)
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
                    marks = table.Column<double[]>(type: "double precision[]", maxLength: 100, nullable: true)
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
                        column: x => x.student_id,
                        principalTable: "subject",
                        principalColumn: "subject_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "department_id", "department_name" },
                values: new object[,]
                {
                    { new Guid("87a0557a-68ca-4cbc-854d-1674f52158e7"), "ISGiE" },
                    { new Guid("e3757241-42e2-4f61-a358-f1c8e9699b13"), "WBiA" },
                    { new Guid("1e19b000-cf2b-4e48-ab46-72fef4ccac7c"), "WMiBM" },
                    { new Guid("9ab8c1c2-2139-4998-9250-e02ad7123650"), "WEAiI" },
                    { new Guid("daed2e1e-f52f-4e53-a7e8-e3398630f404"), "WZiMK" }
                });

            migrationBuilder.InsertData(
                table: "rector",
                columns: new[] { "rector_id", "card_id", "email", "first_name", "phone_number", "surname" },
                values: new object[] { new Guid("0912ef3e-a9e6-49f0-a11d-2924609f7fc1"), "000000", "admin@admin.com", "Admin", "000000000", "Admin" });

            migrationBuilder.InsertData(
                table: "degree_course",
                columns: new[] { "degree_course_id", "degree_course_name", "department_id" },
                values: new object[,]
                {
                    { new Guid("109f7f43-f17f-4de5-ac1e-b14a462fb447"), "Geodezja i kartografia", new Guid("87a0557a-68ca-4cbc-854d-1674f52158e7") },
                    { new Guid("40a4b8b9-5432-4854-84ec-704af9aaa382"), "Inżynieria środowiska", new Guid("87a0557a-68ca-4cbc-854d-1674f52158e7") },
                    { new Guid("c1db08e1-25fb-4e92-ad6a-e1d797d98cb7"), "Odnawialne źródła energii", new Guid("87a0557a-68ca-4cbc-854d-1674f52158e7") },
                    { new Guid("efdf7a83-a087-4572-bca3-01968464a5c5"), "Architektura", new Guid("e3757241-42e2-4f61-a358-f1c8e9699b13") },
                    { new Guid("313f8bfd-d643-44dc-b2fb-f7c84979bdc8"), "Budownictwo", new Guid("e3757241-42e2-4f61-a358-f1c8e9699b13") },
                    { new Guid("3bbd35cc-7727-4f2f-997d-96e254157eda"), "Automatyka i robotyka", new Guid("1e19b000-cf2b-4e48-ab46-72fef4ccac7c") },
                    { new Guid("fd1ee5e5-1bfd-4b6c-99fc-21ca4c7144ef"), "Mechanika i budowa maszyn", new Guid("1e19b000-cf2b-4e48-ab46-72fef4ccac7c") },
                    { new Guid("2a848f15-b441-4c1c-aa3c-d296db507644"), "Elektromobilność", new Guid("9ab8c1c2-2139-4998-9250-e02ad7123650") },
                    { new Guid("8133ad4f-6522-407f-a91a-97549da65c18"), "Elektrotechnika", new Guid("9ab8c1c2-2139-4998-9250-e02ad7123650") },
                    { new Guid("e05f28ea-85e5-477f-9f95-5f731c38a36a"), "Energetyka", new Guid("9ab8c1c2-2139-4998-9250-e02ad7123650") },
                    { new Guid("6c535e65-8d67-4fd0-b4b1-6eaeb8af34c4"), "Informatyka", new Guid("9ab8c1c2-2139-4998-9250-e02ad7123650") },
                    { new Guid("c077047c-f985-44d4-9d2d-f21cd3571f21"), "Teleinformatyka", new Guid("9ab8c1c2-2139-4998-9250-e02ad7123650") },
                    { new Guid("7514321c-d664-47ab-b522-3f4e17d41403"), "Ekonomia", new Guid("daed2e1e-f52f-4e53-a7e8-e3398630f404") },
                    { new Guid("82e3b4d8-a54f-40a0-a1a4-fd21d6c9ef21"), "Logistyka", new Guid("daed2e1e-f52f-4e53-a7e8-e3398630f404") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_advert_deanery_worker_id",
                table: "advert",
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
