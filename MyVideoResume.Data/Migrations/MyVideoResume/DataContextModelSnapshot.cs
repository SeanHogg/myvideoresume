﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyVideoResume.Data;

#nullable disable

namespace MyVideoResume.Server.Data.Migrations.MyVideoResume
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyVideoResume.Data.Models.JobPreferencesEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmploymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Industry")
                        .HasColumnType("int");

                    b.Property<float>("MinimumSalary")
                        .HasColumnType("real");

                    b.Property<int>("PaySchedule")
                        .HasColumnType("int");

                    b.Property<int>("Seniority")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("JobPreferences", null, t =>
                        {
                            t.HasTrigger("JobPreferences_Trigger");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });
#pragma warning restore 612, 618
        }
    }
}
