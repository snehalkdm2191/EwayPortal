﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Api.Model;

namespace Portal.Api.Migrations
{
    [DbContext(typeof(EwayPortalDbContext))]
    [Migration("20220511201600_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Portal.Api.Model.ContentGroup", b =>
                {
                    b.Property<Guid>("ContentGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ContentGroupId");

                    b.HasIndex("ContentId");

                    b.HasIndex("EmployeeGroupId");

                    b.ToTable("ContentGroup");
                });

            modelBuilder.Entity("Portal.Api.Model.ContentMaster", b =>
                {
                    b.Property<Guid>("ContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContentHeader")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ContentId");

                    b.ToTable("ContentMaster");

                    b.HasData(
                        new
                        {
                            ContentId = new Guid("dca67cf1-7a94-47bd-befc-5aced6af5a6f"),
                            ContentHeader = "welcome to organization"
                        },
                        new
                        {
                            ContentId = new Guid("9cd0405e-e1ea-40a1-8224-4ed8483a19e1"),
                            ContentHeader = "Team meet up"
                        },
                        new
                        {
                            ContentId = new Guid("560136f2-f40f-4f3e-a3b5-b443aaeb7035"),
                            ContentHeader = "Hardware software Access information"
                        },
                        new
                        {
                            ContentId = new Guid("e20b1eac-f4af-4821-ac70-ed675421bd80"),
                            ContentHeader = "On-boarding training"
                        });
                });

            modelBuilder.Entity("Portal.Api.Model.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EmployeeGroupId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeGroupId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Portal.Api.Model.EmployeeContent", b =>
                {
                    b.Property<Guid>("EmployeeContentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid?>("ContentGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Employeeid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("EmployeeIId");

                    b.HasKey("EmployeeContentId");

                    b.HasIndex("ContentGroupId");

                    b.HasIndex("Employeeid");

                    b.ToTable("EmployeeContent");
                });

            modelBuilder.Entity("Portal.Api.Model.EmployeeGroup", b =>
                {
                    b.Property<Guid>("EmployeeGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmployeeGroupName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("EmployeeGroupId");

                    b.ToTable("EmployeeGroup");

                    b.HasData(
                        new
                        {
                            EmployeeGroupId = new Guid("26b53c0e-f5c1-493a-b018-126f9ed18987"),
                            EmployeeGroupName = "Sales"
                        },
                        new
                        {
                            EmployeeGroupId = new Guid("4cbc3cd7-c619-4090-99b0-e91a689f886b"),
                            EmployeeGroupName = "Marketing"
                        },
                        new
                        {
                            EmployeeGroupId = new Guid("23ffa6db-9a01-4290-a3e3-26a521826983"),
                            EmployeeGroupName = "IT"
                        });
                });

            modelBuilder.Entity("Portal.Api.Model.ContentGroup", b =>
                {
                    b.HasOne("Portal.Api.Model.ContentMaster", "Content")
                        .WithMany("ContentGroups")
                        .HasForeignKey("ContentId")
                        .HasConstraintName("FK_ContentGroup_ContentMaster");

                    b.HasOne("Portal.Api.Model.EmployeeGroup", "EmployeeGroup")
                        .WithMany("ContentGroups")
                        .HasForeignKey("EmployeeGroupId")
                        .HasConstraintName("FK_ContentGroup_EmployeeGroup");

                    b.Navigation("Content");

                    b.Navigation("EmployeeGroup");
                });

            modelBuilder.Entity("Portal.Api.Model.Employee", b =>
                {
                    b.HasOne("Portal.Api.Model.EmployeeGroup", "EmployeeGroup")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeGroupId")
                        .HasConstraintName("FK_Employee_EmployeeGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeGroup");
                });

            modelBuilder.Entity("Portal.Api.Model.EmployeeContent", b =>
                {
                    b.HasOne("Portal.Api.Model.ContentGroup", "ContentGroup")
                        .WithMany("EmployeeContents")
                        .HasForeignKey("ContentGroupId")
                        .HasConstraintName("FK_EmployeeContent_ContentGroup");

                    b.HasOne("Portal.Api.Model.Employee", "Employee")
                        .WithMany("EmployeeContents")
                        .HasForeignKey("Employeeid")
                        .HasConstraintName("FK_EmployeeContent_Employee");

                    b.Navigation("ContentGroup");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Portal.Api.Model.ContentGroup", b =>
                {
                    b.Navigation("EmployeeContents");
                });

            modelBuilder.Entity("Portal.Api.Model.ContentMaster", b =>
                {
                    b.Navigation("ContentGroups");
                });

            modelBuilder.Entity("Portal.Api.Model.Employee", b =>
                {
                    b.Navigation("EmployeeContents");
                });

            modelBuilder.Entity("Portal.Api.Model.EmployeeGroup", b =>
                {
                    b.Navigation("ContentGroups");

                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}