﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PractiveRoom.Entities;

#nullable disable

namespace PractiveRoom.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240124081810_initdatabase")]
    partial class initdatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PractiveRoom.Models.Room", b =>
                {
                    b.Property<int>("roomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("roomName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("roomId");

                    b.ToTable("room");
                });

            modelBuilder.Entity("PractiveRoom.Models.Schedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("day")
                        .HasColumnType("int");

                    b.Property<int>("endTime")
                        .HasColumnType("int");

                    b.Property<int>("month")
                        .HasColumnType("int");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.Property<int>("startTime")
                        .HasColumnType("int");

                    b.Property<int>("subjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("teacherId")
                        .HasColumnType("char(36)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roomId");

                    b.HasIndex("subjectId");

                    b.HasIndex("teacherId");

                    b.ToTable("schedule");
                });

            modelBuilder.Entity("PractiveRoom.Models.StudentSchedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("Scheduleid")
                        .HasColumnType("int");

                    b.Property<int>("calenderId")
                        .HasColumnType("int");

                    b.Property<Guid>("userId")
                        .HasColumnType("char(36)");

                    b.HasKey("id");

                    b.HasIndex("Scheduleid");

                    b.HasIndex("userId");

                    b.ToTable("StudentSchedule");
                });

            modelBuilder.Entity("PractiveRoom.Models.Subject", b =>
                {
                    b.Property<int>("subjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("subjectId");

                    b.ToTable("subject");
                });

            modelBuilder.Entity("PractiveRoom.Models.Teacher", b =>
                {
                    b.Property<Guid>("teacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("teacherId");

                    b.ToTable("teacher");
                });

            modelBuilder.Entity("PractiveRoom.Models.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("id");

                    b.ToTable("student");
                });

            modelBuilder.Entity("PractiveRoom.Models.Schedule", b =>
                {
                    b.HasOne("PractiveRoom.Models.Room", "room")
                        .WithMany("calenders")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PractiveRoom.Models.Subject", "subject")
                        .WithMany("calenders")
                        .HasForeignKey("subjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PractiveRoom.Models.Teacher", "teacher")
                        .WithMany("calenders")
                        .HasForeignKey("teacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");

                    b.Navigation("subject");

                    b.Navigation("teacher");
                });

            modelBuilder.Entity("PractiveRoom.Models.StudentSchedule", b =>
                {
                    b.HasOne("PractiveRoom.Models.Schedule", null)
                        .WithMany("studentCalenders")
                        .HasForeignKey("Scheduleid");

                    b.HasOne("PractiveRoom.Models.User", null)
                        .WithMany("studentCalenders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PractiveRoom.Models.Room", b =>
                {
                    b.Navigation("calenders");
                });

            modelBuilder.Entity("PractiveRoom.Models.Schedule", b =>
                {
                    b.Navigation("studentCalenders");
                });

            modelBuilder.Entity("PractiveRoom.Models.Subject", b =>
                {
                    b.Navigation("calenders");
                });

            modelBuilder.Entity("PractiveRoom.Models.Teacher", b =>
                {
                    b.Navigation("calenders");
                });

            modelBuilder.Entity("PractiveRoom.Models.User", b =>
                {
                    b.Navigation("studentCalenders");
                });
#pragma warning restore 612, 618
        }
    }
}
