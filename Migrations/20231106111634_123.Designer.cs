﻿// <auto-generated />
using System;
using EmployeeAttendance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeAttenadance.Migrations
{
    [DbContext(typeof(AttendanceContext))]
    [Migration("20231106111634_123")]
    partial class _123
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeAttendance.Models.Attendance", b =>
                {
                    b.Property<int>("AId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("EmployeeAttendance.Models.EmpDetails", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<string>("Dept")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBYUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedOnDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.ToTable("EmpDetails");
                });

            modelBuilder.Entity("EmployeeAttendance.Models.EmpSalaryDetails", b =>
                {
                    b.Property<int>("SdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Basic")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HRA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOnDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Others")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TsId")
                        .HasColumnType("int");

                    b.HasKey("SdId");

                    b.ToTable("EmpSalaryDetails");
                });

            modelBuilder.Entity("EmployeeAttendance.Models.EmpTotalSalary", b =>
                {
                    b.Property<int>("TsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("ModifiedById")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedByUsername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOnDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalSalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TsId");

                    b.ToTable("EmpTotalSalary");
                });

            modelBuilder.Entity("EmployeeAttendance.Utilities.UserCredentials", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserCredentials");
                });
#pragma warning restore 612, 618
        }
    }
}
