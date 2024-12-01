using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class JobPosting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmploymentType",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "GoLiveDate",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<float>(
                name: "MaximumSalary",
                table: "Jobs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinimumSalary",
                table: "Jobs",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PaySchedule",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Seniority",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmploymentType",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "GoLiveDate",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MaximumSalary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MinimumSalary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PaySchedule",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Seniority",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Jobs");
        }
    }
}
