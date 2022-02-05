﻿// <auto-generated />
using System;
using HomeWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeWork.Migrations
{
    [DbContext(typeof(AssignmentContext))]
    [Migration("20220204173349_changeMatric")]
    partial class changeMatric
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HomeWork.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("DueDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("TotalMark")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("HomeWork.Models.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone_no")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("HomeWork.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("DOB")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Matric_no")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone_no")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("HomeWork.Models.Submission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AssignmentsId")
                        .HasColumnType("int");

                    b.Property<string>("AssingmentFileUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Comment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Date_Marked")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Date_Submitted")
                        .HasColumnType("datetime2");

                    b.Property<string>("DueDate")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Score")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("HomeWork.Models.Assignment", b =>
                {
                    b.HasOne("HomeWork.Models.Lecturer", "Lecturer")
                        .WithMany()
                        .HasForeignKey("LecturerId");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("HomeWork.Models.Submission", b =>
                {
                    b.HasOne("HomeWork.Models.Assignment", "Assignments")
                        .WithMany("Submitted_Assignment")
                        .HasForeignKey("AssignmentsId");

                    b.HasOne("HomeWork.Models.Student", "Students")
                        .WithMany("Submitted_Homework")
                        .HasForeignKey("StudentsId");

                    b.Navigation("Assignments");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("HomeWork.Models.Assignment", b =>
                {
                    b.Navigation("Submitted_Assignment");
                });

            modelBuilder.Entity("HomeWork.Models.Student", b =>
                {
                    b.Navigation("Submitted_Homework");
                });
#pragma warning restore 612, 618
        }
    }
}
