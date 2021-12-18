﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using usos.API;

namespace usos.API.Migrations
{
    [DbContext(typeof(UsosDbContext))]
    [Migration("20211218141015_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("usos.API.Entities.Advert", b =>
                {
                    b.Property<Guid>("AdvertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("advert_id");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data");

                    b.Property<Guid>("DeaneryWorkerId")
                        .HasColumnType("uuid")
                        .HasColumnName("deanery_worker_id");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("AdvertId")
                        .HasName("pk_advert");

                    b.HasIndex("DeaneryWorkerId")
                        .HasDatabaseName("ix_advert_deanery_worker_id");

                    b.ToTable("advert");
                });

            modelBuilder.Entity("usos.API.Entities.Application", b =>
                {
                    b.Property<Guid>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("application_id");

                    b.Property<Guid?>("DeaneryWorkerId")
                        .HasColumnType("uuid")
                        .HasColumnName("deanery_worker_id");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_accepted");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<Guid>("Recipent")
                        .HasColumnType("uuid")
                        .HasColumnName("recipent");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid")
                        .HasColumnName("student_id");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("ApplicationId")
                        .HasName("pk_application");

                    b.HasIndex("DeaneryWorkerId")
                        .HasDatabaseName("ix_application_deanery_worker_id");

                    b.HasIndex("StudentId")
                        .HasDatabaseName("ix_application_student_id");

                    b.ToTable("application");
                });

            modelBuilder.Entity("usos.API.Entities.DeaneryWorker", b =>
                {
                    b.Property<Guid>("DeaneryWorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("deanery_worker_id");

                    b.Property<string>("CardId")
                        .HasColumnType("text")
                        .HasColumnName("card_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("DeaneryWorkerId")
                        .HasName("pk_deanery_worker");

                    b.ToTable("deanery_worker");
                });

            modelBuilder.Entity("usos.API.Entities.DegreeCourse", b =>
                {
                    b.Property<Guid>("DegreeCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("degree_course_id");

                    b.Property<string>("DegreeCourseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("degree_course_name");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.HasKey("DegreeCourseId")
                        .HasName("pk_degree_course");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_degree_course_department_id");

                    b.ToTable("degree_course");

                    b.HasData(
                        new
                        {
                            DegreeCourseId = new Guid("e70a16db-e990-4440-b826-964932fc1fe2"),
                            DegreeCourseName = "Architecture",
                            DepartmentId = new Guid("74591e57-1aca-4ea0-bcc3-6332a66c007e")
                        },
                        new
                        {
                            DegreeCourseId = new Guid("0c5807a6-4bd5-4d9d-a00c-24711ca983c1"),
                            DegreeCourseName = "ComputerScience",
                            DepartmentId = new Guid("e1511aea-18aa-43c1-a1ca-723159c57fae")
                        });
                });

            modelBuilder.Entity("usos.API.Entities.Department", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("department_name");

                    b.HasKey("DepartmentId")
                        .HasName("pk_department");

                    b.ToTable("department");

                    b.HasData(
                        new
                        {
                            DepartmentId = new Guid("74591e57-1aca-4ea0-bcc3-6332a66c007e"),
                            DepartmentName = "WBiA"
                        },
                        new
                        {
                            DepartmentId = new Guid("e1511aea-18aa-43c1-a1ca-723159c57fae"),
                            DepartmentName = "WeAiI"
                        });
                });

            modelBuilder.Entity("usos.API.Entities.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.Property<Guid>("DegreeCourseId")
                        .HasColumnType("uuid")
                        .HasColumnName("degree_course_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Term")
                        .HasColumnType("integer")
                        .HasColumnName("term");

                    b.HasKey("GroupId")
                        .HasName("pk_group");

                    b.HasIndex("DegreeCourseId")
                        .HasDatabaseName("ix_group_degree_course_id");

                    b.ToTable("group");
                });

            modelBuilder.Entity("usos.API.Entities.Lecturer", b =>
                {
                    b.Property<Guid>("LecturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("lecturer_id");

                    b.Property<string>("CardId")
                        .HasColumnType("text")
                        .HasColumnName("card_id");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<Guid?>("GroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("LecturerId")
                        .HasName("pk_lecturer");

                    b.HasIndex("DepartmentId")
                        .HasDatabaseName("ix_lecturer_department_id");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_lecturer_group_id");

                    b.ToTable("lecturer");
                });

            modelBuilder.Entity("usos.API.Entities.LecturerGroup", b =>
                {
                    b.Property<Guid>("LecturerGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("lecturer_group_id");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.Property<Guid>("LecturerId")
                        .HasColumnType("uuid")
                        .HasColumnName("lecturer_id");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("subject_id");

                    b.HasKey("LecturerGroupId")
                        .HasName("pk_lecturer_group");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_lecturer_group_group_id");

                    b.HasIndex("LecturerId")
                        .HasDatabaseName("ix_lecturer_group_lecturer_id");

                    b.HasIndex("SubjectId")
                        .HasDatabaseName("ix_lecturer_group_subject_id");

                    b.ToTable("lecturer_group");
                });

            modelBuilder.Entity("usos.API.Entities.Questionnaire", b =>
                {
                    b.Property<Guid>("QuestionnaireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("questionnaire_id");

                    b.Property<Guid>("LecturerId")
                        .HasColumnType("uuid")
                        .HasColumnName("lecturer_id");

                    b.Property<string>("Note")
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid")
                        .HasColumnName("student_id");

                    b.HasKey("QuestionnaireId")
                        .HasName("pk_questionnaire");

                    b.HasIndex("LecturerId")
                        .HasDatabaseName("ix_questionnaire_lecturer_id");

                    b.HasIndex("StudentId")
                        .HasDatabaseName("ix_questionnaire_student_id");

                    b.ToTable("questionnaire");
                });

            modelBuilder.Entity("usos.API.Entities.Rector", b =>
                {
                    b.Property<Guid>("RectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("rector_id");

                    b.Property<string>("CardId")
                        .HasColumnType("text")
                        .HasColumnName("card_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("RectorId")
                        .HasName("pk_rector");

                    b.ToTable("rector");
                });

            modelBuilder.Entity("usos.API.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("student_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid")
                        .HasColumnName("group_id");

                    b.Property<int>("IndexNumber")
                        .HasMaxLength(10)
                        .HasColumnType("integer")
                        .HasColumnName("index_number");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<int?>("Semester")
                        .HasMaxLength(1)
                        .HasColumnType("integer")
                        .HasColumnName("semester");

                    b.HasKey("StudentId")
                        .HasName("pk_student");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_student_group_id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("usos.API.Entities.StudentSubject", b =>
                {
                    b.Property<Guid>("StudentSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("student_subject_id");

                    b.Property<double[]>("Marks")
                        .HasColumnType("double precision[]")
                        .HasColumnName("marks");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid")
                        .HasColumnName("student_id");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("subject_id");

                    b.HasKey("StudentSubjectId")
                        .HasName("pk_student_subject");

                    b.HasIndex("StudentId")
                        .HasDatabaseName("ix_student_subject_student_id");

                    b.HasIndex("SubjectId")
                        .HasDatabaseName("ix_student_subject_subject_id");

                    b.ToTable("student_subject");
                });

            modelBuilder.Entity("usos.API.Entities.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("subject_id");

                    b.Property<Guid>("DegreeCourseId")
                        .HasColumnType("uuid")
                        .HasColumnName("degree_course_id");

                    b.Property<string>("SubjectName")
                        .HasColumnType("text")
                        .HasColumnName("subject_name");

                    b.HasKey("SubjectId")
                        .HasName("pk_subject");

                    b.HasIndex("DegreeCourseId")
                        .HasDatabaseName("ix_subject_degree_course_id");

                    b.ToTable("subject");
                });

            modelBuilder.Entity("usos.API.Entities.Advert", b =>
                {
                    b.HasOne("usos.API.Entities.DeaneryWorker", "DeaneryWorker")
                        .WithMany("Advert")
                        .HasForeignKey("DeaneryWorkerId")
                        .HasConstraintName("fk_advert_deanery_worker_deanery_worker_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeaneryWorker");
                });

            modelBuilder.Entity("usos.API.Entities.Application", b =>
                {
                    b.HasOne("usos.API.Entities.DeaneryWorker", null)
                        .WithMany("Applications")
                        .HasForeignKey("DeaneryWorkerId")
                        .HasConstraintName("fk_application_deanery_worker_deanery_worker_id");

                    b.HasOne("usos.API.Entities.Student", "Student")
                        .WithMany("Application")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("fk_application_student_student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("usos.API.Entities.DegreeCourse", b =>
                {
                    b.HasOne("usos.API.Entities.Department", "Department")
                        .WithMany("DegreeCourses")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("fk_degree_course_department_department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("usos.API.Entities.Group", b =>
                {
                    b.HasOne("usos.API.Entities.DegreeCourse", "DegreeCourse")
                        .WithMany("Groups")
                        .HasForeignKey("DegreeCourseId")
                        .HasConstraintName("fk_group_degree_course_degree_course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DegreeCourse");
                });

            modelBuilder.Entity("usos.API.Entities.Lecturer", b =>
                {
                    b.HasOne("usos.API.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("fk_lecturer_department_department_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("usos.API.Entities.Group", null)
                        .WithMany("Lecturers")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("fk_lecturer_group_group_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("usos.API.Entities.LecturerGroup", b =>
                {
                    b.HasOne("usos.API.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .HasConstraintName("fk_lecturer_group_group_group_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("usos.API.Entities.Lecturer", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("fk_lecturer_group_lecturer_lecturer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("usos.API.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("fk_lecturer_group_subject_subject_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("usos.API.Entities.Questionnaire", b =>
                {
                    b.HasOne("usos.API.Entities.Lecturer", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("fk_questionnaire_lecturer_lecturer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("usos.API.Entities.Student", "Student")
                        .WithMany("Questionnaire")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("fk_questionnaire_student_student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("usos.API.Entities.Student", b =>
                {
                    b.HasOne("usos.API.Entities.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("fk_student_group_group_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("usos.API.Entities.StudentSubject", b =>
                {
                    b.HasOne("usos.API.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .HasConstraintName("fk_student_subject_student_student_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("usos.API.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("fk_student_subject_subject_subject_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("usos.API.Entities.Subject", b =>
                {
                    b.HasOne("usos.API.Entities.DegreeCourse", "DegreeCourse")
                        .WithMany("Subjects")
                        .HasForeignKey("DegreeCourseId")
                        .HasConstraintName("fk_subject_degree_course_degree_course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DegreeCourse");
                });

            modelBuilder.Entity("usos.API.Entities.DeaneryWorker", b =>
                {
                    b.Navigation("Advert");

                    b.Navigation("Applications");
                });

            modelBuilder.Entity("usos.API.Entities.DegreeCourse", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("usos.API.Entities.Department", b =>
                {
                    b.Navigation("DegreeCourses");
                });

            modelBuilder.Entity("usos.API.Entities.Group", b =>
                {
                    b.Navigation("Lecturers");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("usos.API.Entities.Student", b =>
                {
                    b.Navigation("Application");

                    b.Navigation("Questionnaire");
                });
#pragma warning restore 612, 618
        }
    }
}
