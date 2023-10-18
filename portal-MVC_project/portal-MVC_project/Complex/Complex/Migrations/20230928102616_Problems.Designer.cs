﻿// <auto-generated />
using System;
using Complex.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Complex.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20230928102616_Problems")]
    partial class Problems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Complex.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProgressInPercentage")
                        .HasColumnType("float");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Complex.Models.Material", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("UserId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("Complex.Models.Skill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("UserId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Complex.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfJoining")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Complex.Models.Course", b =>
                {
                    b.HasOne("Complex.Models.User", null)
                        .WithMany("AvailableCourses")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Complex.Models.Material", b =>
                {
                    b.HasOne("Complex.Models.Course", null)
                        .WithMany("Materials")
                        .HasForeignKey("CourseID");

                    b.HasOne("Complex.Models.User", null)
                        .WithMany("UserMaterials")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Complex.Models.Skill", b =>
                {
                    b.HasOne("Complex.Models.Course", null)
                        .WithMany("Skills")
                        .HasForeignKey("CourseID");

                    b.HasOne("Complex.Models.User", null)
                        .WithMany("UserSkills")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Complex.Models.Course", b =>
                {
                    b.Navigation("Materials");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Complex.Models.User", b =>
                {
                    b.Navigation("AvailableCourses");

                    b.Navigation("UserMaterials");

                    b.Navigation("UserSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
