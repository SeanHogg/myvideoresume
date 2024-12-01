using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class MetaResumeMoreNamingUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Award_MetaResume_MetaResumeId",
                table: "Award");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_MetaResume_MetaResumeId",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_MetaResume_MetaResumeId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_MetaResume_MetaResumeId",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguageItem_MetaResume_MetaResumeId",
                table: "LanguageItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResume_Basics_BasicsId",
                table: "MetaResume");

            migrationBuilder.DropForeignKey(
                name: "FK_MetaResumes_MetaResume_ResumeStructureId",
                table: "MetaResumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_MetaResume_MetaResumeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Publication_MetaResume_MetaResumeId",
                table: "Publication");

            migrationBuilder.DropForeignKey(
                name: "FK_ReferenceItem_MetaResume_MetaResumeId",
                table: "ReferenceItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_MetaResumes_ResumeFormatId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_UserAccounts_UserAccountEntityId",
                table: "Resumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_MetaResume_MetaResumeId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer_MetaResume_MetaResumeId",
                table: "Volunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_MetaResume_MetaResumeId",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaResume",
                table: "MetaResume");

            migrationBuilder.RenameTable(
                name: "Resumes",
                newName: "ResumeFormat");

            migrationBuilder.RenameTable(
                name: "MetaResume",
                newName: "Resume");

            migrationBuilder.RenameColumn(
                name: "ResumeStructureId",
                table: "MetaResumes",
                newName: "ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_ResumeStructureId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_Resumes_UserAccountEntityId",
                table: "ResumeFormat",
                newName: "IX_ResumeFormat_UserAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Resumes_ResumeFormatId",
                table: "ResumeFormat",
                newName: "IX_ResumeFormat_ResumeFormatId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResume_BasicsId",
                table: "Resume",
                newName: "IX_Resume_BasicsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResumeFormat",
                table: "ResumeFormat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resume",
                table: "Resume",
                column: "Id");

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
                name: "FK_Resume_Basics_BasicsId",
                table: "Resume",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeFormat_MetaResumes_ResumeFormatId",
                table: "ResumeFormat",
                column: "ResumeFormatId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResumeFormat_UserAccounts_UserAccountEntityId",
                table: "ResumeFormat",
                column: "UserAccountEntityId",
                principalTable: "UserAccounts",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Resume_Basics_BasicsId",
                table: "Resume");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeFormat_MetaResumes_ResumeFormatId",
                table: "ResumeFormat");

            migrationBuilder.DropForeignKey(
                name: "FK_ResumeFormat_UserAccounts_UserAccountEntityId",
                table: "ResumeFormat");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Resume_MetaResumeId",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer_Resume_MetaResumeId",
                table: "Volunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Resume_MetaResumeId",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResumeFormat",
                table: "ResumeFormat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resume",
                table: "Resume");

            migrationBuilder.RenameTable(
                name: "ResumeFormat",
                newName: "Resumes");

            migrationBuilder.RenameTable(
                name: "Resume",
                newName: "MetaResume");

            migrationBuilder.RenameColumn(
                name: "ResumeId",
                table: "MetaResumes",
                newName: "ResumeStructureId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaResumes_ResumeId",
                table: "MetaResumes",
                newName: "IX_MetaResumes_ResumeStructureId");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeFormat_UserAccountEntityId",
                table: "Resumes",
                newName: "IX_Resumes_UserAccountEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ResumeFormat_ResumeFormatId",
                table: "Resumes",
                newName: "IX_Resumes_ResumeFormatId");

            migrationBuilder.RenameIndex(
                name: "IX_Resume_BasicsId",
                table: "MetaResume",
                newName: "IX_MetaResume_BasicsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resumes",
                table: "Resumes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaResume",
                table: "MetaResume",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Award_MetaResume_MetaResumeId",
                table: "Award",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_MetaResume_MetaResumeId",
                table: "Certificate",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_MetaResume_MetaResumeId",
                table: "Education",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_MetaResume_MetaResumeId",
                table: "Interest",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageItem_MetaResume_MetaResumeId",
                table: "LanguageItem",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResume_Basics_BasicsId",
                table: "MetaResume",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_MetaResume_ResumeStructureId",
                table: "MetaResumes",
                column: "ResumeStructureId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_MetaResume_MetaResumeId",
                table: "Project",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_MetaResume_MetaResumeId",
                table: "Publication",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenceItem_MetaResume_MetaResumeId",
                table: "ReferenceItem",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_MetaResumes_ResumeFormatId",
                table: "Resumes",
                column: "ResumeFormatId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_UserAccounts_UserAccountEntityId",
                table: "Resumes",
                column: "UserAccountEntityId",
                principalTable: "UserAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_MetaResume_MetaResumeId",
                table: "Skill",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer_MetaResume_MetaResumeId",
                table: "Volunteer",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_MetaResume_MetaResumeId",
                table: "Work",
                column: "MetaResumeId",
                principalTable: "MetaResume",
                principalColumn: "Id");
        }
    }
}
