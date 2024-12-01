using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class MetaResumeRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Award_Resume_MetaResumeId",
                table: "Award");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Resume_MetaResumeId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Resume_MetaResumeId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_Resume_MetaResumeId",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageItem_Resume_MetaResumeId",
                table: "LanguageItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_Resume_ResumeId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Resume_MetaResumeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Publication_Resume_MetaResumeId",
                table: "Publication");

            migrationBuilder.DropForeignKey(
                name: "FK_ReferenceItem_Resume_MetaResumeId",
                table: "ReferenceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Resume_MetaResumeId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer_Resume_MetaResumeId",
                table: "Volunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Resume_MetaResumeId",
                table: "Work");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropTable(
                name: "ResumeFormat");

            migrationBuilder.DropIndex(
                name: "IX_Work_MetaResumeId",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Volunteer_MetaResumeId",
                table: "Volunteer");

            migrationBuilder.DropIndex(
                name: "IX_Skill_MetaResumeId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_ReferenceItem_MetaResumeId",
                table: "ReferenceItem");

            migrationBuilder.DropIndex(
                name: "IX_Publication_MetaResumeId",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Project_MetaResumeId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_LanguageItem_MetaResumeId",
                table: "LanguageItem");

            migrationBuilder.DropIndex(
                name: "IX_Interest_MetaResumeId",
                table: "Interest");

            migrationBuilder.DropIndex(
                name: "IX_Education_MetaResumeId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Certificate_MetaResumeId",
                table: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Award_MetaResumeId",
                table: "Award");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "ReferenceItem");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "LanguageItem");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Interest");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "MetaResumeId",
                table: "Award");

            migrationBuilder.RenameColumn(
                name: "ResumeId",
                table: "MetaResumes",
                newName: "BasicsId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_ResumeId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_BasicsId");

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Work",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Volunteer",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "ReferenceItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Publication",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserAccountEntityId",
                table: "MetaResumes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "LanguageItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Interest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Education",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Certificate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaResumeEntityId",
                table: "Award",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Work_MetaResumeEntityId",
                table: "Work",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_MetaResumeEntityId",
                table: "Volunteer",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_MetaResumeEntityId",
                table: "Skill",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceItem_MetaResumeEntityId",
                table: "ReferenceItem",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_MetaResumeEntityId",
                table: "Publication",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_MetaResumeEntityId",
                table: "Project",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MetaResumes_UserAccountEntityId",
                table: "MetaResumes",
                column: "UserAccountEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageItem_MetaResumeEntityId",
                table: "LanguageItem",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Interest_MetaResumeEntityId",
                table: "Interest",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_MetaResumeEntityId",
                table: "Education",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_MetaResumeEntityId",
                table: "Certificate",
                column: "MetaResumeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Award_MetaResumeEntityId",
                table: "Award",
                column: "MetaResumeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Award_MetaResumes_MetaResumeEntityId",
                table: "Award",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_MetaResumes_MetaResumeEntityId",
                table: "Certificate",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_MetaResumes_MetaResumeEntityId",
                table: "Education",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_MetaResumes_MetaResumeEntityId",
                table: "Interest",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageItem_MetaResumes_MetaResumeEntityId",
                table: "LanguageItem",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_Basics_BasicsId",
                table: "MetaResumes",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_UserAccounts_UserAccountEntityId",
                table: "MetaResumes",
                column: "UserAccountEntityId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_MetaResumes_MetaResumeEntityId",
                table: "Project",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_MetaResumes_MetaResumeEntityId",
                table: "Publication",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenceItem_MetaResumes_MetaResumeEntityId",
                table: "ReferenceItem",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_MetaResumes_MetaResumeEntityId",
                table: "Skill",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer_MetaResumes_MetaResumeEntityId",
                table: "Volunteer",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_MetaResumes_MetaResumeEntityId",
                table: "Work",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Award_MetaResumes_MetaResumeEntityId",
                table: "Award");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_MetaResumes_MetaResumeEntityId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_MetaResumes_MetaResumeEntityId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_MetaResumes_MetaResumeEntityId",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageItem_MetaResumes_MetaResumeEntityId",
                table: "LanguageItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_Basics_BasicsId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_UserAccounts_UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_MetaResumes_MetaResumeEntityId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Publication_MetaResumes_MetaResumeEntityId",
                table: "Publication");

            migrationBuilder.DropForeignKey(
                name: "FK_ReferenceItem_MetaResumes_MetaResumeEntityId",
                table: "ReferenceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_MetaResumes_MetaResumeEntityId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer_MetaResumes_MetaResumeEntityId",
                table: "Volunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_MetaResumes_MetaResumeEntityId",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Work_MetaResumeEntityId",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Volunteer_MetaResumeEntityId",
                table: "Volunteer");

            migrationBuilder.DropIndex(
                name: "IX_Skill_MetaResumeEntityId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_ReferenceItem_MetaResumeEntityId",
                table: "ReferenceItem");

            migrationBuilder.DropIndex(
                name: "IX_Publication_MetaResumeEntityId",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Project_MetaResumeEntityId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_MetaResumes_UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.DropIndex(
                name: "IX_LanguageItem_MetaResumeEntityId",
                table: "LanguageItem");

            migrationBuilder.DropIndex(
                name: "IX_Interest_MetaResumeEntityId",
                table: "Interest");

            migrationBuilder.DropIndex(
                name: "IX_Education_MetaResumeEntityId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Certificate_MetaResumeEntityId",
                table: "Certificate");

            migrationBuilder.DropIndex(
                name: "IX_Award_MetaResumeEntityId",
                table: "Award");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "ReferenceItem");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "UserAccountEntityId",
                table: "MetaResumes");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "LanguageItem");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Interest");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Certificate");

            migrationBuilder.DropColumn(
                name: "MetaResumeEntityId",
                table: "Award");

            migrationBuilder.RenameColumn(
                name: "BasicsId",
                table: "MetaResumes",
                newName: "ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_BasicsId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_ResumeId");

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Work",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Volunteer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Skill",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "ReferenceItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Publication",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "MetaResumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "MetaResumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "MetaResumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "LanguageItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Interest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Education",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Certificate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaResumeId",
                table: "Award",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BasicsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_Basics_BasicsId",
                        column: x => x.BasicsId,
                        principalTable: "Basics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ResumeFormat",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeFormatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmploymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industry = table.Column<int>(type: "int", nullable: false),
                    MinimumSalary = table.Column<float>(type: "real", nullable: false),
                    PaySchedule = table.Column<int>(type: "int", nullable: false),
                    ResumeSerialized = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeType = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserAccountEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeFormat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeFormat_MetaResumes_ResumeFormatId",
                        column: x => x.ResumeFormatId,
                        principalTable: "MetaResumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeFormat_UserAccounts_UserAccountEntityId",
                        column: x => x.UserAccountEntityId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Work_MetaResumeId",
                table: "Work",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_MetaResumeId",
                table: "Volunteer",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_MetaResumeId",
                table: "Skill",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceItem_MetaResumeId",
                table: "ReferenceItem",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_MetaResumeId",
                table: "Publication",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_MetaResumeId",
                table: "Project",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageItem_MetaResumeId",
                table: "LanguageItem",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interest_MetaResumeId",
                table: "Interest",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_MetaResumeId",
                table: "Education",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_MetaResumeId",
                table: "Certificate",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Award_MetaResumeId",
                table: "Award",
                column: "MetaResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_BasicsId",
                table: "Resume",
                column: "BasicsId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeFormat_ResumeFormatId",
                table: "ResumeFormat",
                column: "ResumeFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeFormat_UserAccountEntityId",
                table: "ResumeFormat",
                column: "UserAccountEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Award_Resume_MetaResumeId",
                table: "Award",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Resume_MetaResumeId",
                table: "Certificate",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Resume_MetaResumeId",
                table: "Education",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_Resume_MetaResumeId",
                table: "Interest",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageItem_Resume_MetaResumeId",
                table: "LanguageItem",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_Resume_ResumeId",
                table: "MetaResumes",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Resume_MetaResumeId",
                table: "Project",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_Resume_MetaResumeId",
                table: "Publication",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenceItem_Resume_MetaResumeId",
                table: "ReferenceItem",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Resume_MetaResumeId",
                table: "Skill",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer_Resume_MetaResumeId",
                table: "Volunteer",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Resume_MetaResumeId",
                table: "Work",
                column: "MetaResumeId",
                principalTable: "Resume",
                principalColumn: "Id");
        }
    }
}
