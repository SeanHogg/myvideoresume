using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVideoResume.Data.Migrations.MyVideoResume
{
    /// <inheritdoc />
    public partial class RelationshipChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "UpdateTime",
                table: "MetaResumes",
                newName: "UpdateDateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "MetaResumes",
                newName: "DeletedDateTime");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "MetaResumes",
                newName: "CreationDateTime");

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

            migrationBuilder.RenameColumn(
                name: "UpdateDateTime",
                table: "MetaResumes",
                newName: "UpdateTime");

            migrationBuilder.RenameColumn(
                name: "DeletedDateTime",
                table: "MetaResumes",
                newName: "DeletedTime");

            migrationBuilder.RenameColumn(
                name: "CreationDateTime",
                table: "MetaResumes",
                newName: "CreationDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Award_MetaResumes_MetaResumeEntityId",
                table: "Award",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_MetaResumes_MetaResumeEntityId",
                table: "Certificate",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_MetaResumes_MetaResumeEntityId",
                table: "Education",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_MetaResumes_MetaResumeEntityId",
                table: "Interest",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageItem_MetaResumes_MetaResumeEntityId",
                table: "LanguageItem",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MetaResumes_Basics_BasicsId",
                table: "MetaResumes",
                column: "BasicsId",
                principalTable: "Basics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_MetaResumes_MetaResumeEntityId",
                table: "Project",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_MetaResumes_MetaResumeEntityId",
                table: "Publication",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReferenceItem_MetaResumes_MetaResumeEntityId",
                table: "ReferenceItem",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_MetaResumes_MetaResumeEntityId",
                table: "Skill",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer_MetaResumes_MetaResumeEntityId",
                table: "Volunteer",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Work_MetaResumes_MetaResumeEntityId",
                table: "Work",
                column: "MetaResumeEntityId",
                principalTable: "MetaResumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
