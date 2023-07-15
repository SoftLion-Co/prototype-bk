﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MIG.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230715051451_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Avatar")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employment")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Viewers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blog", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastWasOnline")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkedIn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.OrderBlog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("OrderBlog", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.OrderProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OrderProject", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Paragraph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Paragraph", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Picture", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DateYear")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RequestDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultFirstParagraph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultSecondParagraph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultThirdParagraph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SolutionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Mark")
                        .HasColumnType("decimal(2,1)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Rating", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.SVG", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BlogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("SVG", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Blog", b =>
                {
                    b.HasOne("DAL.Entities.Author", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Author");
                });

            modelBuilder.Entity("DAL.Entities.Paragraph", b =>
                {
                    b.HasOne("DAL.Entities.Blog", "Blog")
                        .WithMany("Paragraphs")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.Project", "Project")
                        .WithMany("Paragraphs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Blog");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DAL.Entities.Picture", b =>
                {
                    b.HasOne("DAL.Entities.Blog", "Blog")
                        .WithMany("Pictures")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.Project", "Project")
                        .WithMany("Pictures")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Blog");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DAL.Entities.Project", b =>
                {
                    b.HasOne("DAL.Entities.Country", "Country")
                        .WithMany("Projects")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DAL.Entities.Customer", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DAL.Entities.Rating", b =>
                {
                    b.HasOne("DAL.Entities.Project", "Project")
                        .WithMany("Ratings")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DAL.Entities.SVG", b =>
                {
                    b.HasOne("DAL.Entities.Blog", "Blog")
                        .WithMany("SVGs")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("DAL.Entities.Author", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("DAL.Entities.Blog", b =>
                {
                    b.Navigation("Paragraphs");

                    b.Navigation("Pictures");

                    b.Navigation("SVGs");
                });

            modelBuilder.Entity("DAL.Entities.Country", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DAL.Entities.Customer", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DAL.Entities.Project", b =>
                {
                    b.Navigation("Paragraphs");

                    b.Navigation("Pictures");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
