﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NganHangDe.DataAccess;

#nullable disable

namespace NganHangDe.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NganHangDe.ModelsDb.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Grade")
                        .HasColumnType("float");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Grade = 1.0,
                            QuestionId = 1,
                            Text = "Answer Text 1 - 0"
                        },
                        new
                        {
                            Id = 5,
                            Grade = 0.0,
                            QuestionId = 1,
                            Text = "Answer Text 1 - 1"
                        },
                        new
                        {
                            Id = 6,
                            Grade = 0.0,
                            QuestionId = 1,
                            Text = "Answer Text 1 - 2"
                        },
                        new
                        {
                            Id = 7,
                            Grade = 0.0,
                            QuestionId = 1,
                            Text = "Answer Text 1 - 3"
                        },
                        new
                        {
                            Id = 8,
                            Grade = 1.0,
                            QuestionId = 2,
                            Text = "Answer Text 2 - 0"
                        },
                        new
                        {
                            Id = 9,
                            Grade = 0.0,
                            QuestionId = 2,
                            Text = "Answer Text 2 - 1"
                        },
                        new
                        {
                            Id = 10,
                            Grade = 0.0,
                            QuestionId = 2,
                            Text = "Answer Text 2 - 2"
                        },
                        new
                        {
                            Id = 11,
                            Grade = 0.0,
                            QuestionId = 2,
                            Text = "Answer Text 2 - 3"
                        },
                        new
                        {
                            Id = 12,
                            Grade = 1.0,
                            QuestionId = 3,
                            Text = "Answer Text 3 - 0"
                        },
                        new
                        {
                            Id = 13,
                            Grade = 0.0,
                            QuestionId = 3,
                            Text = "Answer Text 3 - 1"
                        },
                        new
                        {
                            Id = 14,
                            Grade = 0.0,
                            QuestionId = 3,
                            Text = "Answer Text 3 - 2"
                        },
                        new
                        {
                            Id = 15,
                            Grade = 0.0,
                            QuestionId = 3,
                            Text = "Answer Text 3 - 3"
                        },
                        new
                        {
                            Id = 16,
                            Grade = 1.0,
                            QuestionId = 4,
                            Text = "Answer Text 4 - 0"
                        },
                        new
                        {
                            Id = 17,
                            Grade = 0.0,
                            QuestionId = 4,
                            Text = "Answer Text 4 - 1"
                        },
                        new
                        {
                            Id = 18,
                            Grade = 0.0,
                            QuestionId = 4,
                            Text = "Answer Text 4 - 2"
                        },
                        new
                        {
                            Id = 19,
                            Grade = 0.0,
                            QuestionId = 4,
                            Text = "Answer Text 4 - 3"
                        },
                        new
                        {
                            Id = 20,
                            Grade = 1.0,
                            QuestionId = 5,
                            Text = "Answer Text 5 - 0"
                        },
                        new
                        {
                            Id = 21,
                            Grade = 0.0,
                            QuestionId = 5,
                            Text = "Answer Text 5 - 1"
                        },
                        new
                        {
                            Id = 22,
                            Grade = 0.0,
                            QuestionId = 5,
                            Text = "Answer Text 5 - 2"
                        },
                        new
                        {
                            Id = 23,
                            Grade = 0.0,
                            QuestionId = 5,
                            Text = "Answer Text 5 - 3"
                        },
                        new
                        {
                            Id = 24,
                            Grade = 1.0,
                            QuestionId = 6,
                            Text = "Answer Text 6 - 0"
                        },
                        new
                        {
                            Id = 25,
                            Grade = 0.0,
                            QuestionId = 6,
                            Text = "Answer Text 6 - 1"
                        },
                        new
                        {
                            Id = 26,
                            Grade = 0.0,
                            QuestionId = 6,
                            Text = "Answer Text 6 - 2"
                        },
                        new
                        {
                            Id = 27,
                            Grade = 0.0,
                            QuestionId = 6,
                            Text = "Answer Text 6 - 3"
                        },
                        new
                        {
                            Id = 28,
                            Grade = 1.0,
                            QuestionId = 7,
                            Text = "Answer Text 7 - 0"
                        },
                        new
                        {
                            Id = 29,
                            Grade = 0.0,
                            QuestionId = 7,
                            Text = "Answer Text 7 - 1"
                        },
                        new
                        {
                            Id = 30,
                            Grade = 0.0,
                            QuestionId = 7,
                            Text = "Answer Text 7 - 2"
                        },
                        new
                        {
                            Id = 31,
                            Grade = 0.0,
                            QuestionId = 7,
                            Text = "Answer Text 7 - 3"
                        },
                        new
                        {
                            Id = 32,
                            Grade = 1.0,
                            QuestionId = 8,
                            Text = "Answer Text 8 - 0"
                        },
                        new
                        {
                            Id = 33,
                            Grade = 0.0,
                            QuestionId = 8,
                            Text = "Answer Text 8 - 1"
                        },
                        new
                        {
                            Id = 34,
                            Grade = 0.0,
                            QuestionId = 8,
                            Text = "Answer Text 8 - 2"
                        },
                        new
                        {
                            Id = 35,
                            Grade = 0.0,
                            QuestionId = 8,
                            Text = "Answer Text 8 - 3"
                        },
                        new
                        {
                            Id = 36,
                            Grade = 1.0,
                            QuestionId = 9,
                            Text = "Answer Text 9 - 0"
                        },
                        new
                        {
                            Id = 37,
                            Grade = 0.0,
                            QuestionId = 9,
                            Text = "Answer Text 9 - 1"
                        },
                        new
                        {
                            Id = 38,
                            Grade = 0.0,
                            QuestionId = 9,
                            Text = "Answer Text 9 - 2"
                        },
                        new
                        {
                            Id = 39,
                            Grade = 0.0,
                            QuestionId = 9,
                            Text = "Answer Text 9 - 3"
                        },
                        new
                        {
                            Id = 40,
                            Grade = 1.0,
                            QuestionId = 10,
                            Text = "Answer Text 10 - 0"
                        },
                        new
                        {
                            Id = 41,
                            Grade = 0.0,
                            QuestionId = 10,
                            Text = "Answer Text 10 - 1"
                        },
                        new
                        {
                            Id = 42,
                            Grade = 0.0,
                            QuestionId = 10,
                            Text = "Answer Text 10 - 2"
                        },
                        new
                        {
                            Id = 43,
                            Grade = 0.0,
                            QuestionId = 10,
                            Text = "Answer Text 10 - 3"
                        });
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Info = "Test",
                            Name = "TEst 1"
                        },
                        new
                        {
                            Id = 2,
                            Info = "Test",
                            Name = "TEst 2"
                        },
                        new
                        {
                            Id = 3,
                            Info = "Test",
                            Name = "TEst 3",
                            ParentCategoryId = 1
                        });
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "Question 1",
                            Text = "Question Text 1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "Question 2",
                            Text = "Question Text 2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Name = "Question 3",
                            Text = "Question Text 3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            Name = "Question 4",
                            Text = "Question Text 4"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Name = "Question 5",
                            Text = "Question Text 5"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Name = "Question 6",
                            Text = "Question Text 6"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Name = "Question 7",
                            Text = "Question Text 7"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            Name = "Question 8",
                            Text = "Question Text 8"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 2,
                            Name = "Question 9",
                            Text = "Question Text 9"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Name = "Question 10",
                            Text = "Question Text 10"
                        });
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<TimeSpan>("TimeLimit")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Quiz1",
                            Name = "Quiz1",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Description = "Quiz2",
                            Name = "Quiz2",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            Description = "Quiz3",
                            Name = "Quiz3",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            Description = "Quiz4",
                            Name = "Quiz4",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            Description = "Quiz5",
                            Name = "Quiz5",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            Description = "Quiz6",
                            Name = "Quiz6",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            Description = "Quiz7",
                            Name = "Quiz7",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            Description = "Quiz8",
                            Name = "Quiz8",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            Description = "Quiz9",
                            Name = "Quiz9",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            Description = "Quiz10",
                            Name = "Quiz10",
                            TimeLimit = new TimeSpan(0, 0, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.QuizQuestion", b =>
                {
                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("QuizId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuizQuestion");
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Answer", b =>
                {
                    b.HasOne("NganHangDe.ModelsDb.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Category", b =>
                {
                    b.HasOne("NganHangDe.ModelsDb.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Question", b =>
                {
                    b.HasOne("NganHangDe.ModelsDb.Category", "Category")
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.QuizQuestion", b =>
                {
                    b.HasOne("NganHangDe.ModelsDb.Question", "Question")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NganHangDe.ModelsDb.Quiz", "Quiz")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Category", b =>
                {
                    b.Navigation("ChildCategories");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("QuizQuestions");
                });

            modelBuilder.Entity("NganHangDe.ModelsDb.Quiz", b =>
                {
                    b.Navigation("QuizQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}
