using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class ResumeInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResumeInformationId",
                table: "MetaResumes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "MetaData",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResumeInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<int>(type: "int", nullable: false),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaySchedule = table.Column<int>(type: "int", nullable: false),
                    MinimumSalary = table.Column<float>(type: "real", nullable: false),
                    ResumeType = table.Column<int>(type: "int", nullable: false),
                    ResumeSerialized = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeInformation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_ResumeInformationId",
                table: "MetaResumes",
                column: "ResumeInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_MetaResumeEntityId",
                table: "MetaData",
                column: "MetaResumeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaData_MetaResumes_MetaResumeEntityId",
                table: "MetaData",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_ResumeInformation_ResumeInformationId",
                table: "MetaResumes",
                column: "ResumeInformationId",
                principalTable: "ResumeInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaData_MetaResumes_MetaResumeEntityId",
                table: "MetaData");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_ResumeInformation_ResumeInformationId",
                table: "MetaResumes");

            migrationBuilder.DropTable(
                name: "ResumeInformation");

            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_ResumeInformationId",
                table: "MetaResumes");

            migrationBuilder.DropIndex(
                name: "IX_MetaData_MetaResumeEntityId",
                table: "MetaData");

            migrationBuilder.DropColumn(
                name: "ResumeInformationId",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "MetaData");
        }
    }
}
